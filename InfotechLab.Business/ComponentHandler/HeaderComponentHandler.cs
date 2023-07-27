using InfotechLab.Business.Helpers;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfotechLab.Business.ComponentHandler
{
	public class HeaderComponentHandler : IHeaderComponentHandler
	{
		private readonly ICookieHelper _cookieHelper;
		private readonly IUserService _userService;

		public HeaderComponentHandler(ICookieHelper cookieHelper, IUserService userService)
		{
			_cookieHelper = cookieHelper;
			_userService = userService;
		}
	}

	public interface IHeaderComponentHandler
	{
	}
}
