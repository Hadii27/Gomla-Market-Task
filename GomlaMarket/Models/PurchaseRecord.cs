using System.ComponentModel.DataAnnotations;

namespace GomlaMarket.Models
{
    public class PurchaseRecord
    {
        public int ID { get; set; }
        [Display(Name = "صافى المشتريات")]
        public decimal NetPurchasesValue { get; set; }

        [Display(Name = "نسبه المرتجعات للمشتريات")]
        public decimal PurchaseReturnRate { get; set; }

        [Display(Name = "قيمة المرتجعات")]
        public decimal ReturnValue { get; set; }

        [Display(Name = "قيمة المشتريات")]
        public decimal PurchaseValue { get; set; }

        [Display(Name = "كمية البوانص")]
        public decimal BonusQuantity { get; set; }

        [Display(Name = "صافى كمية المشتريات")]
        public int NetPurchaseQuantity { get; set; }

        [Display(Name = "إسم الصنف")]
        public string ItemName { get; set; }

        [Display(Name = "كود الصنف")]
        public string ItemCode { get; set; }
    }
}
