using Itcast.CMS.BLL;
using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Itcast.CMS.WebApp.Controllers
{
    public class AdminNewListController : Controller
    {
        NewsInfoService newsInfoService = new NewsInfoService();

        #region 獲取分頁列表
        /// <summary>
        /// 獲取分頁列表
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            int pageIndex = Request["pageIndex"] != null ? int.Parse(Request["pageIndex"]) : 1;
            int pageSize = 5;
            int pageCount = newsInfoService.GetPageCount(pageSize);
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageIndex = pageIndex > pageCount ? pageCount : pageIndex;

            List<NewsInfo> list = new List<NewsInfo>();
            list = newsInfoService.GetPageList(pageIndex, pageSize);
            ViewData["list"] = list;
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageCount"] = pageCount;
            return View();
        }
        #endregion

        #region 獲取詳細資料
        /// <summary>
        /// 獲取詳細資料
        /// </summary>
        /// <returns></returns>
        public ActionResult GetNewsInfoModel()
        {
            int id = int.Parse(Request["ids"]);
            NewsInfo newsInfo = newsInfoService.GetModel(id);

            return Json(newsInfo, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region 刪除一筆資料
        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <returns></returns>
        public ActionResult DeleteNewsInfo()
        {
            int id = int.Parse(Request["id"]);
            if (newsInfoService.DeleteNewsInfo(id))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion

    }
}
