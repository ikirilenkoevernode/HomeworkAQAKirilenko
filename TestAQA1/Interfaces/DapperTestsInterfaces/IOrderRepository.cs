using System;
using System.Collections.Generic;
using System.Text;
using Tests1.DTO.DapperTestsDTO;

namespace Tests1.Interfaces.DapperTestsInterfaces
{
    public interface IOrderRepository
    {
        Task<OrderDTO> GetOrderByOrderId(int orderId);
    }
}
