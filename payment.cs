using System;

namespace HerfaTest_Batch_6.Data
{
    public class Payment
    {
        public Payment(string cardholdersName = "", string cardNumber = "", string expiryDate = "", string cvv = "", decimal amount = 0)
        {
            CardholdersName = cardholdersName;
            CardNumber = cardNumber;
            ExpiryDate = expiryDate;
            CVV = cvv;
            Amount = amount;
        }

        public string CardholdersName { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string CVV { get; set; }
        public decimal Amount { get; set; }
    }
}

