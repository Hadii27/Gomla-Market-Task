using System.Text.RegularExpressions;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using GomlaMarket.Models;

namespace GomlaMarket.Mapping
{

    public class SellingRecordsMap  : ClassMap<SaleRecord>
    {
        public SellingRecordsMap() 
        {
            Map(m => m.BranchCode).Name("كود الفرع");
            Map(m => m.BranchName).Name("اسم الفرع");
            Map(m => m.DepartmentCode).Name("كود القسم");
            Map(m => m.DepartmentName).Name("القسم");
            Map(m => m.MainGroupCode).Name("مجموعة رئيسية");
            Map(m => m.MainGroupName).Name("اسم مجموعة رئيسية");
            Map(m => m.SubGroupCode).Name("مجموعة فرعية");
            Map(m => m.SubGroupName).Name("اسم المجموعة فرعية");
            Map(m => m.ItemCode).Name("كود الصنف");
            Map(m => m.Barcode).Name("باركود");
            Map(m => m.ItemName).Name("اسم الصنف");
            Map(m => m.NetQuantitySold).Name("صافى كمية مبيعات");
            Map(m => m.NetSalesValue).Name("صافى قيمة مبيعات");
        }
    }
}
