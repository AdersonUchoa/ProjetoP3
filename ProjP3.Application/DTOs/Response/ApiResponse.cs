using ProjP3.Application.InterfaceResponseHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjP3.Application.DTOs.Response
{
    public class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(bool Success, HttpStatusCode StatusCode, T Data, string Message, string MoreDetails)
        {
            this.Success = Success;
            this.StatusCode = StatusCode;
            this.Data = Data;
            this.Message = Message;
            this.MoreDetails = MoreDetails;
        }

        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public string MoreDetails { get; set; }
    }
}
