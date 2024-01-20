using MVC_OnlineTicariOtomasyon.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_OnlineTicariOtomasyon.Models.Trigger
{
    public class TriggerAction
    {
            Context DbTrigger=new Context();
            public void PerformTrigger(int productId, int soldQuantity)
            {
                UpdateProductStock(productId, soldQuantity);
            }

            private void UpdateProductStock(int productId, int soldQuantity)
            {
                Product product = DbTrigger.Products.FirstOrDefault(p => p.ProductID == productId);

                if (product != null)
                {
                    product.ProductStock -= (short)soldQuantity;

                    DbTrigger.SaveChanges();
                }
            }
    }
}