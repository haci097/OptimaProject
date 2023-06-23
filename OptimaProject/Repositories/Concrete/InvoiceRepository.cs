using OptimaProject.DbContexts;
using OptimaProject.Entities.Concrete;
using OptimaProject.Entities.Dtos;
using OptimaProject.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using Utilities.Aspects.Autofac;
using Utilities.Results;

namespace OptimaProject.Repositories.Concrete
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly OptimaDbContext _context;
        public InvoiceRepository(OptimaDbContext context)
        {
            _context = context;
        }

        [SecuredOperation("Cashier")]
        public IResult AddInvoice(Invoice invoice)
        {
            try
            {
                if (invoice.InvoiceTypeId == 1)
                {
                    invoice.ChildInvoiceId = 0;
                }

                var newInvoice = new Invoice()
                {
                    InvoiceTypeId = invoice.InvoiceTypeId,
                    CustomerId = invoice.CustomerId,
                    ChildInvoiceId = invoice.ChildInvoiceId
                };

                _context.Invoices.Add(newInvoice);
                _context.SaveChangesAsync();
                return new SuccessResult("Qaimə uğurla yaradıldı");
            }
            catch (Exception ex)
            {
                return new ErrorResult(ex.Message);
            }

        }

        [SecuredOperation("Cashier")]
        public IResult AddInvoiceDetails(int InvoiceId, List<Detail> details)
        {
            var invoice = _context.Invoices.Find(InvoiceId);

            if (invoice.InvoiceTypeId == 1)
            {
                var discount = _context.Discounts.Where(x => x.BeginDate <= DateTime.Today && x.EndDate >= DateTime.Today).FirstOrDefault();

                double discountAmount = 1;
                if (discount != null)
                {
                    discountAmount = 1 - discount.DiscountAmount / 100.0;
                }

                for (int i = 0; i < details.Count; i++)
                {
                    var newInvoiceDetail = new InvoiceDetail()
                    {
                        InvoiceId = InvoiceId,
                        ProductId = details[i].ProductId,
                        ProductPrice = details[i].ProductPrice * discountAmount,
                        ProductCount = details[i].ProductCount
                    };

                    _context.InvoiceDetails.Add(newInvoiceDetail);
                }

                _context.SaveChangesAsync();
                return new SuccessResult("Satış qaiməsi uğurla əlavə olundu");
            }
            else
            {

                var salesInvoiceDetails = _context.InvoiceDetails.Where(id => id.InvoiceId == invoice.ChildInvoiceId).ToList();
                List<Detail> salesDetails = new List<Detail>();
                for (int i = 0; i < salesInvoiceDetails.Count; i++)
                {
                    Detail salesDetail = new Detail()
                    {
                        ProductId = salesInvoiceDetails[i].ProductId,
                        ProductPrice = salesInvoiceDetails[i].ProductPrice,
                        ProductCount = salesInvoiceDetails[i].ProductCount
                    };

                    salesDetails.Add(salesDetail);
                }

                if (salesDetails.Count > 0)
                {

                    var output = (from d1 in details
                                  from d2 in salesDetails
                                  where (d1.ProductId == d2.ProductId) && (d1.ProductCount == d2.ProductCount) && (d1.ProductPrice == d2.ProductPrice)
                                  select d2).ToList();

                    if (output.Count > 0)
                    {
                        for (int i = 0; i < output.Count; i++)
                        {
                            var newInvoiceDetail = new InvoiceDetail()
                            {
                                InvoiceId = InvoiceId,
                                ProductId = output[i].ProductId,
                                ProductPrice = output[i].ProductPrice,
                                ProductCount = output[i].ProductCount
                            };

                            _context.InvoiceDetails.Add(newInvoiceDetail);
                        }

                        _context.SaveChangesAsync();
                        return new SuccessResult("Geri qaytarma qaiməsi uğurla əlavə olundu");
                    }
                    else
                    {
                        return new ErrorResult("Geri qaytarma qaiməsi ilə satış qaiməsi uyğunsuzdur");
                    }
                }
                else
                {
                    return new ErrorResult("Uyğun satış qaiməsi tapılmadı");
                }

            }
        }

        public IDataResult<List<InvoiceDetailDto>> GetInvoiceDetailList()
        {
            var result = from id in _context.InvoiceDetails
                         join i in _context.Invoices
                         on id.InvoiceId equals i.Id
                         join p in _context.Products
                         on id.ProductId equals p.Id
                         join it in _context.InvoiceTypes
                         on i.InvoiceTypeId equals it.Id
                         join c in _context.Customers
                         on i.CustomerId equals c.Id
                         select new InvoiceDetailDto
                         {
                             Id = id.Id,
                             InvoiceId = id.InvoiceId,
                             InvoiceTypeName = it.InvoiceTypeName,
                             ProductName = p.ProductName,
                             ProductPrice = id.ProductPrice,
                             ProductCount = id.ProductCount,
                             CustomernName = c.CustomerName,
                             Status = id.Status
                         };
            return new SuccessDataResult<List<InvoiceDetailDto>>(result.ToList(), "Qaimə detalları siyahısı uğurla gətirildi");
        }

        public IDataResult<List<InvoiceDto>> GetInvoiceList()
        {
            var result = from i in _context.Invoices
                         join it in _context.InvoiceTypes
                         on i.InvoiceTypeId equals it.Id
                         join c in _context.Customers
                         on i.CustomerId equals c.Id
                         select new InvoiceDto
                         {
                             Id = i.Id,
                             InvoiceType = it.InvoiceTypeName,
                             CustomerName = c.CustomerName,
                             ChildInvoiceId = i.ChildInvoiceId,
                             Status = i.Status
                         };
            return new SuccessDataResult<List<InvoiceDto>>(result.ToList(), "Qaimə siyahısı uğurla gətirildi");
        }
    }
}
