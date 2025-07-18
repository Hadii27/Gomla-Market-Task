using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using GomlaMarket.db;
using GomlaMarket.Models;
using GomlaMarketApi.web.Services.Contracts;
using Microsoft.AspNetCore.Identity;

namespace GomlaMarketApi.web.Services.Implement
{
    public class UploadPurchaseDataService : IuploadPurchaseDataService
    {
        private readonly dataContext _dataContext;
        public UploadPurchaseDataService (dataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<PurchaseRecord>> Upload_Excel_File(IFormFile file)
        {
            var records = new List<PurchaseRecord>();
            var stream = new MemoryStream();

            try
            {
                await file.CopyToAsync(stream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Stream copy failed: " + ex.Message);
                throw;
            }

            stream.Position = 0;

            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            var lastRow = worksheet.LastRowUsed().RowNumber();

            for (int i = 3; i <= lastRow; i++)
            {
                var row = worksheet.Row(i);

                var itemCode = row.Cell(18).GetString();
                if (string.IsNullOrWhiteSpace(itemCode) || itemCode == "كود الصنف")
                    continue;

                decimal SafeDecimal(string input)
                {
                    if (decimal.TryParse(input.Replace("%", "").Trim(), out var val))
                        return val;
                    return 0;
                }

                int SafeInt(string input)
                {
                    if (int.TryParse(input.Trim(), out var val))
                        return val;
                    return 0;
                }

                var record = new PurchaseRecord
                {
                    ItemCode = itemCode,
                    ItemName = row.Cell(12).GetString()?.Trim(),
                    NetPurchaseQuantity = SafeInt(row.Cell(11).GetString()),
                    BonusQuantity = SafeDecimal(row.Cell(7).GetString()),
                    NetPurchasesValue = SafeDecimal(row.Cell(5).GetString()),
                    ReturnValue = SafeDecimal(row.Cell(4).GetString()),
                    PurchaseReturnRate = SafeDecimal(row.Cell(2).GetString()),
                    PurchaseValue = SafeDecimal(row.Cell(1).GetString()),
                };

                records.Add(record);
            }

            _dataContext.purchaseRecords.AddRange(records);
            await _dataContext.SaveChangesAsync();
            return records;
        }

    }
}
