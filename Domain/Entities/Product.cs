namespace Domain.Entities
{
    public class Product
    {
        public Product()
        {
            Name = string.Empty;
            Description = string.Empty;
            Brand = new Brand();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public long BrandId { get; set; }

        public Brand Brand { get; set; }   
    }
}