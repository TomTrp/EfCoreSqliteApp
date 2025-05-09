using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSqliteLibs.Exceptions
{
    public class ServiceException : Exception
    {
        public int StatusCode { get; }

        public ServiceException(string message, int statusCode = 500) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
