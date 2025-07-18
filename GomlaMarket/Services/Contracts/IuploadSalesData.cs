using GomlaMarket.Models;

namespace GomlaMarketApi.web.Services.Contracts
{
    public interface IuploadSalesData
    {

        Task<List<SaleRecord>> UploadCsvFile(IFormFile file);
    }
}
