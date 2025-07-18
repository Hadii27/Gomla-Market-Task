using GomlaMarketApi.web.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GomlaMarketApi.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Upload_Purchase_DataController : ControllerBase
    {
        private readonly IuploadPurchaseDataService _PurchaseService;
        public Upload_Purchase_DataController(IuploadPurchaseDataService purchaseService)
        {
            _PurchaseService = purchaseService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadPurchaseData (IFormFile file)
        {
            var AllowedExtension = ".xlsx" ;
            if (file == null || file.Length == 0)
                return BadRequest("No File was Uploaded");

            var extension = Path.GetExtension(file.FileName).ToLower();
            if (extension != AllowedExtension)
                return BadRequest("Unable to upload this file. Only Excel files are allowed");
            var result = await _PurchaseService.Upload_Excel_File (file);
            return Ok (result);
        }
    }
}
