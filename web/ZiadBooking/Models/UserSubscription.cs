using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ZiadBooking.Models
{
    public class GenericModel
    {
        public Dictionary<string, object> values = new Dictionary<string, object>();

        public void CreateFromReader(IDataReader reader)
        {
            int count = reader.FieldCount;
            for (int a = 0; a < count; a++)
            {
                string name = reader.GetName(a);
                values.Add(name, reader[name]);
            }
        }
    }

    public class UserSubscription
    {
        public string Id, UserId, ServiceId,PackageId, StartTs, NumMonths, AmountPaid,Details,ServiceName,StartDate,ExpiredAt,Discount;
    }

    public class UserPayment
    {
        public string Id, UserId, ServiceId,PackageId, AmountPaid, PaymentTs, PaymentDetails,ServiceName,PaymentDate,Discount;
    }

    public class BookingService
    {
        public string Id, Name;
    }

    public class BookingPackage
    {
        public string Id, Name, ServiceId,NumMonths,Amount;
    }

    public class PackageService
    {
        public string PackageId, ServiceId;
    }

    public class SubscriptionRequest
    {
        public string Id, UserName, PackageName,RequestDt;
    }
}
