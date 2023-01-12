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

        public BankNotificationController(NotificationDbContext notificationDbContext, ILogger<BankNotificationController> logger)
        {
            _notificationDbContext = notificationDbContext;
            this.logger = logger;
        }

        [HttpPost("stanbic-notification")]
        
        public async Task<IActionResult> StandbicTransactionNotification([FromBody] StanbicIncomingNotification incomingNotification)
        {
            if (incomingNotification == null)
            {
                return BadRequest();
            }

            try
            {

                var dataTosend = new StanbicBankNotification
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

                await _notificationDbContext.StanbicBankNotifications.AddAsync(dataTosend);

                await _notificationDbContext.SaveChangesAsync();

                return Ok(incomingNotification);
            }

            catch (Exception ex)
            {

                logger.LogError(JsonConvert.SerializeObject(ex));

                return StatusCode(500);
            }


        }

        [HttpPost("kcb-notification")]

        public async Task<IActionResult> KcbBillNotification([FromBody] KcbIncomingBillNotification kcbBankBillNotification) {

            if (kcbBankBillNotification == null)
            {
                return BadRequest();
            }
            try
            {

                var dataToSend = new KcbBankBillNotification {

                    Id = Guid.NewGuid(),
                    TransactionReference = kcbBankBillNotification.TransactionReference,
                    RequestId = kcbBankBillNotification.RequestId,
                    ChannelCode = kcbBankBillNotification.ChannelCode,
                    Timestamp = kcbBankBillNotification.Timestamp,
                    TransactionAmount = kcbBankBillNotification.TransactionAmount,
                    Currency = kcbBankBillNotification.Currency,
                    CustomerReference = kcbBankBillNotification.CustomerReference,
                    CustomerName = kcbBankBillNotification.CustomerName,
                    CustomerMobileNumber = kcbBankBillNotification.CustomerMobileNumber,
                    Balance = kcbBankBillNotification.Balance,
                    Narration = kcbBankBillNotification.Narration,
                    CreditAccountIdentifier = kcbBankBillNotification.CreditAccountIdentifier,
                    OrganizationShortCode = kcbBankBillNotification.OrganizationShortCode,
                    TillNumber = kcbBankBillNotification.TillNumber

                };

                await _notificationDbContext.KcbBillNotifications.AddAsync(dataToSend);

                await _notificationDbContext.SaveChangesAsync();

                KcbResponseMessage responseMessage = new KcbResponseMessage
                {
                    TransactionId = dataToSend.TransactionReference,
                    StatusCode="",
                    StatusMessage="Notification Received"
                };

                return Ok(responseMessage);

            }
            catch (Exception ex)
            {
                logger.LogError(JsonConvert.SerializeObject(ex));
                return StatusCode(500);
                
            }

        }

        public class StanbicIncomingNotification
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

        public class KcbIncomingBillNotification
        {
            [JsonProperty("transactionReference")]
            public string TransactionReference { get; set; }

            [JsonProperty("requestId")]
            public string RequestId { get; set; }

            [JsonProperty("channelCode")]
            public string ChannelCode { get; set; }

            [JsonProperty("timestamp")]
            public string Timestamp { get; set; }

            [JsonProperty("transactionAmount")]
            public string TransactionAmount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("customerReference")]
            public string CustomerReference { get; set; }

            [JsonProperty("customerName")]
            public string CustomerName { get; set; }

            [JsonProperty("customerMobileNumber")]
            public string CustomerMobileNumber { get; set; }

            [JsonProperty("balance")]
            public string Balance { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("creditAccountIdentifier")]
            public string CreditAccountIdentifier { get; set; }

            [JsonProperty("organizationShortCode")]
            public string OrganizationShortCode { get; set; }

            [JsonProperty("tillNumber")]
            public string TillNumber { get; set; }
        }

        public class KcbResponseMessage
        {
            [JsonProperty("transactionID")]
            public string TransactionId { get; set; }

            [JsonProperty("statusCode")]
            public string StatusCode { get; set; }

            [JsonProperty("statusMessage")]
            public string StatusMessage { get; set; }
        }
    }
}