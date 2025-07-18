using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace GomlaMarket.Models
{
    public class SaleRecord
    {
        public int id { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public int MainGroupCode { get; set; }
        public string MainGroupName { get; set; }
        public int SubGroupCode { get; set; }
        public string SubGroupName { get; set; }
        public string ItemCode { get; set; }
        public string Barcode { get; set; }
        public string ItemName { get; set; }
        public decimal NetQuantitySold { get; set; }
        public decimal NetSalesValue { get; set; }
    }
}
