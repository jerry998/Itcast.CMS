using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Itcast.CMS.DAL;
using Itcast.CMS.Model;

namespace Itcast.CMS.BLL
{
    public class NewsInfoService
    {
        NewsInfoDal newsInfoDal = new NewsInfoDal();

        #region 獲取分頁數據 + List<NewsInfo> GetPageList(int pageIndex, int pageSize)
        /// <summary>
        /// 獲取分頁數據
        /// </summary>
        /// <param name="pageIndex">當前頁碼值</param>
        /// <param name="pageSize">每頁顯示的記錄數</param>
        /// <returns></returns>
        public List<NewsInfo> GetPageList(int pageIndex, int pageSize)
        {
            int start = (pageIndex - 1) * pageSize + 1;
            int end = pageIndex * pageSize;
            return newsInfoDal.GetPageList(start, end);
        }
        #endregion

        #region 獲取單筆新聞詳細資料 + NewsInfo GetModel(int id)
        /// <summary>
        /// 獲取單筆新聞詳細資料
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public NewsInfo GetModel(int id)
        {
            return newsInfoDal.GetModel(id);
        }
        #endregion

        #region 刪除一筆資料 + bool DeleteNewsInfo(int id)
        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public bool DeleteNewsInfo(int id)
        {
            return (newsInfoDal.DeleteNewsInfo(id) > 0);
        }
        #endregion

        #region 獲取總頁數 + int GetPageCount(int pageSize)
        /// <summary>
        /// 獲取總頁數
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public int GetPageCount(int pageSize)
        {
            int recordCount = newsInfoDal.GetRecordCount();
            return Convert.ToInt32(Math.Ceiling((double)recordCount / pageSize));
        }
        #endregion
    }
}
