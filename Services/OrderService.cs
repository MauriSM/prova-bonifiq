using ProvaPub.Models;
using System.Runtime.CompilerServices;

namespace ProvaPub.Services
{
    public class OrderService
    {
        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
        //    if (paymentMethod == "pix")
        //    {
        //        //Faz pagamento...
        //    }
        //    else if (paymentMethod == "creditcard")
        //    {
        //        //Faz pagamento...
        //    }
        //    else if (paymentMethod == "paypal")
        //    {
        //        //Faz pagamento...
        //    }

            switch (paymentMethod)
            {

                case "pix":
                //Faz pagamento...


                case "creditcard":

                //Faz pagamento...


                case "paypal":

                //Faz pagamento...

                default:
                    break;
            }

            return await Task.FromResult(new Order()
            {
                Value = paymentValue
            });
        }
    }
}
