using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace StanbicAPI.Controllers
{

    [ApiController]

    [Route("api/[controller]")]

    public class TransactionNotificationController : ControllerBase
    {

        [HttpPost]
        public string TransactionRequest(XElement transactionRequestObject)
        {
            String requestURI = "https://api.connect.stanbicbank.co.ke/api/sandbox";

            var client = new RestClient(requestURI);

            RestRequest request = null;

            XElement api_key = new XElement("ApiKey", "content");

            var key = transactionRequestObject.Element(api_key.Name).Value;

            request = new RestRequest("/transaction-notification-api", Method.Post);
            request.AddHeader("X-IBM-Client-Id", key);
            request.AddHeader("content-type", "application/xml");
            request.AddHeader("accept", "application/xml");
            request.AddXmlBody(transactionRequestObject);
            request.RequestFormat = DataFormat.Xml;
            RestResponse response = null;
            try
            {
             response = client.Execute(request);

            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Application Return the Response");

            }
      
            return response.Content;
        }
    }
}
