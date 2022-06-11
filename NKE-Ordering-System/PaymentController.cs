using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKE_Ordering_System
{
    class PaymentController
    {
        NKEOrderDataContext db = new NKEOrderDataContext();
        public int Payment_ID { get; set; }
        public decimal Payment_Amount { get; set; }
        public int Payment_Type { get; set; }
        public int Payment_Status { get; set; }
        public int Order_ID { get; set; }

        public void Store()
        {
            Payment payment = new Payment();
            payment.PaymentID = Payment_ID;
            payment.PaymentAmount = Payment_Amount;
            payment.PaymentType = Payment_Type;
            payment.PaymentStatus = Payment_Status;
            payment.OrderID = Order_ID;

            db.Payments.InsertOnSubmit(payment);

            db.SubmitChanges();
        }
        public int generateID()
        {
            var SearchAny = db.Payments.Count();
            if (SearchAny != 0)
            {
                var MaxID = db.Payments.Max(i => i.PaymentID);
                int newId = MaxID;
                return ++newId;
            }
            else
            {
                int newId = 1000;
                return newId;
            }
        }
    }
}
