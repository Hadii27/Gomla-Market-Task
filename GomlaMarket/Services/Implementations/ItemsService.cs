using GomlaMarket.db;
using GomlaMarket.DTOS;
using GomlaMarket.Models;
using GomlaMarketApi.web.DTOS;
using GomlaMarketApi.web.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GomlaMarketApi.web.Services.Implement
{
    public class ItemsService : IitemsService
    {
        private readonly dataContext _Context;
        public ItemsService(dataContext context)
        {
            _Context = context;
        }

        public async Task<GetItemDto> GetPurchaseInfo(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
                throw new Exception("Inter a valid name");

            var result = await _Context.purchaseRecords
                .Where(i => i.ItemName == itemName)
                .GroupBy(i => i.ItemName)
                .Select(g => new GetItemDto
                {
                    name = g.Key,
                    TotalPurchaseValue = g.Sum(i => i.PurchaseValue),
                    ItemQty = g.Sum(i => i.NetPurchaseQuantity)
                })
                .FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("No Results Found!");
            return result;
        }
        public async Task<GetItemDto> GetSalesInfo(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
                throw new Exception("Inter a valid name");
            var result = await _Context.saleRecords
                .Where(i => i.ItemName == itemName)
                .GroupBy(i => i.ItemName)
                .Select(g => new GetItemDto
                {
                    name = g.Key,
                    TotalSalesValue = g.Sum(i => i.NetSalesValue),
                    ItemQty = g.Sum(q => q.NetQuantitySold),
                }
                )

                .FirstOrDefaultAsync();
             if (result == null)
                throw new Exception("No Results Found!");
            return result;
        }
        public async Task<GetItemDto> GetItemByName(string name)
        {

            var Item = await _Context.purchaseRecords
                .Where(i => i.ItemName == name).FirstOrDefaultAsync();

            if (Item is null)
                throw new Exception("Item Not Found");

            var ItemID = Item.ItemCode;
            var ItemName = Item.ItemName;
            var PurchaseInfo = await GetPurchaseInfo(name);
            var SalesInfo = await GetSalesInfo(name);

            if (PurchaseInfo is null || SalesInfo is null)
                throw new Exception("No purchase or sales data available for this item.");

            var Qty = PurchaseInfo.ItemQty - SalesInfo.ItemQty;

            var itemInfo = await _Context.saleRecords
                .Where(i => i.ItemName == ItemName)
                .FirstOrDefaultAsync();

            if (itemInfo is null)
                throw new Exception("No Info For this item");

            var result = new GetItemDto
            {
                id = ItemID,
                name = itemInfo.ItemName,
                Barcode = itemInfo.Barcode,
                MainGroupID = itemInfo.MainGroupCode,
                MainGroupName = itemInfo.MainGroupName,
                SubGroupID = itemInfo.SubGroupCode,
                SubGroupName = itemInfo.SubGroupName,
                departmentID = itemInfo.DepartmentCode,
                departmentName = itemInfo.DepartmentName,
                TotalPurchaseValue = PurchaseInfo.TotalPurchaseValue,
                TotalSalesValue = SalesInfo.TotalSalesValue,               
                ItemQty = Qty,
            };
            return result;          
        }
        public async Task<ProfitDto> GetProfitOfItem(string itemName)
        {
            var salesInfo = await GetSalesInfo(itemName);
            var purchaseInfo = await GetPurchaseInfo(itemName);
            if (salesInfo is null || purchaseInfo is null)
                throw new Exception("Unavailable");

            var Profit = purchaseInfo.TotalPurchaseValue - salesInfo.TotalSalesValue;
            var result = new ProfitDto
            {
                Profit = Profit,
            };
            return result;
        }
        public async Task<List<SalesRecordDto>> BestSales(int n)
        {
            var result = await _Context.saleRecords
                .GroupBy(i => i.ItemName)
                .Select(
                    g => new SalesRecordDto
                    {
                        ItemName = g.Key,
                        TotalQuantitySold = g.Sum(i => i.NetQuantitySold),
                        TotalSalesValue = g.Sum(i => i.NetSalesValue)
                    }
                )
                .OrderByDescending(i => i.TotalQuantitySold)
                .Take(n)
                .ToListAsync();
            return result;
        }

        public async Task<List<DeadstockDto>> DeadStockItems()
        {
            var sales_qty = await _Context.saleRecords
               .GroupBy(i => i.ItemName)
               .Select(
                   g => new SalesRecordDto
                   {
                       ItemName = g.Key,
                       TotalQuantitySold = g.Sum(i => i.NetQuantitySold),
                   }
               )
               .ToListAsync();

            var Purchase_qty = await _Context.purchaseRecords
                 .GroupBy(i => i.ItemName)
                 .Select(
                    g => new PurchaseDto
                    {

                        ItemName = g.Key,
                        TotalQuantityPurchase = g.Sum(i => i.NetPurchaseQuantity)
                    }
                 )
                 .ToListAsync();

            var result = (
                from sale in sales_qty
                join purcahse in Purchase_qty
                on sale.TotalQuantitySold equals purcahse.TotalQuantityPurchase
                select new DeadstockDto
                {
                    ItemName = sale.ItemName,
                    Qty = 0
                }
                )
                .ToList();

            return result;

        }
        
    }
}
