using System;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class BookingDbcontext
    {
        public object BookingType { get;  set; }

        internal Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}