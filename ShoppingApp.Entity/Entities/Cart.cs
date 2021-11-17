using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Entity.Entities
{
    public class Cart
    {
        private List<CartLine> products = new List<CartLine>();
        public List<CartLine> Products => products;

        public void AddProduct(Product product , int quantity)
        {
            var prd = products.Where(i => i.Product.ProductID == product.ProductID).FirstOrDefault();

            if (prd==null)
            {
                products.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                prd.Quantity += quantity;
            }
        }

        public void UpdateProduct(Product product, int quantity)
        {
            var prd = products.Where(i => i.Product.ProductID == product.ProductID).FirstOrDefault();

            if (prd == null)
            {
                products.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                prd.Quantity = quantity;
            }
        }

        public void RemoveProduct(Product product)
        {
            products.RemoveAll(i => i.Product.ProductID == product.ProductID);
        }
        public double TotalPrice()
        {
            return products.Sum(x => x.Product.Price * x.Quantity);
        }

        public void ClearAll()
        {
            products.Clear();
        }
       
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
