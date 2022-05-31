using BasicDataOfCustomers.API.DTOs;

namespace BasicDataOfCustomers.Infrastructure.DTOs
{
    public class FilteringCustomersDto
    {
        public FilteringCustomersDto()
        {
            Items = new List<CustomerDto>();
        }
        public List<CustomerDto> Items { get; set; }
        public Paginator Paginator { get; set; }
        public Sorting Sorting { get; set; }

    }
    public class Paginator
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int? Total { get; set; }

    }
    public class Sorting
    {
        private string _column { get; set; }
        public string Column
        {
            get => _column;
            set
            {
                _column = !string.IsNullOrEmpty(value.Trim()) ? string.Concat($"{value[0]}".ToUpper(), value.AsSpan(1)) :
                    string.Empty;
            }
        }

        public string Direction { get; set; } 
    }
}
