using Mvc101.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Mvc101.Services.EmailService
{
    public class SendGridEmailService : IEmailService
    {
        private readonly ISendGridClient _sendGridClient;

        public SendGridEmailService(ISendGridClient sendGridClient)
        {
            _sendGridClient = sendGridClient;
        }

        public Task SendEmailAsync(MailModel model)
        {
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("agmet1999@gmail.com", "Mail"),
                Subject = model.Subject
            };
            msg.AddContent(MimeType.Html, model.Body);
            foreach (var emailModel in model.To)
            {
                msg.AddTo(new EmailAddress(emailModel.Adress, emailModel.Name));
            }
            foreach (var emailModel in model.Cc)
            {
                msg.AddCc(new EmailAddress(emailModel.Adress, emailModel.Name));
            }
            foreach (var emailModel in model.Bcc)
            {
                msg.AddBcc(new EmailAddress(emailModel.Adress, emailModel.Name));
            }
            return _sendGridClient.SendEmailAsync(msg);
        }
    }
}