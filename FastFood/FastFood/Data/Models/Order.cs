using System.ComponentModel.DataAnnotations;

namespace FastFood.Data.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string AddressLine1 { get; set; }= null!;

        public string AddressLine2 { get; set; }= null!;

        public string ZipCode { get; set; }= null!;

        public string State { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string PhoneNumber{ get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public ICollection<OrderDetail> OrderLines { get; set; } = new List<OrderDetail>();


    }
}
