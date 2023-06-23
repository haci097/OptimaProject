using OptimaProject.Entities.Concrete;
using System.Collections.Generic;
using Utilities.Results;

namespace OptimaProject.Repositories.Abstract
{
    public interface ISettingsRepository
    {
        IDataResult<List<Discount>> GetDiscountList();
        IResult AddDiscount(Discount discount);
        IResult UpdateDiscount(Discount discount);
        IResult DeleteDiscount(Discount discount);
        IDataResult<List<Product>> GetProductList();
        IResult AddProduct(Product product);
        IResult UpdateProduct(Product product);
        IResult DeleteProduct(Product product);
        IDataResult<List<Customer>> GetCustomerList();
        IResult AddCustomer(Customer customer);
        IResult UpdateCustomer(Customer customer);
        IResult DeleteCustomer(Customer customer);
        IResult AddOperationClaim(OperationClaim operationClaim);
        IResult AddUserOperationClaim(UserOperationClaim userOperationClaim);
        IResult AddInvoiceType(InvoiceType invoiceType);

    }
}
