using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Wesalt.Basis.Tools
{
    ///2015-08-31
    /// 覃之祺
    /// <summary>
    /// 短信工具类
    /// </summary>
    public static class SmsHelper
    {
        private static string htmlstr;
        private static string[] array;
        private static string[] array2;
        private static string errcod = "";

        /// <summary>
        /// 作者：李修妙
        /// 功能：短信发送api
        /// 日期2015-03-23
        /// </summary>
        /// <param name="phoneno">手机号码</param>
        /// <param name="tpl_id">短信模板id</param>
        /// <param name="tpl_value"></param>
        /// <returns></returns>
        public static string msg_api(string phoneno, string tpl_id, string tpl_value)
        {
            try
            {
                string appkey = "39ad3be65b347a988a02472413db2d28";//申请短信接口key
                string url = "http://v.juhe.cn/sms/send?mobile=" + phoneno + "&tpl_id=" + tpl_id + "& tpl_value=" + tpl_value + "&key=" + appkey + "";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/xml";
                Stream reqstream = request.GetRequestStream();
                request.Timeout = 90000;
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.UTF8;

                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                string strResult = streamReader.ReadToEnd();
                htmlstr = strResult;
                streamReceive.Dispose();
                streamReader.Dispose();

                htmlstr = htmlstr.Replace("\"", "");
                htmlstr = htmlstr.Replace("{", "");
                htmlstr = htmlstr.Replace("}", "");
                if (htmlstr.IndexOf(",") >= 0)
                {
                    array = htmlstr.Split(',');
                    for (int i = 0; i < array.Length; i++)
                    {
                        if (array[i].IndexOf(":") >= 2)
                        {
                            array2 = array[i].Split(':');
                            if (array2[0] == "error_code")
                            {
                                errcod = array2[1];
                            }
                        }
                    }
                }
                return errcod;
            }
            catch (Exception e)
            {
                return errcod = "404";
            }
        }
    }
}
