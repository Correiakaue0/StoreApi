namespace Domain.ViewModels.ReturnViewModels
{
    public class BrandReturnViewModel
    {
        public BrandReturnViewModel()
        {
            Description = string.Empty;
        }

        public long Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
    }
}