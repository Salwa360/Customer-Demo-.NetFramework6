using AutoMapper;
using BasicData.Domain.Entries;
using BasicData.Infrastructure.Persistence;
using BasicData.Infrastructure.Services.Interfaces;
using BasicDataOfCustomers.API.DTOs;
using BasicDataOfCustomers.Infrastructure.DTOs;
using Microsoft.EntityFrameworkCore;

using BasicDataOfCustomers.Infrastructure.Common.Extensions;

namespace BasicData.Infrastructure.Services.Implementions
{
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerServiceAsync(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<FilteringCustomersDto> GetAllCustomersAsync(FilteringCustomersDto dto)
        {
            var customerModel = await _context.Customers.AsNoTracking().ToListAsync();
            var customers = paginatorAndSortingCustomer(dto, customerModel);
            dto.Paginator.Total =(int) customerModel.Count();
            var customerDto = _mapper.Map<List<CustomerDto>>(customers);
            FilteringCustomersDto allCustomerAfterFilteration = MapCustomersDtoToFilteringCustomer(dto, customerDto);
            return allCustomerAfterFilteration;
        }

        private static FilteringCustomersDto MapCustomersDtoToFilteringCustomer(FilteringCustomersDto dto, List<CustomerDto> customerDto)
        {
            return new FilteringCustomersDto
            {
                Sorting = dto.Sorting,
                Paginator = dto.Paginator,
                Items = customerDto,

            };
        }

        private static List<Customer> paginatorAndSortingCustomer(FilteringCustomersDto dto, List<Customer> customerModel)
        {
            return customerModel.Take(dto.Paginator.Page * dto.Paginator.PageSize)
               .OrderBy(dto.Sorting)
                       .Skip((dto.Paginator.Page - 1) * dto.Paginator.PageSize)
                       .ToList();
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(int id)
        {
            var getCustomerById = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (getCustomerById == null)
                return null;
            var customerByIdDto = _mapper.Map<CustomerDto>(getCustomerById);
            return customerByIdDto;
        }
        public async Task<int> AddNewCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.CustomerId;
        }
        public async Task<CustomerDto> EditCustomerAsync(CustomerDto customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customerDto;
        }

        public async Task<bool> DeleteCustomerByIdAsync(int id)
        {
            var getCustomerById = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (getCustomerById == null)
                return false;
            try
            {
                _context.Customers.Remove(getCustomerById);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
