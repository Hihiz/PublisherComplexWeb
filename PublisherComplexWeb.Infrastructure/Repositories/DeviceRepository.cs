using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Infrastructure.Data;

namespace PublisherComplexWeb.Infrastructure.Repositories
{
    public class DeviceRepository : IBaseRepository<Device>
    {
        private readonly ApplicationDbContext _db;

        public DeviceRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Device>> GetAll() => await _db.Devices.Include(d => d.Materials).OrderBy(d => d.Id).AsNoTracking().ToListAsync();

        public async Task<Device> GetById(int id) => await _db.Devices.Include(d => d.Materials).AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);

        public async Task<Device> Create(Device entity)
        {
            await _db.Devices.AddAsync(entity);

            return entity;
        }

        public async Task<Device> Update(Device entity)
        {
            _db.Devices.Update(entity);

            return entity;
        }

        public async Task Delete(Device entity) => _db.Devices.Remove(entity);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
