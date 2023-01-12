using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StanbicAPI.Models
{
    public class BankNotification
    {
        public Guid Id { get; set; } 

        public string BusinessAccountNo { get; set; }

        public string InvoiceNumber { get; set; }

        public string AvailableAccountBalance { get; set; }

        public string ValidateEndPoint { get; set; }

        public string BusinessShortCode { get; set; }

        public string PaymentDetails { get; set; }

        public string TransId { get; set; }

        public string ThirdPartyTransId { get; set; }

        public string CallbackUrl { get; set; }

        public string TransactionType { get; set; }

        public string Msisdn { get; set; }

        public string OrgAccountBalance { get; set; }

        public string TransAmount { get; set; }

        public string TransTime { get; set; }

        public string ApiKey { get; set; }

        public string BillRefNumber { get; set; }
    }
}
