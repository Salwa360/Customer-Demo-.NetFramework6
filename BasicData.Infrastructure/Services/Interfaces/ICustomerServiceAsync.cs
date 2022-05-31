using BasicDataOfCustomers.API.DTOs;
using BasicDataOfCustomers.Infrastructure.DTOs;

namespace BasicData.Infrastructure.Services.Interfaces
{
    public interface ICustomerServiceAsync
    {
        Task<FilteringCustomersDto> GetAllCustomersAsync(FilteringCustomersDto dto);

        Task<CustomerDto> GetCustomerByIdAsync(int id);
        Task<int> AddNewCustomerAsync(CustomerDto customer);
        Task<CustomerDto> EditCustomerAsync(CustomerDto customer);
        Task<bool> DeleteCustomerByIdAsync(int id);

    }
}
