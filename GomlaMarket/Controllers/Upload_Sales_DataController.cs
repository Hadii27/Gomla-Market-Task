using GomlaMarket.Models;
using GomlaMarketApi.web.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GomlaMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Upload_Sales_DataController : ControllerBase
    {
        private readonly IuploadSalesData _uploadSellsDataService;
        public Upload_Sales_DataController (IuploadSalesData uploadFileService)
        {
            _uploadSellsDataService = uploadFileService;
        }

        [HttpPost]
        [RequestFormLimits(MultipartBodyLengthLimit = 524288000)]
        [RequestSizeLimit(524288000)]
        public async Task<IActionResult> UploadData(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");
            var allowedExtension = ".csv";
            var fileExtension = Path.GetExtension(file.FileName).ToLower();
            if (fileExtension != allowedExtension)
                return BadRequest("Unable to upload this file, Only csv Files allowed");
                
            
            var result = await _uploadSellsDataService.UploadCsvFile(file);

            if (result == null)
                return NotFound("Processing failed or no data found.");

            return Ok(result);
        }
    }
}
