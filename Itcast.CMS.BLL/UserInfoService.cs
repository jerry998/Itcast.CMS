using Itcast.CMS.DAL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itcast.CMS.BLL
{
    public class UserInfoService
    {
        UserInfoDal userInfoDal = new UserInfoDal();
        public UserInfo GetUserInfo(string userName, string userPwd)
        {
            return userInfoDal.GetUserInfo(userName, userPwd);
        }
    }
}
