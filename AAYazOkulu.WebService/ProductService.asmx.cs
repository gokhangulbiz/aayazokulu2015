using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AAYazOkulu.WebService
{
    /// <summary>
    /// Summary description for ProductService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class ProductService : System.Web.Services.WebService
    {
        static List<Product> products = new List<Product> {
                new Product {
                    Id = 1,
                    AddedDate = DateTime.Now,
                    Description = Guid.NewGuid().ToString(),
                    Name = Guid.NewGuid().ToString()
                }
            };

        [WebMethod]
        public Product AddProduct(Product product)
        {
            products.Add(product);
            return product;
        }

        [WebMethod]
        public List<Product> GetProducts()
        {
            return products;
        }

        [WebMethod]
        public Product GetProduct(int id)
        {
            return products.SingleOrDefault(t => t.Id == id);
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public DateTime AddedDate { get; set; }
        }
    }
}
