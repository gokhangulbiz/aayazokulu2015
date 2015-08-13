using AAYazOkulu.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using AAYazOkulu.WebAPI.Models;

namespace AAYazOkulu.WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public async Task<IEnumerable<ProductModel>> Get()
        {
            using (var dbModelContainer = new AAYazOkuluDBModelContainer())
            {
                return (await dbModelContainer.ProductSet.ToListAsync()).Select(t => new ProductModel
                {
                    AddedDate = t.AddedDate,
                    Description = t.Description,
                    Name = t.Name
                });
            }
        }

        // GET: api/Products/5
        public async Task<ProductModel> Get(int id)
        {
            ProductModel retVal = null;

            using (var dbModelContainer = new AAYazOkuluDBModelContainer())
            {
                var product = await dbModelContainer.ProductSet.SingleOrDefaultAsync(t => t.Id == id);
                if (product != null)
                {
                    retVal = new ProductModel
                    {
                        AddedDate = product.AddedDate,
                        Description = product.Description,
                        Name = product.Name
                    };
                }
                else
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
            }

            return retVal;
        }

        // POST: api/Products
        public async Task<ProductModel> Post([FromBody]ProductModel product)
        {
            using (var dbModelContainer = new AAYazOkuluDBModelContainer())
            {
                var addedProduct = dbModelContainer.ProductSet.Add(new Product
                {
                    AddedDate = product.AddedDate,
                    Description = product.Description,
                    Name = product.Name
                });

                await dbModelContainer.SaveChangesAsync();
                return new ProductModel
                {
                    AddedDate = addedProduct.AddedDate,
                    Description = addedProduct.Description,
                    Name = addedProduct.Name
                };
            }
        }

        // PUT: api/Products/5
        public async Task<ProductModel> Put(int id, [FromBody]ProductModel product)
        {
            using (var dbModelContainer = new AAYazOkuluDBModelContainer())
            {
                var productToBeUpdated = dbModelContainer.ProductSet.Find(id);
                if (productToBeUpdated != null)
                {
                    productToBeUpdated.AddedDate = product.AddedDate;
                    productToBeUpdated.Description = product.Description;
                    productToBeUpdated.Name = product.Name;
                }

                await dbModelContainer.SaveChangesAsync();

                return new ProductModel
                {
                    AddedDate = productToBeUpdated.AddedDate,
                    Description = productToBeUpdated.Description,
                    Name = productToBeUpdated.Name
                };
            }
        }

        // DELETE: api/Products/5
        public async Task Delete(int id)
        {
            using (var dbModelContainer = new AAYazOkuluDBModelContainer())
            {
                var productToBeDeleted = await dbModelContainer.ProductSet.SingleOrDefaultAsync(t => t.Id == id);
                if (productToBeDeleted != null)
                {
                    dbModelContainer.ProductSet.Remove(productToBeDeleted);
                    await dbModelContainer.SaveChangesAsync();
                }
            }
        }
    }
}
