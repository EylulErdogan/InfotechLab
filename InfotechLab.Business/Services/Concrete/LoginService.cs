using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Business.Helpers;
using InfotechLab.Business.Models;
using InfotechLab.Business.Services.Abstract;
using InfotechLab.Data.Abstract;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Http;

namespace InfotechLab.Business.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private IUserDal _userDal;
        private ICookieHelper _cookieHelper;
        private IUserService _userService;

        public LoginService(IUserDal userDal, ICookieHelper cookieHelper, IUserService userService)
        {
            _userDal = userDal;
            _cookieHelper = cookieHelper;
            _userService = userService;
        }

        public User Login(string email, string password)
        {
            var output = _userDal.Get(x => x.Email == email && x.Password == password);
            if (output == null)
            {
                return null;
            }
            else
            {
                return output;
            }
        }
        public User UserLogin(string email, string password, HttpResponse httpResponse)
        {
            password = StringHelper.ToMd5(password).ToLower();
            var loginResult = Login(email, password);

            if (loginResult is not null)
            {
                var key = _userDal.ChangeGuidKey(loginResult);
                _cookieHelper.Create(CookieTypes.User, key, DateTime.Now.AddYears(1), httpResponse);
            }
            return loginResult;
        }
        public User Register(User user, HttpResponse httpResponse)
        {
            user.Password = StringHelper.ToMd5(user.Password).ToLower();
            var userResult = _userDal.Register(user);
            if (userResult is not null)
            {
                var loginResult = Login(user.Email, user.Password);
                if (loginResult is not null)
                {
                    var key = _userDal.ChangeGuidKey(loginResult);
                    _cookieHelper.Create(CookieTypes.User, key, DateTime.Now.AddYears(1), httpResponse);
                }
                return loginResult;
            }

            return null;
        }

		public bool Exit(HttpRequest httpRequest)
		{
			try
			{
				var cookie = _cookieHelper.Read(CookieTypes.User, httpRequest);
				if (cookie == null)
				{
					return false;
				}
				_userService.ResetUserGuidKey(cookie);
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}
	}
}
