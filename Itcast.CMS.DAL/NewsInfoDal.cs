using Itcast.CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Itcast.CMS.DAL
{
    public class NewsInfoDal
    {
        #region 獲取分頁數據 + List<NewsInfo> GetPageList(int start, int end)
        /// <summary>
        /// 獲取分頁數據
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public List<NewsInfo> GetPageList(int start, int end)
        {
            string strSQL = "select * from (select row_number() over (order by id) as num,* from T_News) as t where t.num>=@start and t.num<=@end";
            SqlParameter[] pars = 
            {
                new SqlParameter("@start", SqlDbType.Int),
                new SqlParameter("@end",SqlDbType.Int)
            };
            pars[0].Value = start;
            pars[1].Value = end;

            DataTable dt = SqlHelper.GetTable(strSQL, CommandType.Text, pars);
            List<NewsInfo> list = null;
            if (dt.Rows.Count > 0)
            {
                list = new List<NewsInfo>();
                NewsInfo newsInfo = null;
                foreach (DataRow dr in dt.Rows)
                {
                    newsInfo = new NewsInfo();
                    LoadEntity(dr, newsInfo);
                    list.Add(newsInfo);
                }
                
            }
            return list;
        }
        #endregion

        private void LoadEntity(DataRow dr, NewsInfo newsInfo)
        {
            newsInfo.Id = Convert.ToInt32(dr["Id"]);
            newsInfo.Title = dr["Title"] != DBNull.Value ? Convert.ToString(dr["Title"]) : string.Empty;
            newsInfo.Msg = dr["Msg"] != DBNull.Value ? Convert.ToString(dr["Msg"]) : string.Empty;
            newsInfo.Author = dr["Author"] != DBNull.Value ? Convert.ToString(dr["Author"]) : string.Empty;
            newsInfo.ImagePath = dr["ImagePath"] != DBNull.Value ? Convert.ToString(dr["ImagePath"]) : string.Empty;
            newsInfo.SubDateTime = Convert.ToDateTime(dr["SubDateTime"]);
        }

        #region 獲取單筆新聞詳細資料 + NewsInfo GetModel(int id)
        /// <summary>
        /// 獲取單筆新聞詳細資料
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public NewsInfo GetModel(int id)
        {
            string strSQL = "select * from T_News where id=@id";
            SqlParameter[] pars = { 
                                      new SqlParameter("@id",SqlDbType.Int) 
                                  };
            pars[0].Value = id;

            DataTable dt = SqlHelper.GetTable(strSQL, CommandType.Text, pars);
            NewsInfo newsInfo = null;
            if (dt.Rows.Count > 0)
            {
                newsInfo = new NewsInfo();
                LoadEntity(dt.Rows[0], newsInfo);
            }
            return newsInfo;
        }
        #endregion

        #region 刪除一筆資料 + int DeleteNewsInfo(int id)
        /// <summary>
        /// 刪除一筆資料
        /// </summary>
        /// <param name="id">編號</param>
        /// <returns></returns>
        public int DeleteNewsInfo(int id)
        {
            string strSQL = "delete from T_News where id=@id";
            return SqlHelper.ExecuteNonQuery(strSQL, CommandType.Text, new SqlParameter("@id", id));
        }
        #endregion

        #region 獲取總記錄數 + int GetRecordCount()
        /// <summary>
        /// 獲取總記錄數
        /// </summary>
        /// <returns></returns>
        public int GetRecordCount()
        {
            string strSQL = "select count(*) from T_News";
            return Convert.ToInt32(SqlHelper.ExecuteScalar(strSQL, CommandType.Text));
        }
        #endregion
    }
}
