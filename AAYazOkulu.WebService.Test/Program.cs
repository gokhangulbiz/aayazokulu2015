using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAYazOkulu.WebService.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductServiceClient.ProductServiceSoapClient productServiceClient = new ProductServiceClient.ProductServiceSoapClient();
            
            productServiceClient.AddProduct(new ProductServiceClient.Product()
            {
                Id = 1,
                AddedDate = DateTime.Now,
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
            });

            var products = productServiceClient.GetProduct(5);
        }
    }
}
