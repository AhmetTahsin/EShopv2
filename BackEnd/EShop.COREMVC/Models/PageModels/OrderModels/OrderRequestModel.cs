namespace EShop.COREMVC.Models.PageModels.OrderModels
{
    public class OrderRequestModel
    {
        public string ShippingAddress { get; set; }
        public string Email { get; set; } 
        public string NameDescription { get; set; }
        public int? AppUserID { get; set; } 
        public decimal PriceOfOrder { get; set; }
    }
}
