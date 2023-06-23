using OptimaProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Entities.Concrete
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        [Required]
        public int InvoiceTypeId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int ChildInvoiceId { get; set; }
        public bool Status { get; set; }
    }
}
