using DesktopModel.Model;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace DesktopModel.Services
{
    public class Productservice : IProductservice
    {
        string path = "D:/Demo/Json";
        public async Task<string> AddData(List<Product> Product)
        {
            
            var json = JsonConvert.SerializeObject(Product, Formatting.Indented);
            File.WriteAllText(Path.Combine(path, "Product.json"), string.Empty);
            File.WriteAllText(Path.Combine(path, "Product.json"),json);
            return "Add Sucessfully!!";
        }

        public async Task<List<Product>> GetRequestData()
        {
            List<Product> products = new List<Product>();
            var Data = File.ReadAllText(Path.Combine(path, "UpdateProduct.json"));
            products = JsonConvert.DeserializeObject<List<Product>>(Data);
            return products;
        }

        public async Task<List<Product>> GetData()
        {
            List<Product> products = new List<Product>();
            var Data = File.ReadAllText(Path.Combine(path, "Product.json"));
            products = JsonConvert.DeserializeObject<List<Product>>(Data);
            return products;
        }

        public async Task<string> Updatedata(List<Product> Product)
        {
            List<Product> products = new List<Product>();
            var Data = File.ReadAllText(Path.Combine(path, "UpdateProduct.json"));
            products = JsonConvert.DeserializeObject<List<Product>>(Data);
            foreach(var item in Product)
            {
                if(products != null)
                {
                    if (products.Any(x => x.Id == item.Id))
                    {
                        return "First Approve Request Product:- " + item.Items;
                    }
                }
                else
                {
                    products = new();
                }
                item.Check = false;
            }
            products.AddRange(Product);
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(Path.Combine(path, "UpdateProduct.json"), string.Empty);
            File.WriteAllText(Path.Combine(path, "UpdateProduct.json"), json);
            return "Update Sucessfully!!";
        }

        public async Task<string> ApproveData(List<Product> Product)
        {
            List<Product> products = new List<Product>();
            var PendingData = File.ReadAllText(Path.Combine(path, "UpdateProduct.json"));
            products = JsonConvert.DeserializeObject<List<Product>>(PendingData);
            foreach (var item in Product)
            {
                foreach (var tom in products.Where(w => w.Id == item.Id).ToList())
                {
                    products.Remove(tom);
                }
            }
            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(Path.Combine(path, "UpdateProduct.json"), string.Empty);
            File.WriteAllText(Path.Combine(path, "UpdateProduct.json"), json);

            products = null;
            var Data = File.ReadAllText(Path.Combine(path, "Product.json"));
            products = JsonConvert.DeserializeObject<List<Product>>(Data);
            foreach (var item in Product.ToList())
            {
                foreach (var tom in products.Where(w => w.Id == item.Id))
                {
                    tom.Quantity = item.Quantity - item.AvailableQuan;
                    tom.ApprovedBy = item.ApprovedBy;
                }
            }
            var json1 = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(Path.Combine(path, "Product.json"), string.Empty);
            File.WriteAllText(Path.Combine(path, "Product.json"), json1);
            return "Approve Sucessfully!!";
        }
    }
}
