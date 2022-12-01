using ETrade.DTO;

namespace ETrade.UI.Models.ViewModel
{
    public class BasketDetailModel
    {
        public List<ProductsDTO> ProductsDTO { get; set; }
        public List<BasketDetailDTO> BasketDetailDTO { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Ratio { get; set; }
        public int UnitId { get; set; }
    }
}
