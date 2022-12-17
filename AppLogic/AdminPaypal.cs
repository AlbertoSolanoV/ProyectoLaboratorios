using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using DTO;

namespace AppLogic
{
    public class AdminPaypal
    {
        private string _paypalEnvironment;
        private string _clientId;
        private string _secret;
        private PaypalConfig paypalConfigData;
        private const double CHANGE_TYPE_CRC_USD = 622.0;
        private const string CURRENCY_PAY = "USD";

        public AdminPaypal(string redirectURL, string payerApprovedOrderId)
        {
            _paypalEnvironment = "sandbox";//live
            _clientId = "Ado1q1d0UuXuMrtjMN3nhyIqIX07VEyl44W1vOhN_n3ykL5sPGnvX_a_o4g41EfLZKwxe5ijYm5_eGW1";
            _secret = "EBZKCMChm1-4F71hK_cILb6mQBiHuHXo1wxc4MpAIg2c5wAmAN_1-j7IVhe75LKIWC3KuOCZhRe-TNev";

            paypalConfigData = new PaypalConfig();
            paypalConfigData.Environment = _paypalEnvironment;
            paypalConfigData.ClientId = _clientId;
            paypalConfigData.Secret = _secret;
            paypalConfigData.RedirectUrl = redirectURL;
            paypalConfigData.PayerApprovedOrderId = payerApprovedOrderId;
        }

        /// <summary>
        /// Initiates Paypal Client. Must ensure correct environment.
        /// </summary>            
        /// <returns>PayPalHttp.HttpClient</returns>
        private PayPalHttpClient Client()
        {
            PayPalEnvironment environment = null;

            if (paypalConfigData.Environment == "live")
            {
                // Creating a live environment
                environment = new LiveEnvironment(paypalConfigData.ClientId, paypalConfigData.Secret);
            }
            else
            {
                // Creating a sandbox environment
                environment = new SandboxEnvironment(paypalConfigData.ClientId, paypalConfigData.Secret);
            }

            // Creating a Client for the environment
            PayPalHttpClient client = new PayPalHttpClient(environment);
            return client;
        }

        //### Creating an Order
        //This will create an order and print order id for the created order

        public async Task<HttpResponse> CreateOrder(PaymentObject paymentObject)
        {
            HttpResponse response = null;

            try
            {
                // Construct a request object and set desired parameters
                // Here, OrdersCreateRequest() creates a POST request to /v2/checkout/orders
                #region order_creation
                var order = new OrderRequest()
                {
                    CheckoutPaymentIntent = "CAPTURE",
                    PurchaseUnits = new List<PurchaseUnitRequest>()
                        {
                            new PurchaseUnitRequest()
                            {
                                Items = new List<Item>()
                                {
                                    new Item()
                                    {
                                        Quantity = paymentObject.Quantity.ToString(),
                                        Name = paymentObject.Name,
                                        Description = paymentObject.Description,
                                        Sku = paymentObject.Sku,
                                        Tax = new Money(){ CurrencyCode = CURRENCY_PAY, Value = GetPaymentValueUSD(paymentObject.Tax) },
                                        UnitAmount = new Money(){ CurrencyCode = CURRENCY_PAY, Value = GetPaymentValueUSD(paymentObject.UnitAmount) }
                                    }
                                },
                                AmountWithBreakdown = new AmountWithBreakdown()
                                {
                                    CurrencyCode = CURRENCY_PAY,
                                    Value = GetPaymentValueUSD(paymentObject.UnitAmount),

                                    AmountBreakdown = new AmountBreakdown()
                                    {
                                        TaxTotal = new Money()
                                        {
                                            CurrencyCode = CURRENCY_PAY,
                                            Value = "0.00"
                                        },
                                        Shipping = new Money()
                                        {
                                            CurrencyCode = CURRENCY_PAY,
                                            Value = "0.00"
                                        },
                                        ItemTotal = new Money()
                                        {
                                            CurrencyCode = CURRENCY_PAY,
                                            Value = GetPaymentValueUSD(paymentObject.UnitAmount)
                                        }
                                    }
                                }
                            }
                        },
                    ApplicationContext = new ApplicationContext()
                    {
                        ReturnUrl = paypalConfigData.RedirectUrl,
                        CancelUrl = paypalConfigData.RedirectUrl + "&Cancel=true"
                    }
                };

                #endregion

                //IMPORTANT
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                // Call API with your Client and get a response for your call
                var request = new OrdersCreateRequest();
                request.Prefer("return=representation");
                request.RequestBody(order);
                PayPalHttpClient paypalHttpClient = Client();
                response = await paypalHttpClient.Execute(request);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
                throw;
            }
            return response;
        }

        //### Capturing an Order
        //Before capturing an order, order should be approved by the buyer using the approve link in create order response

        public async Task<HttpResponse> CaptureOrder()
        {
            // Construct a request object and set desired parameters
            // Replace ORDER-ID with the approved order id from create order
            var request = new OrdersCaptureRequest(paypalConfigData.PayerApprovedOrderId);
            request.RequestBody(new OrderActionRequest());
            PayPalHttpClient paypalHttpClient = Client(); //paypalSetup);
            HttpResponse response = await paypalHttpClient.Execute(request);
            return response;
        }

        public string GetPaymentValueUSD(double amount)
        {
            double usdAmount = amount / CHANGE_TYPE_CRC_USD;

            return usdAmount.ToString("#.00");
        }
    }
}
