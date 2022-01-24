using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Upwork.ElasticSearch_Net.Contacts.Properties;
using Upwork.ElasticSearch_Net.Contacts.Shared;
using Upwork.ElasticSearch_Net.Models;

namespace Upwork.ElasticSearch_Net.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PropertiesController : ControllerBase {
    private readonly IPropertyService _propertyService;

    public PropertiesController(IPropertyService propertyService) {
        _propertyService = propertyService;
    }

    [HttpPost]
    public async Task<IActionResult> BulkUpload(IFormFile formFile) {
        IEnumerable<Property>? properties = null;

        try {
            using var stream = formFile.OpenReadStream();

            properties = JsonSerializer.Deserialize<List<PropertyUploadItem>>(stream, ApiConsts.DefaultJsonSerializerOptions)?.Select(x => x.Property);
        } catch (Exception e) {
            // log - most likely I would implement global error handler
            return BadRequest(e.Message);
        }

        if (properties == null) {
            return BadRequest("No properties were uploaded");
        }

        await _propertyService.BulkUpload(properties);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Search([FromQuery] SearchInput input) {
        var result = await _propertyService.GetAll(input); // should improve global error handling 
        return Ok(result);
    }
}
