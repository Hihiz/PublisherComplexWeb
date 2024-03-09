using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Domain.Entities;

namespace PublisherComplexWeb.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TypeWork> TypeWorks { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Format> Formats { get; set; }
    }
}
