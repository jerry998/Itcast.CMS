using Itcast.CMS.BLL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        UserInfoService userInfoService = new UserInfoService();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserLogin()
        {
            string validateCode = Session["code"] == null ? string.Empty : Session["code"].ToString();
            if (string.IsNullOrEmpty(validateCode))
            {
                return Content("no:驗證碼錯誤！");
            }
            Session["code"] = null;
            string txtCode = Request["vCode"];
            if (!validateCode.Equals(txtCode, StringComparison.InvariantCultureIgnoreCase))
            {
                return Content("no:驗證碼錯誤！");
            }
            string userName = Request["LoginCode"];
            string userPwd = Request["LoginPwd"];
            UserInfo userInfo = userInfoService.GetUserInfo(userName, userPwd);
            if (userInfo != null)
            {
                Session["UserInfo"] = userInfo;
                return Content("ok:登錄成功！");
            }
            else
            {
                return Content("no:登錄失敗！");
            }
        }

        #region 圖形驗證碼
        /// <summary>
        /// 圖形驗證碼
        /// </summary>
        /// <returns></returns>
        public ActionResult ShowValidateCode()
        {
            Common.ValidateCode validateCode = new Common.ValidateCode();
            string code = validateCode.CreateValidateCode(4);   //獲取驗證碼
            Session["code"] = code;
            byte[] buffer = validateCode.CreateValidateGraphic(code);   //驗證碼轉成圖片
            return File(buffer, "image/jpeg");
        }
        #endregion
    }
}
