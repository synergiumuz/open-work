using System;

using Microsoft.AspNetCore.Http;

using OpenWork.Services.Interfaces.Common;

namespace OpenWork.Services.Services.Common
{
	public class IdentityService : IIdentityService
	{
		private readonly IHttpContextAccessor _accessor;

		public IdentityService(IHttpContextAccessor accessor)
		{
			_accessor = accessor;
		}
		public long Id
		{
			get
			{
				System.Security.Claims.Claim? result = _accessor.HttpContext.User.FindFirst("Id");
				return result is not null ? long.Parse(result.Value) : throw new Exception("Unauthorized");
			}
		}
		public string Email
		{
			get
			{
				System.Security.Claims.Claim? result = _accessor.HttpContext!.User.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
				return result is null ? string.Empty : result.Value;
			}
		}
	}
}