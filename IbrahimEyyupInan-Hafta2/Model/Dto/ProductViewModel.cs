﻿namespace IbrahimEyyupInan_Hafta2.Model.Dto
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string sku { get; set; }
        public double Price { get; set; }
        public int categoryId { get; set; }
        public string categoryName { get; set; }    
    }
}
