namespace IbrahimEyyupInan_Hafta2.Model
{
    public class Product : EntityBase
    {
        public double? Price { get; set; }
        public string sku { get; set; }

        public Category category { get; set; }
        public int? categoryId { get; set; }
    }
}
