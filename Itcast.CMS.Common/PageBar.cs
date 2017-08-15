using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Itcast.CMS.Common
{
    public class PageBar
    {
        /// <summary>
        /// 產生數字頁碼條
        /// </summary>
        /// <param name="pageIndex">當前頁碼</param>
        /// <param name="pageCount">總頁數</param>
        /// <returns></returns>
        public static string GetPageBar(int pageIndex, int pageCount)
        {
            if (pageCount == 1)
            {
                return string.Empty;
            }
            int start = pageIndex - 5;  //起始頁碼, P.S:頁面只顯示10個數字頁碼
            if (start < 1)
            {
                start = 1;
            }
            int end = start + 9;    //結束頁碼
            if (end > pageCount)
            {
                end = pageCount;
            }
            StringBuilder sb = new StringBuilder();
            if (pageIndex > 1)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}'>第一頁</a>", 1));
                sb.Append(string.Format("<a href='?pageIndex={0}'>上一頁</a>", pageIndex - 1));
            }
            for (int i = start; i <= end; i++)
            {
                if (i == pageIndex)
                {
                    sb.Append(i);
                }
                else
                {
                    sb.Append(string.Format("<a href='?pageIndex={0}'>{0}</a>", i));
                }
            }
            if (pageIndex < pageCount)
            {
                sb.Append(string.Format("<a href='?pageIndex={0}'>下一頁</a>", pageIndex + 1));
                sb.Append(string.Format("<a href='?pageIndex={0}'>最後頁</a>", pageCount));
            }
            return sb.ToString();
        }
    }
}
