namespace IMS.Core.Common.Helper
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string body);
        Task SendEmailToCustomer(string Email, string Subject, string emailText);
    }
}
