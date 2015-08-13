using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAYazOkulu.WebAPI.Client.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }

        static async Task MainAsync()
        {
            ProductClient pc = new ProductClient();
            var product = await pc.GetAsync(1);
            Console.WriteLine(product.Name);
            Console.ReadKey();
        }
    }
}
