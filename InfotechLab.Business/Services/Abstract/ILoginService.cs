using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfotechLab.Entities;
using Microsoft.AspNetCore.Http;

namespace InfotechLab.Business.Services.Abstract
{
    public interface ILoginService 
	{
        public User UserLogin(string email, string password, HttpResponse httpResponse);
        public User Register(User user, HttpResponse httpResponse);
        public bool Exit(HttpRequest httpRequest);
	}
}
