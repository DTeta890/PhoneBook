using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PhoneBook.Data;
using System;

namespace PhoneBook.Repository
{
    public static class ChangeTrackerExtension
    {
        public static void ApplyAuditInformation(this ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries())
            {
                if (!(entry.Entity is BaseEntity baseEntity)) continue;

                var now = DateTime.Now;
                switch (entry.State)
                {
                    case EntityState.Modified:
                        baseEntity.UpdatedAt = now;
                        break;
                    case EntityState.Added:
                        baseEntity.CreatedAt = now;
                        baseEntity.UpdatedAt = now;
                        break;
                }
            }
        }
    }
}
