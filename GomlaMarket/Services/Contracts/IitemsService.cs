using GomlaMarket.DTOS;
using GomlaMarketApi.web.DTOS;

namespace GomlaMarketApi.web.Services.Contracts
{
    public interface IitemsService
    {
        Task<GetItemDto> GetItemByName(string name);
        Task<GetItemDto> GetSalesInfo(string itemName);
        Task<GetItemDto> GetPurchaseInfo(string itemName);
        Task<ProfitDto> GetProfitOfItem(string itemName);
        Task<List<SalesRecordDto>> BestSales(int n);
        Task<List<DeadstockDto>> DeadStockItems();
    }
}
