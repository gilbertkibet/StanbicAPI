using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StanbicAPI.Models;

namespace StanbicAPI.ApiDbContext
{
    public class NotificationDbContext:DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options) { }

        public DbSet<StanbicBankNotification> StanbicBankNotifications { get; set; }

        public DbSet<KcbBankBillNotification> KcbBillNotifications { get; set; }

    }
}
