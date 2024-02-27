using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Infrastructure.Data;

namespace PublisherComplexWeb.Infrastructure.Repositories
{
    public class FormatRepository : IBaseRepository<Format>
    {
        private readonly ApplicationDbContext _db;

        public FormatRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Format>> GetAll() => await _db.Formats.OrderBy(f => f.Id).Include(f => f.Works).AsNoTracking().ToListAsync();

        public async Task<Format> GetById(int id) => await _db.Formats.Include(f => f.Id).AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

        public async Task<Format> Create(Format entity)
        {
            await _db.Formats.AddAsync(entity);
            return entity;
        }

        public async Task<Format> Update(Format entity)
        {
            _db.Formats.Update(entity);

            return entity;
        }

        public async Task Delete(Format entity) => _db.Formats.Remove(entity);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
