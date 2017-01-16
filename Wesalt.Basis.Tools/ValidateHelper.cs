using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wesalt.Basis.Tools
{
    ///2015-08-31
    /// 覃之祺
    /// <summary>
    /// 数据验证工具类
    /// </summary>
    public static class ValidateHelper
    {
        #region 得到某字符串的长度,先检查是否为空值.能检测三种类型,布尔,字符串,数字
        /// <summary>
        /// 检查长度
        /// </summary>
        /// <param name="para"></param>
        /// <returns></returns> 2015/07/24优化
        public static int xlength(object para)
        {
            try
            {
                switch (Convert.ToString(para.GetType()))
                {
                    case "System.Boolean":
                        switch ((bool)para)
                        {
                            case true:
                                return 1;
                            case false:
                                return 0;
                        }
                        break;
                    case "System.String":
                        return para.Equals(DBNull.Value) ? 0 : para.ToString().Length;
                    case "System.Int32":
                        return Convert.ToInt32(para);                //检测数值返回实际长度
                }
            }
            catch
            {
                return 0; //无法检测
            }
            return 0; //无法检测
        }
        #endregion

        #region 检查字符串是否合法
        public static readonly string LEGAL_CHARACTERS = "abcdefghijklmnopqrstuvwxyz0123456789";
        /// <summary>
        /// 检查字符串是否合法
        /// </summary>
        /// <param name="sExt">需要检查字符</param>
        /// <returns>bool</returns>
        public static bool isLegalCharacters(string sExt)
        {
            sExt = sExt.ToLower();
            for (int i = 0; i < sExt.Length; i++)
            {
                if (!LEGAL_CHARACTERS.Contains(sExt.Substring(i, 1)))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region 判断邮箱是否合法
        /// <summary> 
        /// 检测输入的邮件地址strEmail是否合法，非法则返回true。 
        /// </summary> 
        public static bool CheckEmail(string strEmail)
        {
            int i, j;
            string strTmp, strResult;
            string strWords = "abcdefghijklmnopqrstuvwxyz_-.0123456789"; //定义合法字符范围 
            bool blResult = false;
            strTmp = strEmail.Trim();
            //检测输入字符串是否为空，不为空时才执行代码。 
            if (!(strTmp == "" || strTmp.Length == 0))
            {
                //判断邮件地址中是否存在“@”号 
                if ((strTmp.IndexOf("@") < 0))
                {
                    blResult = true;
                    return blResult;
                }
                //以“@”号为分割符，把地址切分成两部分，分别进行验证。 
                string[] strChars = strTmp.Split(new char[] { '@' });
                foreach (string strChar in strChars)
                {
                    i = strChar.Length;
                    //“@”号前部分或后部分为空时。 
                    if (i == 0)
                    {
                        blResult = true;
                        return blResult;
                    }
                    //逐个字进行验证，如果超出所定义的字符范围strWords，则表示地址非法。 
                    for (j = 0; j < i; j++)
                    {
                        strResult = strChar.Substring(j, 1).ToLower();//逐个字符取出比较 
                        if (strWords.IndexOf(strResult) < 0)
                        {
                            blResult = true;
                            return blResult;
                        }
                    }
                }
            }
            return blResult;
        }
        #endregion

        #region 判断是否为邮箱
        public static bool IsEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
        #endregion

        #region 判断是否为电话
        public static bool IsTelephone(string telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(telephone, @"^[1][3578][0-9]{9}$");
        }
        #endregion

        #region 验证身份证号
        public static bool IsIDcard(string idcard)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(idcard, @" /^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$/");
        }
        #endregion

        public static bool IsInt(string value)
        {
            try
            {
                Convert.ToInt32(value);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public static bool IsDouble(string value)
        {
            try
            {
                Convert.ToDouble(value);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
