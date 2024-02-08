namespace Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Description = string.Empty;
            Products = new List<Product>();
        }

        public long Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}