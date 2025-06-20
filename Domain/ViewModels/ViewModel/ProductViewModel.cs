namespace Domain.ViewModels.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Name = string.Empty;
            Description = string.Empty;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long BrandId { get; set; }
    }
}