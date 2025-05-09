using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSqliteLibs.Exceptions
{
    public class BadRequestException : ServiceException
    {
        public BadRequestException(string message) : base(message, 400)
        { }
    }
}
