using System.ComponentModel.DataAnnotations;

namespace FastFood.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [MaxLength(70)]
        [Required]
        public string FirstName { get; set; } = null!;

        [Display(Name = "Last Name")]
        [MaxLength(70)]
        [Required]
        public string LastName { get; set; } = null!;

        [Display(Name = "Address Line 1")]
        [MaxLength(100)]
        [Required]
        public string AddressLine1 { get; set; }= null!;

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }= null!;

        [Display(Name = "Zip Code")]
        [MaxLength(10)]
        [Required]
        public string ZipCode { get; set; }= null!;

        [MaxLength(30)]
        public string State { get; set; } = null!;

        [MaxLength(50)]
        [Required]
        public string Country { get; set; } = null!;

        public string City { get; set; } = null!;

        [Display(Name = "Phone Number")]
        [MaxLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber{ get; set; } = null!;

        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [Required]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { get; set; } = null!;


        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public ICollection<OrderDetail> OrderLines { get; set; } = new List<OrderDetail>();


    }
}
