using BasicData.Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BasicData.Domain.Entries
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [MaxLength(30), Required]
        public string? FirstCustomerName { get; set; }
        [MaxLength(30)]
        public string? LastCustomerName { get; set; }
        [MaxLength(11), Required]
        public string? PhoneNumber { get; set; }
        [MaxLength(50), Required]
        public string? Comment { get; set; }
        [MaxLength(30), Required]
        [EmailAddress]
        public string? Email { get; set; }
        public Classes? Class { get; set; } = Classes.A;
    }
}
