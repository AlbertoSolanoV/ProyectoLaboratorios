using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System.Threading.Tasks;

namespace DevCodersApi.Controllers
{
    public class PaypalController : ApiController
    {
        [HttpPost]
        public APIData CreatePaypalOrder(OrdenDeCompra pOrden)
        {
            APIData resp = new APIData();
            string approveURL = string.Empty;

            PaymentObject payDesc = new PaymentObject()
            {
                Quantity = "1",
                Description = "Pago Realizado desde CLINNIX",
                Name = pOrden.NombreCliente,
                Sku = "sku",
                Tax = 0.0,
                UnitAmount = pOrden.Total
            };

            AdminPaypal admin = new AdminPaypal("http://localhost:44360/ProcesoDePago/PaypalProcess?", "");

            HttpResponse response = Task.Run(async () => await admin.CreateOrder(payDesc)).Result;

            //var statusCode = response.StatusCode;
            Order result = response.Result<Order>();

            //Revisar los Links que provee Paypal y devolver el Link al que se debe ir para hacer la Aprobación
            foreach (PayPalCheckoutSdk.Orders.LinkDescription link in result.Links)
            {
                if (link.Rel.Trim().ToLower() == "approve")
                {
                    approveURL = link.Href;
                }
            }
            if (!string.IsNullOrEmpty(approveURL))
            {
                resp.Result = "OK";
                resp.Data = approveURL;
            }
            return resp;
        }

        [HttpPost]
        public APIData ExcecutePaypalOrder(string PayerApprovedOrderId, string PayerID)
        {
            APIData resp = new APIData();

            AdminPaypal admin = new AdminPaypal("", PayerApprovedOrderId);


            List<string> paymentResultList = new List<string>();

            //this is where actual transaction is carried out
            HttpResponse response = Task.Run<HttpResponse>(async () => await admin.CaptureOrder()).Result;

            try
            {
                var statusCode = response.StatusCode;
                Order result = response.Result<Order>();

                //update view bag so user/payer gets to know the status
                if (result.Status.Trim().ToUpper() == "COMPLETED")

                    if (result.PurchaseUnits != null &&
                        result.PurchaseUnits.Count > 0 &&
                        result.PurchaseUnits[0].Payments != null &&
                        result.PurchaseUnits[0].Payments.Captures != null &&
                        result.PurchaseUnits[0].Payments.Captures.Count > 0)
                    {
                        resp.Result = "OK";
                        resp.Data = "Transaction ID: " + result.PurchaseUnits[0].Payments.Captures[0].Id;
                    }
                paymentResultList.Add("Transaction ID: " + result.PurchaseUnits[0].Payments.Captures[0].Id);
            }
            catch (Exception ex)
            {
                resp.Result = "ERROR";
                resp.Message = ex.Message;
            }

            return resp;
        }

    }

}