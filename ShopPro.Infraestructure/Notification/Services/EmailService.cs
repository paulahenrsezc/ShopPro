using ShopPro.Infraestructure.Base;
using ShopPro.Infraestructure.Notification.Interfaces;
using ShopPro.Infraestructure.Notification.Model;

namespace ShopPro.Infraestructure.Notification.Services
{
    public class EmailService : INotificationService<EmailModel>
    {
        Task<NotificationResult> INotificationService<EmailModel>.Send(EmailModel model)
        {
            throw new NotImplementedException();

        }
    }
}
