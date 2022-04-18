using System.Collections.Generic;

namespace IbrahimEyyupInan_Hafta2.Model
{
    public class Category:EntityBase
    {
        public Category()
        {
            products = new HashSet<Product>(); 
        }
        public ICollection<Product> products { set; get; }
    }
}
