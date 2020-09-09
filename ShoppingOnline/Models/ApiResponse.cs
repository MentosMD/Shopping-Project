using System.Net;
using Microsoft.AspNetCore.Http;

namespace ShoppingOnline.Models
{
    public class ApiResponse<T>
    {
        public int StatusCode { get; set; }
        public T Result { get; set; }
    }
}