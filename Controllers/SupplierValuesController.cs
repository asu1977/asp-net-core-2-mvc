using Microsoft.AspNetCore.Mvc;
using suppliers.Models;
using suppliers.Models.BindingTargets;
using System.Collections;
using System.Collections.Generic;

namespace suppliers.Controllers
{
    [Route("api/suppliers")]
    public class SupplierValuesController : Controller
    {
        private DataContext context;

        public SupplierValuesController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Supplier> GetSuppliers()
        {
            return context.Suppliers;
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody]SupplierData sdata)
        {
            if (ModelState.IsValid)
            {
                Supplier s = sdata.Supplier;
                context.Add(s);
                context.SaveChanges();
                return Ok(s.SupplierId);
            } else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
