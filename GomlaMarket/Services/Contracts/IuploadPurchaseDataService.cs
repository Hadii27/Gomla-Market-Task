using GomlaMarket.Models;

namespace GomlaMarketApi.web.Services.Contracts
{
    public interface IuploadPurchaseDataService
    {
        Task<List<PurchaseRecord>> Upload_Excel_File(IFormFile file);

    }
}
