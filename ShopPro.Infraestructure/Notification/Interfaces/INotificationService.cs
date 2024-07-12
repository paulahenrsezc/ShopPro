using ShopPro.Infraestructure.Base;

namespace ShopPro.Infraestructure.Notification.Interfaces
{
    public interface INotificationService<TModel> where TModel : class
    {
        public Task<NotificationResult> Send(TModel model);
    }
}
