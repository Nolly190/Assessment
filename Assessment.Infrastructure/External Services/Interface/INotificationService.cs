using Assessment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Infrastructure.External_Services.Interface
{
    public interface INotificationService
    {
        void SendNotification(Book book, User customerInfo);
    }
}
