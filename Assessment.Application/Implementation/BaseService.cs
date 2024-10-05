using Assessment.Application.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Assessment.Application.Implementation
{
    public class BaseService
    {
        public readonly int SignedInCustomerId;
        public readonly string SignedInCustomerEmail;
        public readonly string SignedInCustomerName;
        public readonly IMapper _mapper;
        public readonly AppSettings _appSettings;
        public readonly IHttpContextAccessor _contextAccessor;
        public BaseService(IHttpContextAccessor httpContextAccessor, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            if (httpContextAccessor?.HttpContext?.Request?.Headers["Authorization"].Any() == true)
            {
                SignedInCustomerName = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "FullName")?.Value;
                SignedInCustomerEmail = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Email")?.Value;
                SignedInCustomerId = Convert.ToInt32(httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value);
            }

            _contextAccessor = httpContextAccessor;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }
    }
}
