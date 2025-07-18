using System.Reflection.Metadata.Ecma335;

namespace GomlaMarket.DTOS
{
    public class GetItemDto
    {
        public string id { get; set; }
        public string name { get; set; }

        public string Barcode { get; set; }
        public int departmentID { get; set; }
        public string departmentName { get; set; }
        public int MainGroupID { get; set; }
        public string MainGroupName { get; set; }

        public int SubGroupID { get; set; }
        public string SubGroupName { get; set; }

        public decimal TotalPurchaseValue { get; set; }
        public decimal TotalSalesValue { get; set; }
        public decimal ItemQty { get; set; }


    }
}
