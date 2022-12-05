using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManager.Services.Interfaces.Interfaces
{
    public interface INotificationService
    {
        NotificationEntity Create(NotificationEntity entity);
        void AddRange(IEnumerable<NotificationEntity> entity);
        IEnumerable<NotificationEntity> GetAllNotificationsByAppForUser(int id);
        IEnumerable<NotificationEntity> GetAllNotificationsByServices(NotificationEntity entity);
        void ChangeNotificationState(IEnumerable<int> notificationIds);
    }
}
