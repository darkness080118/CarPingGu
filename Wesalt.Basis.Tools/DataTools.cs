using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Wesalt.Basis.Tools
{
    ///2015-08-27
    /// 覃之祺
    /// <summary>
    /// 常用数据操作方法工具类
    /// </summary>
    public static class DataTools
    {
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name="timeStamp">Unix时间戳格式</param>
        /// <returns>C#格式时间</returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            dtStart = dtStart.Add(toNow);
            return dtStart;
        }

        /// <summary>
        /// 转换成万元保留两位小数点
        /// </summary>
        /// <returns></returns>
        public static string ChangeMoney(double money)
        {
            double temp = Math.Round(money / 10000, 2);
            return temp.ToString();
        }

        public static string ChangeDate(string va, int i)
        {
            switch (i)
            {
                case 1:
                    var year = Convert.ToDateTime(va).Year;
                    break;
                case 2:
                    var month = Convert.ToDateTime(va).Month;
                    break;
                case 3:
                    var day = Convert.ToDateTime(va).Day;
                    break;
                default:
                    break;
            }

            var temp = va;
            return temp;
        }

        /// <summary>
        /// 判断状态，显示进度条
        /// </summary>
        /// <param name="val">返回数据</param>
        /// <param name="no">对比数据</param>
        /// <returns></returns>
        public static string ReState(int val, int no)
        {
            string state1 = "focus";
            string state2 = "active";
            string state3 = "";
            if (val == no)
            {
                return state1;
            }
            else if (val > no)
            {
                return state2;
            }
            else
            {
                return state3;
            }
        }

        public static string ReStr(bool b1, bool b2, int n,int i)
        {
            if (n<=2 && b1)
            {
                if (n == i)
                {
                    return "点击";
                }
            }
            if (n>2 && b2)
            {
                if (n == i)
                {
                    return "点击";
                }
            }
            return "";
        }

        /// <summary>
        /// BytesToHexString For RSA
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string BytesToHexString(byte[] input)
        {
            StringBuilder hexString = new StringBuilder(64);

            for (int i = 0; i < input.Length; i++)
            {
                hexString.Append(String.Format("{0:X2}", input[i]));
            }
            return hexString.ToString();
        }

        /// <summary>
        /// HexStringToBytes For RSA
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>

        public static byte[] HexStringToBytes(string hex)
        {
            if (hex.Length == 0)
            {
                return new byte[] { 0 };
            }

            if (hex.Length % 2 == 1)
            {
                hex = "0" + hex;
            }

            byte[] result = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                result[i] = byte.Parse(hex.Substring(2 * i, 2), System.Globalization.NumberStyles.AllowHexSpecifier);
            }

            return result;
        }

        /// <summary>
        /// 计算日期差值
        /// </summary>
        /// <param name="data_start">开始日期</param>
        /// <param name="data_end">结束日期</param>
        /// <returns>相差日期</returns>
        public static string DateDiff(string data_start, string data_end)
        {
            string dateDiff_days = null;
            if (!string.IsNullOrEmpty(data_start) && !string.IsNullOrEmpty(data_end))
            {
                DateTime dataTime_Start = Convert.ToDateTime(data_start);
                DateTime dataTime_End = Convert.ToDateTime(data_end);
                TimeSpan timeSpan_Start = new TimeSpan(dataTime_Start.Ticks);
                TimeSpan timeSpan_End = new TimeSpan(dataTime_End.Ticks);
                TimeSpan diff = timeSpan_End.Subtract(timeSpan_Start);
                dateDiff_days = diff.Days.ToString();
            }
            return dateDiff_days;
        }

        public static int DateDiff_Int(string data_start, string data_end)
        {
            int dateDiff_days = 0;
            if (!string.IsNullOrEmpty(data_start) && !string.IsNullOrEmpty(data_end))
            {
                DateTime dataTime_Start = Convert.ToDateTime(data_start);
                DateTime dataTime_End = Convert.ToDateTime(data_end);
                TimeSpan timeSpan_Start = new TimeSpan(dataTime_Start.Ticks);
                TimeSpan timeSpan_End = new TimeSpan(dataTime_End.Ticks);
                TimeSpan diff = timeSpan_End.Subtract(timeSpan_Start);
                dateDiff_days = diff.Days;
            }
            return dateDiff_days;
        }

        /// <summary>
        /// 计算日期差值
        /// </summary>
        /// <param name="data_start">开始日期</param>
        /// <param name="data_end">结束日期</param>
        /// <returns>相差日期</returns>
        public static string DateDiff(DateTime data_start, DateTime data_end)
        {
            string dateDiff_days = null;
            TimeSpan timeSpan_Start = new TimeSpan(data_start.Ticks);
            TimeSpan timeSpan_End = new TimeSpan(data_end.Ticks);
            TimeSpan diff = timeSpan_End.Subtract(timeSpan_Start);
            dateDiff_days = diff.Days.ToString();

            return dateDiff_days;
        }

        /// <summary>
        /// 判断是否为图片
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static bool IsPic(string url)
        {
            string[] pic = new[] { "jpg", "png", "jpeg", "tif", "gif", "bmp" };
            var data = url.Trim().Split('.');
            var back = data[data.Length - 1];
            foreach (var i in pic)
            {
                if (i.Equals(back))
                {
                    return true;
                }
            }
            return false;
        }

        #region 判断日期是否是合法
        //使用方法
        //DklFuns df = new DklFuns();
        //df.IsDate("2012-1-1")
        /// <summary>
        /// 检查日期
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDate(string str)
        {
            DateTime dateValue;
            return DateTime.TryParse(str, out dateValue);
            //try
            //{
            //    Convert.ToDateTime(str);
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        #endregion

        #region 转换格式日期为（如：2012/02/30 2012.02.30）至：2012-02-30此种格式。
        //作者:刘俊研
        //日期:2013-3-6
        //功能:转换格式日期为（如：2012/02/30 2012.02.30）至：2012-02-30此种格式。
        //style为1时有时分秒，为0时仅日期
        public static string FormatDate(string indate, int style)
        {
            try
            {
                string redate = ""; //返回转换的日期
                DateTime dt = Convert.ToDateTime(indate);
                if (dt.Hour == 0 || style == 0)//判断传入日期参数是否有：时分秒
                    redate = (dt.ToString("yyyy-MM-dd"));//可自定义（如："yyyy年MM月dd日）
                else if (style == 1) { 
                    redate = (dt.ToString("yyyy-MM-dd HH:mm"));//可自定义（如："yyyy年MM月dd日 HH小时mm分ss秒"注意大小写）
                }else if (style == 2)
                {
                    redate = (dt.ToString("yyyy"));//可自定义（如："yyyy年MM月dd日 HH小时mm分ss秒"注意大小写）
                }
                return redate;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 转换格式日期为（如：2012/02/30 2012.02.30）至：2012-02-30此种格式。
        //作者:刘俊研
        //日期:2013-3-6
        //功能:转换格式日期为（如：2012/02/30 2012.02.30）至：2012-02-30此种格式。
        //style为1时有时分秒，为0时仅日期
        public static string FormatDate1(string indate, int style)
        {
            try
            {
                string redate = ""; //返回转换的日期
                DateTime dt = Convert.ToDateTime(indate);
                if (dt.Hour == 0 || style == 0)//判断传入日期参数是否有：时分秒
                    redate = (dt.ToString("yyyy-MM-dd"));//可自定义（如："yyyy年MM月dd日）
                else if (style == 1)
                    redate = (dt.ToString("yyyy-MM-dd HH:mm"));//可自定义（如："yyyy年MM月dd日 HH小时mm分ss秒"注意大小写）
                return redate;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        /// <summary>
        /// 保存图片
        /// </summary>
        /// <param name="strImg"></param>
        /// <returns></returns>
        public static string SaveImage(string strImg)
        {
            string fpath = System.Web.HttpContext.Current.Server.MapPath("/Upload/");
            //图片存储文件夹路径            
            string time = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            string picturename = time;   //文件名        

            String ExistsPath = fpath + "Images";

            if (!Directory.Exists(ExistsPath))//查看存储路径的文件是否存在    
            {
                Directory.CreateDirectory(ExistsPath);   //创建文件夹，并上传文件    
            }
            String newFilePath = fpath + "Images" + "/" + picturename; //文件保存路径  
            byte[] arr = Convert.FromBase64String(strImg);
            MemoryStream ms = new MemoryStream(arr);
            Bitmap bmp = new Bitmap(ms);

            bmp.Save(newFilePath + ".jpg",
            System.Drawing.Imaging.ImageFormat.Jpeg);   //保存为.jpg格式       
            ms.Close();
            return picturename + ".jpg";
        }

        public static string BackDateTime(string indate)
        {
            string reTime = CountDate(indate);
            reTime = reTime.Split(' ')[0];
            if (string.IsNullOrEmpty(reTime))
            {
                reTime = "未定";
            }
            return reTime;
        }

        #region 根据当前时间，返回几秒、几分钟前，相差2天以上返回日期（03-08），异年返回年份日期（12-03-08）。
        //作者:刘俊研
        //日期:2013-3-9
        //功能:根据当前时间，返回几秒、几分钟前，相差2天以上返回日期（03-08），异年返回年份日期（12-03-08）。
        public static string CountDate(string indate)
        {
            int second, day = 0;
            string retime = ""; //返回的时间
            if (IsDate(indate) == false)  //非合法日期
                return "";
            DateTime dt = Convert.ToDateTime(indate);
            indate = (dt.ToString("yyyy年MM月dd日 HH:mm:ss"));//格式化日期
            try               //防出错
            {
                DateTime dt1 = Convert.ToDateTime(indate);
                DateTime dt2 = Convert.ToDateTime(DateTime.Now.ToString());
                DateTime dt4 = Convert.ToDateTime(DateTime.Today.ToString());
                DateTime dt3 = Convert.ToDateTime(indate.Substring(0, 10));//只取日期
                TimeSpan ts = dt2 - dt1;
                TimeSpan td = dt4 - dt3;//注意：输出字符样式为：0.00:00:00
                second = int.Parse(ts.TotalSeconds.ToString());
                if (td.ToString().IndexOf(".") > 0)//判断是否取到 "."
                {
                    day = int.Parse(td.ToString().Substring(0, td.ToString().IndexOf(".")));
                    if (day > 1 && dt4.Year == dt3.Year)
                    {
                        retime = indate.Substring(5, 11);   //两天前
                    }
                    else if (day < -1 && dt4.Year == dt3.Year)
                    {
                        retime = indate.Substring(5, 11);
                    }
                    else
                    {
                        retime = indate.Substring(0, 16);
                    }
                }
                else
                {
                    retime = "今天 " + indate.Substring(indate.IndexOf(" ") + 1, 5);
                }
                if (second < 60 && second > 0)
                {
                    retime = second.ToString("0") + "秒前";
                }
                else if (second > -60 && second < 0)
                {
                    retime = (second * -1).ToString("0") + "秒后";
                }
                else if (second >= 60 && second < 60 * 60)
                {
                    retime = (second / 60).ToString("0") + "分钟前";
                }
                else if (second <= -60 && second > -60 * 60)
                {
                    retime = (second / -60).ToString("0") + "分钟后";
                }
                else if (day == 1)
                {
                    retime = "昨天 " + indate.Substring(indate.LastIndexOf(" ") + 1, 5);
                }
                else if (day == -1)
                {
                    retime = "明天 " + indate.Substring(indate.LastIndexOf(" ") + 1, 5);
                }
            }
            catch
            {
                return indate.Substring(0, 16);
            };
            return retime;
        }
        #endregion

        #region 生成N位随机数
        public static string RndNum(int VcodeNum) //生成N位随机数
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9";
            string[] VcArray = Vchar.Split(',');
            string VNum = "";//由于字符串很短，就不用StringBuilder了 
            int temp = -1;//记录上次随机数值，尽量避免生产几个一样的随机数 
            //采用一个简单的算法以保证生成随机数的不同 
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1) { rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks)); }
                //int t = rand.Next(35) ; 
                int t = rand.Next(9);
                if (temp != -1 && temp == t) { return RndNum(VcodeNum); }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
        #endregion

        #region 生成N位随机数,有字母
        public static string RndNum2(int VcodeNum) //生成N位随机数,有字母
        {
            string Vchar = "0,1,2,3,4,5,6,7,8,9,a,b,c,d,f,e,f,g,h,i,j";
            string[] VcArray = Vchar.Split(',');
            string VNum = "";//由于字符串很短，就不用StringBuilder了 
            int temp = -1;//记录上次随机数值，尽量避免生产几个一样的随机数 
            //采用一个简单的算法以保证生成随机数的不同 
            Random rand = new Random();
            for (int i = 1; i < VcodeNum + 1; i++)
            {
                if (temp != -1) { rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks)); }
                //int t = rand.Next(35) ; 
                int t = rand.Next(20);
                if (temp != -1 && temp == t) { return RndNum(VcodeNum); }
                temp = t;
                VNum += VcArray[t];
            }
            return VNum;
        }
        #endregion

        #region 登录前保存当前URL到cookie,以便登录后返回.
        public static void saveurl()
        {
            setcookie("url", HttpContext.Current.Request.Url.ToString(), 1);
        }
        #endregion

        #region 去除HTML标记
        public static string NoHTML(string Htmlstring)
        {
            //删除脚本   
            Htmlstring = Regex.Replace(Htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML   
            Htmlstring = Regex.Replace(Htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            Htmlstring = Regex.Replace(Htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();

            return Htmlstring;
        }
        #endregion

        #region 设置cookies函数,三个参数，一个是cookie的名字，一个是值,一个是cookie 将被保存天数
        //设置cookies函数,三个参数，一个是cookie的名字，一个是值,一个是cookie 将被保存天数
        public static void setcookie(string cname, string value, int exdays)
        {
            delcookie(cname);
            if (exdays > 0)  //0则是会话
            {
                HttpContext.Current.Response.Cookies[cname].Expires = DateTime.Now.AddDays(exdays);
            }
            HttpContext.Current.Response.Cookies[cname].Value = HttpUtility.UrlEncode(value, System.Text.Encoding.GetEncoding("utf-8"));
        }
        public static string getcookie(string cname)
        {
            if (HttpContext.Current.Request.Cookies[cname] != null)
            {
                return HttpUtility.UrlDecode(HttpContext.Current.Request.Cookies[cname].Value, System.Text.Encoding.GetEncoding("utf-8"));
            }
            return "";
        }
        public static void delcookie(string cname)
        {
            HttpCookie cok = HttpContext.Current.Request.Cookies[cname];
            if (cok != null)
            {
                TimeSpan ts = new TimeSpan(-1, 0, 0, 0);
                cok.Expires = DateTime.Now.Add(ts);//删除整个Cookie，只要把过期时间设置为现在
                HttpContext.Current.Response.AppendCookie(cok);
            }
        }
        #endregion

        #region 获得ip地址
        public static string getip()
        {
            return HttpContext.Current.Request.UserHostAddress;
        }
        #endregion

        #region 根据ip获得城市
        public static string getcity(string ip)  //根据ip获得城市
        {
            string htmlstr;
            int endnum = 0;

            try
            {
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                Byte[] pageData = wc.DownloadData("http://www.ip138.com/ips138.asp?ip=" + ip);
                htmlstr = System.Text.Encoding.Default.GetString(pageData);

                htmlstr = htmlstr.Substring(htmlstr.IndexOf("<ul class=\"ul1\"><li>"), 50);
                htmlstr = htmlstr.Substring(htmlstr.IndexOf("<li>"));
                endnum = htmlstr.IndexOf("</");
                htmlstr = htmlstr.Substring(htmlstr.IndexOf(">") + 1, endnum - 4);
                htmlstr = htmlstr.Replace("本站主数据：", "");
                return htmlstr;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region 从左往右截取指定长度的字符
        //函数功能：从左往右截取指定长度的字符
        public static string left(string str, int i)
        {
            if (i <= str.Length)
                str = str.Substring(0, i);
            return str;
        }
        #endregion

        #region 从右往左截取指定长度的字符
        //函数功能：从右往左截取指定长度的字符
        public static string right(string str, int i)
        {
            if (i <= str.Length)
                str = str.Substring(str.Length - i, i);
            return str;
        }
        #endregion

        #region 根据ip获得城市
        /// <summary>
        /// 广州-深圳
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string getCityAndProvince(string ip)  //根据ip获得城市
        {
            string htmlstr;
            int endnum = 0;

            try
            {
                WebClient wc = new WebClient();
                wc.Credentials = CredentialCache.DefaultCredentials;
                Byte[] pageData = wc.DownloadData("http://www.ip138.com/ips138.asp?ip=" + ip);
                htmlstr = System.Text.Encoding.Default.GetString(pageData);

                htmlstr = htmlstr.Substring(htmlstr.IndexOf("<ul class=\"ul1\"><li>"), 50);
                htmlstr = htmlstr.Substring(htmlstr.IndexOf("<li>"));
                endnum = htmlstr.IndexOf("</");
                htmlstr = htmlstr.Substring(htmlstr.IndexOf(">") + 1, endnum - 7);
                htmlstr = htmlstr.Replace("本站主数据：", "");
                htmlstr = htmlstr.Replace("省", "-");
                htmlstr = htmlstr.Replace("市", "");
                return htmlstr;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        public static string Br(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace(((char)13).ToString(), "<br>").Replace(((char)10).ToString(), "");
            }
            else
            {
                return null;
            }
        }

        public static string deBr(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return str.Replace("<br>", ((char)13).ToString() + ((char)10).ToString());
            }
            else
            {
                return null;
            }
        }

        public static string EncryptMD5(string data)
        {
            byte[] result = Encoding.Default.GetBytes(data.Trim());
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }


        /// <summary>
        /// 计算奖金
        /// </summary>
        /// <param name="x">奖金</param>
        /// <param name="y">分成比例</param>
        /// <param name="isLeader">是否队长</param>
        /// <returns></returns>
        public static double? Calculate(decimal? x, decimal? y, bool isLeader)
        {

            decimal? a = x * 0.9m;//得到奖金的90%
            decimal? h = x * 0.1m;//得到奖金的10%
            decimal? o = y / 100;//得到分成比例
            decimal? c = a * o;
            if (isLeader)//是否队长
            {
                var o1 = c + h;
                if (o1 != null) return Math.Round((double)o1,2);
            }
            if (c != null) return Math.Round((double)c, 2);
            return null;
        }
    }
}
