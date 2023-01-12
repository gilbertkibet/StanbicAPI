using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StanbicAPI.Models
{
    public class KcbBankBillNotification
    {
        public Guid Id { get; set; }

        public string TransactionReference { get; set; }

        public string RequestId { get; set; }

        public string ChannelCode { get; set; }

        public string Timestamp { get; set; }

        public string TransactionAmount { get; set; }

        public string Currency { get; set; }

        public string CustomerReference { get; set; }

        public string CustomerName { get; set; }

        public string CustomerMobileNumber { get; set; }

        public string Balance { get; set; }

        public string Narration { get; set; }

        public string CreditAccountIdentifier { get; set; }

        public string OrganizationShortCode { get; set; }

        public string TillNumber { get; set; }
    }
}
