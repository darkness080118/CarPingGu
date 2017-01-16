using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Wesalt.Basis.Tools
{
    ///2015-08-31
    /// 覃之祺
    /// <summary>
    /// 邮件工具类
    /// </summary>
    public static class EmailHelper
    {
        /// <summary>
        /// 邮件设置
        /// </summary>
        /// <param name="mailTo">收件方邮箱</param>
        /// <param name="mailFrom">寄件方邮箱</param>
        /// <param name="mailSub">邮件主题</param>
        /// <param name="mailContent">邮件内容</param>
        /// <param name="Priority">邮件有限级别</param>
        /// <returns></returns>
        public static MailMessage SetMailMessage(string mailTo, string mailFrom, string mailSub, string mailContent)
        {

            // 发送邮件设置        
            MailMessage mailMessage = new MailMessage(mailFrom, mailTo); // 发送人和收件人
            mailMessage.Subject = mailSub;//主题
            mailMessage.Body = mailContent;//内容
            mailMessage.BodyEncoding = Encoding.UTF8;//正文编码
            mailMessage.IsBodyHtml = true;//设置为HTML格式
            mailMessage.Priority = MailPriority.Normal;//优先级
            return mailMessage;
        }



        /// <summary>
        /// SMTP设置和邮件发送暂时不支持附件
        /// </summary>
        /// <param name="smtpServer">SMTP邮件地址</param>
        /// <param name="mailFrom">SMTP登陆账号</param>
        /// <param name="userPassword">SMTP登陆密码</param>
        /// <param name="port">SMTP端口</param>
        /// <param name="ssl">SMTP SSL加密</param>
        /// <param name="mailMessage">邮件</param>
        /// <returns></returns>
        public static bool SetSmtpClient(string smtpServer, string mailFrom, string userPassword, string port, bool ssl, MailMessage mailMessage)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            smtpClient.Host = smtpServer; //指定SMTP服务器
            smtpClient.Credentials = new System.Net.NetworkCredential(mailFrom, userPassword);//用户名和密码
            if (port != null && !port.Equals(""))
            {
                smtpClient.Port = Convert.ToInt32(port);
            }
            smtpClient.EnableSsl = ssl;
            try
            {
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (SmtpException e)
            {
                return false;
            }
        }



        /// <summary>
        /// 微盐平台服务邮件发送
        /// </summary>
        /// <param name="mailMessage"></param>
        /// <returns></returns>
        public static bool WesaltService_Email(string mailTo, string mailSub, string mailContent)
        {
            if (mailTo != null)
            {


                var email = SetMailMessage(mailTo, "noreply@iwesalt.com", mailSub, mailContent);
                try
                {
                    SetSmtpClient("smtp.ym.163.com", "noreply@iwesalt.com", "sendmsg2015", "25", false, email);
                }
                catch (SmtpException e)
                {
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
