using OptimaProject.Entities.Concrete;
using OptimaProject.Entities.Dtos;
using System.Collections.Generic;
using Utilities.Results;

namespace OptimaProject.Repositories.Abstract
{
    public interface IInvoiceRepository
    {
        IResult AddInvoice(Invoice invoice);
        IDataResult<List<InvoiceDto>> GetInvoiceList();
        IResult AddInvoiceDetails(int InvoiceId, List<Detail> details);
        IDataResult<List<InvoiceDetailDto>> GetInvoiceDetailList();
    }
}
