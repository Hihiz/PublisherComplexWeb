using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Infrastructure.Data;

namespace PublisherComplexWeb.Infrastructure.Repositories
{
    public class WorkRepository : IBaseRepository<Work>, IBaseRepositoryWorkOrder<Work>
    {
        private readonly ApplicationDbContext _db;

        public WorkRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Work>> GetAll() =>
            await _db.Works           
            .Include(w => w.Material).ThenInclude(m => m.Device)
            .Include(w => w.Format)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Work> GetById(int id) =>
            await _db.Works
            .Include(w => w.Order)
            .Include(w => w.TypeWork)
            .Include(w => w.Material).ThenInclude(m => m.Device)
             .Include(w => w.Format)
            .AsNoTracking();

        public async Task<Work> Create(Work entity)
        {
            await _db.AddAsync(entity);

            return entity;
        }

        public async Task<Work> Update(Work entity)
        {
            _db.Update(entity);

            return entity;
        }

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
