using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StanbicAPI.ApiDbContext;
using StanbicAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StanbicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BankNotificationController : ControllerBase
    {
        private readonly NotificationDbContext _notificationDbContext;
        private readonly ILogger<BankNotificationController> logger;

        //private readonly ILogger<BankNotificationController> logger;

        public BankNotificationController(NotificationDbContext notificationDbContext, ILogger<BankNotificationController> logger)
        {
            _notificationDbContext = notificationDbContext;
            this.logger = logger;
        }

        [HttpPost]

        public async Task<IActionResult> ReceiveNotification([FromBody] IncomingNotification incomingNotification)
        {
            if (incomingNotification == null)
            {
                return BadRequest();
            }

            try
            {

                var dataTosend = new BankNotification
                {
                    Id = Guid.NewGuid(),
                    BusinessAccountNo = incomingNotification.BusinessAccountNo,
                    InvoiceNumber = incomingNotification.InvoiceNumber,
                    AvailableAccountBalance = incomingNotification.AvailableAccountBalance,
                    ValidateEndPoint = incomingNotification.ValidateEndPoint,
                    BusinessShortCode = incomingNotification.BusinessShortCode,
                    PaymentDetails = incomingNotification.PaymentDetails,
                    TransId = incomingNotification.TransId,
                    ThirdPartyTransId = incomingNotification.ThirdPartyTransId,
                    CallbackUrl = incomingNotification.CallbackUrl,
                    TransactionType = incomingNotification.TransactionType,
                    Msisdn = incomingNotification.Msisdn,
                    OrgAccountBalance = incomingNotification.OrgAccountBalance,
                    TransAmount = incomingNotification.TransAmount,
                    TransTime = incomingNotification.TransTime,
                    ApiKey = incomingNotification.ApiKey,
                    BillRefNumber = incomingNotification.BillRefNumber
                };

                await _notificationDbContext.BankNotifications.AddAsync(dataTosend);

                await _notificationDbContext.SaveChangesAsync();

                return Ok(incomingNotification);
            }

            catch (Exception ex)
            {

                logger.LogError(JsonConvert.SerializeObject(ex));

                return StatusCode(500);
            }

          
        }
    }

    public class IncomingNotification
    {
        [JsonProperty("BusinessAccountNo")]
        public string BusinessAccountNo { get; set; }

        [JsonProperty("InvoiceNumber")]
        public string InvoiceNumber { get; set; }

        [JsonProperty("AvailableAccountBalance")]
        public string AvailableAccountBalance { get; set; }

        [JsonProperty("ValidateEndPoint")]
        public string ValidateEndPoint { get; set; }

        [JsonProperty("BusinessShortCode")]
        public string BusinessShortCode { get; set; }

        [JsonProperty("PaymentDetails")]
        public string PaymentDetails { get; set; }

        [JsonProperty("TransID")]
        public string TransId { get; set; }

        [JsonProperty("ThirdPartyTransID")]
        public string ThirdPartyTransId { get; set; }

        [JsonProperty("CallbackUrl")]
        public string CallbackUrl { get; set; }

        [JsonProperty("TransactionType")]
        public string TransactionType { get; set; }

        [JsonProperty("MSISDN")]
        public string Msisdn { get; set; }

        [JsonProperty("OrgAccountBalance")]
        public string OrgAccountBalance { get; set; }

        [JsonProperty("TransAmount")]
        public string TransAmount { get; set; }

        [JsonProperty("TransTime")]
        public string TransTime { get; set; }

        [JsonProperty("ApiKey")]
        public string ApiKey { get; set; }

        [JsonProperty("BillRefNumber")]
        public string BillRefNumber { get; set; }
    }
}
