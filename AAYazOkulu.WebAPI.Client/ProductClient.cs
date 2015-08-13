using AAYazOkulu.WebAPI.Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AAYazOkulu.WebAPI.Client
{
    public class ProductClient
    {
        HttpClient httpClient;
        public ProductClient(HttpClient httpClient = null)
        {
            // :(
            this.httpClient = httpClient == null ? new HttpClient() { BaseAddress = new Uri("http://localhost:1574") } : httpClient;
        }
        
        public async Task<IEnumerable<Product>> GetAsync()
        {
            var httpResponse = await httpClient.GetAsync("api/products");
            return await httpResponse.Content.ReadAsAsync<IEnumerable<Product>>();
        }

        public async Task<Product> GetAsync(int id)
        {
            var httpResponse = await httpClient.GetAsync(string.Format("api/products/{0}", id));
            return await httpResponse.Content.ReadAsAsync<Product>();
        }

        //// POST: api/Products
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Products/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Products/5
        //public void Delete(int id)
        //{
        //}

    }
}
