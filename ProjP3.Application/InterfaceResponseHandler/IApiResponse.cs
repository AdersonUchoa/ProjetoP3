using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.InterfaceResponseHandler
{
    public interface IApiResponse<T>
    {
        bool Success { get; set; }
        HttpStatusCode StatusCode { get; set; }
        T Data { get; set; }
        string Message { get; set; }
        string MoreDetails { get; set; }
    }
}
