using System.Globalization;
using ClosedXML.Excel;
using System.IO;
using CsvHelper;
using GomlaMarket.db;
using GomlaMarket.Mapping;
using GomlaMarket.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using GomlaMarketApi.web.Services.Contracts;

namespace GomlaMarketApi.web.Services.Implement
{
    public class UploadSalesDataService : IuploadSalesData
    {
        private readonly dataContext _context;
        public UploadSalesDataService(dataContext context)
        { 
            _context = context;
        }

        public async Task<List<SaleRecord>> UploadCsvFile(IFormFile file)
        {
            var records = new List<SaleRecord>();
            var stream = new MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;
            var reader = new StreamReader(stream);
            var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

            csv.Context.RegisterClassMap<SellingRecordsMap>();
            records = csv.GetRecords<SaleRecord>().ToList();      
            _context.saleRecords.AddRange(records);
            await _context.SaveChangesAsync();
            return records;
        }
      
    }
}
