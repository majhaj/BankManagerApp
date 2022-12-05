using BankManager.DataAccess;
using BankManager.Entities;
using BankManager.Services.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services.Services
{
    public class NotificationService : INotificationService
    {

        public IBankManagerContext Context { get; }

        public NotificationService(IBankManagerContext bankManagerContext)
        {
            Context = bankManagerContext;
        }

        public void AddRange(IEnumerable<NotificationEntity> notifications)
        {
            foreach (var notification in notifications)
            {
                Create(notification);
            }
        }

        public NotificationEntity Create(NotificationEntity entity)
        {
            entity.CreationDate = DateTime.Now;
            Context.Notifications.Add(entity);
            Context.SaveChanges();

            var savedEntity = Context.Notifications.FirstOrDefault(x => x.Id == entity.Id);

            return savedEntity;
        }

        public void ChangeNotificationState(IEnumerable<int> notificationIds)
        {
            foreach (var notificationId in notificationIds)
            {
                var notification = Context.Notifications.FirstOrDefault(x => x.Id == notificationId);

                if (notification != null)
                {
                    notification.NotifiedByApp = true;
                }
            }

            Context.SaveChanges();
        }

        public IEnumerable<NotificationEntity> GetAllNotificationsByAppForUser(int id)
        {
            var result = Context.Notifications.Where(x => x.UserToNotifyId == id && !x.NotifiedByApp);

            return result;
        }

        public IEnumerable<NotificationEntity> GetAllNotificationsByServices(NotificationEntity entity)
        {
            var result = Context.Notifications.Where(x => x.NotifiedByService == false);

            return result;
        }
    }
}
