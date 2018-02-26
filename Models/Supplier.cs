using System.Collections.Generic;

namespace suppliers.Models
{
    public class Supplier
    {
        public long SupplierId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
