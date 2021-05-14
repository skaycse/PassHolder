using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace passholder.Utilities
{
    public abstract class EmailUtilities
    {
        private string _Password { get; set; }
        private string _Email { get; set; }
        private int _Port { get; set; } = 587;
        private bool _EnableSsl { get; set; } = true;
        private bool _IsBodyHtml { get; set; } = true;

        public EmailUtilities(string email, string password)
        {
            _Password = password;
            _Email = email;
        }

        public EmailUtilities(string email, string password, int port, bool isBodyHtml, bool enableSSL)
        {
            _Password = password;
            _Email = email;
            _Port = port;
            _EnableSsl = enableSSL;
            _IsBodyHtml = isBodyHtml;
        }

        protected async Task<bool> SendEmailAsync(string toAddress, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = _Port,
                    Credentials = new NetworkCredential(_Email, _Password),
                    EnableSsl = _EnableSsl,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(toAddress),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = _IsBodyHtml,
                };
                mailMessage.To.Add(toAddress);

                smtpClient.UseDefaultCredentials = false;

                await smtpClient.SendMailAsync(mailMessage);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    public class EmailUtility : EmailUtilities
    {
        public EmailUtility(string email, string password) : base(email, password)
        {

        }

        public EmailUtility(string email, string password, int port, bool isBodyHtml, bool enableSSL)
            : base(email, password, port, isBodyHtml, enableSSL)
        {

        }

        public async Task<bool> SendEmail(string toAddress, string subject, string body)
        {
            var res = await SendEmailAsync(toAddress, subject, body);
            return res;
        }
    }

    public class EmailTemplate
    {
        public const string Password = "Your one time password is <b>{0}</b>";
    }
}
