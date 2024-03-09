using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Infrastructure.Data;

namespace PublisherComplexWeb.Infrastructure.Repositories
{
    public class TypeWorkRepository : IBaseRepository<TypeWork>
    {
        private readonly ApplicationDbContext _db;

        public TypeWorkRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<TypeWork>> GetAll() => await _db.TypeWorks.OrderBy(t => t.Id).Include(t => t.Works).AsNoTracking().ToListAsync();

        public async Task<TypeWork> GetById(int id) => await _db.TypeWorks.Include(t => t.Works).AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);

        public async Task<TypeWork> Create(TypeWork entity)
        {
            await _db.TypeWorks.AddAsync(entity);

            return entity;
        }

        public async Task<TypeWork> Update(TypeWork entity)
        {
            _db.TypeWorks.Update(entity);

            return entity;
        }

        public async Task Delete(TypeWork entity) => _db.TypeWorks.Remove(entity);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
