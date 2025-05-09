using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreSqliteLibs.Models
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; } = true;
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? TaceId { get; set; }
        public T? DataResult { get; set; }
    }
}
