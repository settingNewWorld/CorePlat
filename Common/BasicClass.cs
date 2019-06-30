using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public class BasicClass
    {
        /// <summary>
        /// 转换首字母大写
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public string ConvertInitials(string data)
        {
            string str = "";
            if (!string.IsNullOrEmpty(data))
            {
                str=CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data.ToLower());
            }
            return str;
        }

        /// <summary>
        /// 去文本空格及特殊字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string GoToSpace(string str)
        {
            string mStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                mStr = Regex.Replace(str, @"\s", "");
                //mStr = mStr.Replace("-", "").Replace("\'", "").Replace(".", "").Replace("/", "").Replace("、", "");
            }
            return mStr;


        }
        public string GoToRemoveChar(string str)
        {
            string mStr = "";
            if (!string.IsNullOrEmpty(str))
            {
                mStr = str.Replace("-", "").Replace("\'", "").Replace(".", "").Replace("/", "").Replace("、", "").Replace(",", "").Replace("：","");
            }
            return mStr;


        }

        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public string HttpPost(string Url, string postDataStr)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";//请求方约定好

                byte[] bs = Encoding.UTF8.GetBytes(postDataStr);
                request.ContentLength = bs.Length;
                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }

                HttpWebResponse response;
                response = (HttpWebResponse)request.GetResponse();

                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));//一般参数带中文 用utf-8
                string retString = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();

                return retString;
            }
            catch (Exception ex)
            {
                //LogHelper.WriteLog(ex.Message, "");
            }
            return null;
        }

        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="strUrl"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public string Get_Http(string strUrl, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(strUrl);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.UTF8);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }

            return strResult;
        }









    }
}
