using AutoMapper;
using BasicData.Domain.Entries;
using BasicData.Infrastructure.Mapper;
using System.ComponentModel.DataAnnotations;

namespace BasicDataOfCustomers.API.DTOs
{
    public class CustomerDto : IMapFrom<Customer>
    {
        public int CustomerId { get; set; }
        [Required]
        public string? FirstCustomerName { get; set; }
        public string? LastCustomerName { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string? Comment { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        public int Class { get; set; }
        public string FullName { get { return $"{FirstCustomerName} {LastCustomerName}"; } set { } }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDto>().ReverseMap();

        }
    }
}
