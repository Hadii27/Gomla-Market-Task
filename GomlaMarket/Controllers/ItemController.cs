using GomlaMarketApi.web.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace GomlaMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IitemsService _ItemService;
        public ItemController(IitemsService iItemService)
        { 
            _ItemService = iItemService;
        }

        [HttpGet("GetItemInfo")]
        public async Task<IActionResult> GetItemByname(string name)
        {
            var result = await _ItemService.GetItemByName(name);
            return Ok(result);
        }

        [HttpGet("GetProfit")]
        public async Task<IActionResult> Profit(string name)
        {
            var result = await _ItemService.GetProfitOfItem(name);
            return Ok(result);
        }

        [HttpGet("BestSales")]
        public async Task<IActionResult> BestSales(int N)
        {
            var result = await _ItemService.BestSales(N);
            return Ok(result);
        }

        [HttpGet("DeadStock")]
        public async Task<IActionResult> GetDeadstockItem()
        {
            var result = await _ItemService.DeadStockItems();
            if  (result.IsNullOrEmpty())
                return NotFound("No Deadstock items Found");
            return Ok(result);
        }
    }
}
