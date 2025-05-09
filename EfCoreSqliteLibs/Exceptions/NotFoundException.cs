using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSqliteLibs.Exceptions
{
    public class NotFoundException : ServiceException
    {
        public NotFoundException(string message) : base(message, 404)
        { }
    }
}
