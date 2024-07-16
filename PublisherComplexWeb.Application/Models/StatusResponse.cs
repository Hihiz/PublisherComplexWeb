using PublisherComplexWeb.Application.Interfaces;

namespace PublisherComplexWeb.Application.Models
{
    public class StatusResponse<T, TList> : IBaseStatus
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public List<TList> Datas { get; set; }
    }
}
