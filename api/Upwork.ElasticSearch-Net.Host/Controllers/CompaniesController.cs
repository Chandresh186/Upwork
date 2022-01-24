using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Upwork.ElasticSearch_Net.Contacts.Companies;
using Upwork.ElasticSearch_Net.Contacts.Shared;
using Upwork.ElasticSearch_Net.Models;

namespace Upwork.ElasticSearch_Net.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase {
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyService companyService) {
        _companyService = companyService;
    }

    [HttpPost]
    public async Task<IActionResult> BulkUpload(IFormFile formFile) {
        IEnumerable<Company>? companies = null;

        try {
            using var stream = formFile.OpenReadStream();

            companies = JsonSerializer.Deserialize<List<CompanyUploadItem>>(stream, ApiConsts.DefaultJsonSerializerOptions)?.Select(x => x.Mgmt);
        } catch (Exception e) {
            // log - most likely I would implement global error handler
            return BadRequest(e.Message);
        }

        if (companies == null) {
            return BadRequest("No companies were uploaded");
        }

        await _companyService.BulkUpload(companies);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] SearchInput input) {
        var result = await _companyService.GetAll(input); // should improve global error handling 
        return Ok(result);
    }
}
