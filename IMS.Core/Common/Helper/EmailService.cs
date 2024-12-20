using IMS.Core.Common.ResponseModel;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace IMS.Core.Common.Helper
{
    public class EmailService : IEmailService
    {
        private readonly string _apiKey;
        private readonly string _fromEmail;
        private readonly string _fromName;

        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _apiKey = configuration["SendGridSetting:ApiKey"];
            _fromEmail = configuration["SendGridSetting:FromEmail"];
            _fromName = configuration["SendGridSetting:FromName"];
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var client = new SendGridClient(_apiKey);
                var email = new SendGridMessage
                {
                    From = new EmailAddress(_fromEmail, _fromName),
                    Subject = subject,
                    HtmlContent = body
                };
                email.AddTo(new EmailAddress(toEmail));
                await client.SendEmailAsync(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task SendEmailToCustomer(string Email, string Subject, string emailText)
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                var smtpServer = _configuration["EmailConfiguration:SmtpServer"];
                var smtpPort = int.Parse(_configuration["EmailConfiguration:Port"]);
                var smtpUsername = _configuration["EmailConfiguration:Username"];
                var smtpPassword = _configuration["EmailConfiguration:Password"];

                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                    client.EnableSsl = true;

                    var mail = new MailMessage
                    {
                        From = new MailAddress(smtpUsername),
                        Subject = Subject,
                        Body = emailText, // Send plain text here
                        IsBodyHtml = false // Set to false for plain text emails
                    };

                    mail.To.Add(new MailAddress(Email)); // Add recipient email

                    await client.SendMailAsync(mail); // Use SendMailAsync for async operation
                }
            }
            catch (Exception ex)
            {
                // Consider using throw; instead of throw ex; to preserve the stack trace
                throw;
            }
        }

    }
}
