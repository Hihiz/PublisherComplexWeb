namespace PublisherComplexWeb.Infrastructure
{
    public class DeviceRepository : IBaseRepository<>
    {
        public async Task<List GetAll() => Devices.AsNoTracking().Include(d =>).OrderBy(d => d.Id);

    }
}
