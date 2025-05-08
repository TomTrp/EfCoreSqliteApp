using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSqliteLibs.Models
{
    public class ResponseModel<T>
    {
        public bool IsComplete { get; set; } = false;
        public string StatusCode { get; set; } = string.Empty;
        public T? DataResult { get; set; }
    }
}
