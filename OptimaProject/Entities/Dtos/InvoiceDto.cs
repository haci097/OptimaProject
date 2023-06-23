using OptimaProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Entities.Dtos
{
    public class InvoiceDto : IDto
    {
        public int Id { get; set; }
        public string InvoiceType { get; set; }
        public string CustomerName { get; set; }
        public int ChildInvoiceId { get; set; }
        public bool Status { get; set; }
    }
}
