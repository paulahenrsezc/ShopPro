using ShopPro.Infraestructure.Base;
using ShopPro.Infraestructure.Notification.Interfaces;
using ShopPro.Infraestructure.Notification.Model;

namespace ShopPro.Infraestructure.Notification.Services
{
    public class SmsService : INotificationService<SmsModel>
    {
        public Task<NotificationResult> Send(SmsModel model)
        {
            throw new NotImplementedException();
        }
    }
}
