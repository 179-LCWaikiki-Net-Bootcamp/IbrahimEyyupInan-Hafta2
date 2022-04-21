namespace IbrahimEyyupInan_Hafta2.Model.Dto
{
    public class ProductViewModel
    {
        // bu obje bir get veya request cevabı olarak dönülecek olan objedir. sadece kullanıcıya cevap verilirken kullanılır.
        // (Dto adı ile ifade edilenler gelen , ViewModel ile ifade edilenler giden veriyi temsil ediyor.)
        public int Id { get; set; }
        public string Name { get; set; }
        public string sku { get; set; }
        public double Price { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }    
    }
}
