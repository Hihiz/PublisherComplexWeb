using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Infrastructure.Data;

namespace PublisherComplexWeb.Infrastructure.Repositories
{
    public class MaterialRepository : IBaseRepository<Material>
    {
        private readonly ApplicationDbContext _db;

        public MaterialRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Material>> GetAll() => await _db.Materials.OrderBy(m => m.Id).Include(m => m.Device).Include(m => m.Works).AsNoTracking().ToListAsync();

        public async Task<Material> GetById(int id) => await _db.Materials.Include(m => m.Device).Include(m => m.Works).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

        public async Task<Material> Create(Material entity)
        {
            await _db.Materials.AddAsync(entity);

            await _db.Entry(entity).Reference(m => m.Device).LoadAsync();

            return entity;
        }

        public async Task<Material> Update(Material entity)
        {
            _db.Materials.Update(entity);

            await _db.Entry(entity).Reference(m => m.Device).LoadAsync();

            return entity;
        }

        public async Task Delete(Material entity) => _db.Materials.Remove(entity);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
