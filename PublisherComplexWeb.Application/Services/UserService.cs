using PublisherComplexWeb.Application.Dto.Order;
using PublisherComplexWeb.Application.Dto.User;
using PublisherComplexWeb.Application.Interfaces;

namespace PublisherComplexWeb.Application.Services
{
    public class UserService : IUserService<OrderDto>
    {
        private readonly IUserAuthService<UserDto> _userAuthService;

        public UserService(IUserAuthService<UserDto> userAuthService) => _userAuthService = userAuthService;

        public async Task<List<OrderDto>> GetOrdersUserNames(List<OrderDto> orderDto)
        {
            Dictionary<long, string> userNameDictionary = (await _userAuthService.GetAuthUsers())
                .ToDictionary(u => u.Id, u => u.Fio);

            foreach (OrderDto order in orderDto)
            {
                if (userNameDictionary.TryGetValue(order.Id, out string userName))
                {
                    order.UserFio = userName;
                }
            }

            return orderDto;
        }

        public async Task<OrderDto> GetOrderUserName(OrderDto orderDto)
        {
            Dictionary<long, string> userNameDictionary = (await _userAuthService.GetAuthUsers())
                 .ToDictionary(u => u.Id, u => u.Fio);

            if (userNameDictionary.TryGetValue(orderDto.Id, out string userName))
            {
                orderDto.UserFio = userName;
            }

            return orderDto;
        }
    }
}
