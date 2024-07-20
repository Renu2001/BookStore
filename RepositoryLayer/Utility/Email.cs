using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using ModelLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Utility
{
    public class Email
    {
        private readonly Token _token;
        private readonly IConfiguration _config;

        public Email(Token token, IConfiguration config)
        {
            _token = token;
            _config = config;
        }

        public string SendResetMail(string emailId,UserEntity result)
        {
            string token = _token.GenerateToken(result);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("anonymous.u2003@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailId));
            email.Subject = "Password Reset Request";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $@"
                        <html>
                        <head>
                        </head>
                        <body>
                          <div class='container'>
                            <div class='header'>
                              <h2>Password Reset Request</h2>
                            </div>
                            <div class='content'>
                              <p>Hello,</p>
                              <p>We received a request to reset the password for your account. If you did not make this request, you can ignore this email.</p>
                              <p>To reset your password, please click the button below:</p>
                              <p><a href = {"http://localhost:5284/api/Users/ResetPassword"}>http://localhost:5284/api/Users/ResetPassword+{token}</a></p>
                              <p>Thank you,<br/>The BookStore Team</p>
                            </div>
                          </div>
                        </body>
                        </html>"
            };
            using var smtp = new SmtpClient();
            smtp.Connect(_config["Email:Host"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["Email:UserName"], _config["Email:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
            return token;
        }

        public string SendRegisterMail(UserEntity user)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("anonymous.u2003@gmail.com"));
            email.To.Add(MailboxAddress.Parse(user.Email));
            email.Subject = "User Registered";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = $@"{user.Name} is Registered Succesfully"
            };
            using var smtp = new SmtpClient();
            smtp.Connect(_config["Email:Host"], 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["Email:UserName"], _config["Email:Password"]);
            smtp.Send(email);
            smtp.Disconnect(true);
            return "Mail sent successfull";
        }
    }
}
