using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Itcast.CMS.DAL
{
    public class UserInfoDal
    {
        public UserInfo GetUserInfo(string userName, string userPwd)
        {
            string sql = "select * from T_UserInfo where UserName=@userName and UserPwd=@userPwd";
            SqlParameter[] pars = {
                new SqlParameter("@userName", SqlDbType.NVarChar,32),
                new SqlParameter("@userPwd",SqlDbType.NVarChar,32)
            };
            pars[0].Value = userName;
            pars[1].Value = userPwd;
            DataTable da = SqlHelper.GetTable(sql, CommandType.Text, pars);
            UserInfo userInfo = null;
            if (da.Rows.Count > 0)
            {
                userInfo = new UserInfo();
                LoadEntity(userInfo, da.Rows[0]);
            }
            return userInfo;
        }

        private void LoadEntity(UserInfo userInfo, DataRow row)
        {
            userInfo.Id = Convert.ToInt32(row["id"]);
            userInfo.UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : string.Empty;
            userInfo.UserPwd = row["UserPwd"] != DBNull.Value ? row["UserPwd"].ToString() : string.Empty;
            userInfo.UserMail = row["UserMail"] != DBNull.Value ? row["UserMail"].ToString() : string.Empty;
            userInfo.RegTime = Convert.ToDateTime(row["RegTime"]);
        }

    }
}
