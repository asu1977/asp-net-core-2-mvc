using System.ComponentModel.DataAnnotations;

namespace suppliers.Models.BindingTargets
{
    public class SupplierData
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Address { get; set; }

        public Supplier Supplier => new Supplier
        {
            Name = Name, City = City, Address = Address
        };
    }
}
