using OptimaProject.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace OptimaProject.Entities.Concrete
{
    public class InvoiceDetail : IEntity
    {
        public int Id { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public double ProductPrice { get; set; }
        [Required]
        public int ProductCount { get; set; }
        public bool Status { get; set; }
    }
}
