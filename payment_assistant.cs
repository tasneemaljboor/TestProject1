using Bytescout.Spreadsheet;
using HerfaTest_Batch_6.Data;
using HerfaTest_Batch_6.Helpers;
using Oracle.ManagedDataAccess.Client;
using System;
using TestProject1.POM;

namespace HerfaTest_Batch_6.AssistantMethods
{
    public class Payment_AssistantMethods
    {
        public static void FillPaymentForm(PaymentDetails payment)
        {
            Payment_POM payment_POM = new Payment_POM(ManageDriver.driver);
            payment_POM.EnterCardholdersName(payment.CardholdersName);
            payment_POM.EnterCardNumber(payment.CardNumber);
            payment_POM.EnterExpiryDate(payment.ExpiryDate);
            payment_POM.EnterCVV(payment.CVV);
            payment_POM.ClickPayButton();
        }

        public static PaymentDetails ReadPaymentDataFromExcel(int row)
        {
            Worksheet paymentWorkSheet = CommonMethods.ReadExcel("Payment");

            PaymentDetails payment = new PaymentDetails();
            payment.CardholdersName = Convert.ToString(paymentWorkSheet.Cell(row, 2).Value);
            payment.CardNumber = Convert.ToString(paymentWorkSheet.Cell(row, 3).Value);
            payment.ExpiryDate = Convert.ToString(paymentWorkSheet.Cell(row, 4).Value);
            payment.CVV = Convert.ToString(paymentWorkSheet.Cell(row, 5).Value);
            return payment;
        }

        public static bool CheckPaymentSuccess(string transactionId)
        {
            OracleConnection oracleConnection = new OracleConnection(GlobalConstant.ConnectionString);
            oracleConnection.Open();

            string query = "SELECT COUNT(*) FROM transactions WHERE transaction_id = :value";
            OracleCommand command = new OracleCommand(query, oracleConnection);
            command.Parameters.Add(new OracleParameter(":value", transactionId));
            int result = Convert.ToInt32(command.ExecuteScalar());
            bool isTransactionSuccessful = result > 0;
            return isTransactionSuccessful;
        }
    }
}
