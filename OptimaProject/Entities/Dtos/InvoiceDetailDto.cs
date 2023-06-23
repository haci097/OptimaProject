using OptimaProject.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OptimaProject.Entities.Dtos
{
    public class InvoiceDetailDto : IDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceTypeName { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductCount { get; set; }
        public string CustomernName { get; set; }
        public bool Status { get; set; }
    }
}
