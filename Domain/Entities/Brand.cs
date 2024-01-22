namespace Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Description = string.Empty;
        }

        public long Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }
}