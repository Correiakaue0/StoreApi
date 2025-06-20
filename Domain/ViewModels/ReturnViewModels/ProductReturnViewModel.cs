namespace Domain.ViewModels.ReturnViewModels
{
    public class ProductReturnViewModel
    {
        public ProductReturnViewModel()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long BrandId { get; set; }
    }
}