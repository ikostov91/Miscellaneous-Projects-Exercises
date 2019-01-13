namespace StorageMaster.Models.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            var productType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == type);

            if (productType == null)
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            Product product = (Product) Activator.CreateInstance(productType, price);
            return product;
        }
    }
}
