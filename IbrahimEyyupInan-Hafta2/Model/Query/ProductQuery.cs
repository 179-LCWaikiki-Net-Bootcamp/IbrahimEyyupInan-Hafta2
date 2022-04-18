namespace IbrahimEyyupInan_Hafta2.Model.Query
{
    public class ProductQuery:BaseQuery
    {
        public string sku { get; set; }
        public int? categoryId { get; set; }
        public string categoryName { get; set; }
        public int? priceStart { get; set; }
        public int? priceEnd { get; set; }
    }
}
