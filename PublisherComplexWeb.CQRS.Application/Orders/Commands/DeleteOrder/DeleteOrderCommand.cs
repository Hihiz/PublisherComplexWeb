﻿using MediatR;

namespace PublisherComplexWeb.CQRS.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<int>
    {
        public int Id { get; set; }

        public DeleteOrderCommand(int id) => Id = id;   
    }
}
