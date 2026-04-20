namespace Frags.Services.ViewModels.Fragrance
{
    public class FragranceShopModel
    {
        public IEnumerable<FragranceViewModel> Fragrances { get; set; } = new List<FragranceViewModel>();
        public int TotalItems { get; set; }
    }
}
