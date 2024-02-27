using Microsoft.EntityFrameworkCore;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Domain.Entities;
using PublisherComplexWeb.Domain.Enums;
using PublisherComplexWeb.Infrastructure.Data;

namespace PublisherComplexWeb.Infrastructure.Repositories
{
    public class OrderRepository : IBaseRepository<Order>, IBaseRepositoryOrder<Order>
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) => _db = db;

        public async Task<List<Order>> GetAll() =>
            await _db.Orders
            .OrderBy(o => o.Id)
            .Include(o => o.Works)
            .AsNoTracking()
            .ToListAsync();

        public async Task<Order> GetById(int id) => 
            await _db.Orders
            .Include(o => o.Works)
            .AsNoTracking()
            .FirstOrDefaultAsync(o => o.Id == id);

        public async Task<List<Order>> GetOrdersClose() =>
            await _db.Orders
            .OrderBy(o => o.Id)
            .Include(o => o.Works)
            .AsNoTracking()
            .Where(o => o.StatusOrder == Status.Close)
            .ToListAsync();

        public async Task<List<Order>> GetOrdersOpen() =>
            await _db.Orders
            .OrderBy(o => o.Id)
            .Include(o => o.Works)
            .AsNoTracking()
            .Where(o => o.StatusOrder == Status.Open)
            .ToListAsync();

        public async Task<Order> Create(Order entity)
        {
            await _db.Orders.AddAsync(entity);

            return entity;
        }

        public async Task<Order> Update(Order entity)
        {
            _db.Orders.Update(entity);

            return entity;
        }

        public async Task Delete(Order entity) => _db.Orders.Remove(entity);

        public async Task SaveChangesAsync() => await _db.SaveChangesAsync();
    }
}
