using Microsoft.EntityFrameworkCore;
using OptimaProject.Entities.Concrete;
using OptimaProject.Repositories.Abstract;
using System.Collections.Generic;
using System;
using Utilities.Results;
using OptimaProject.DbContexts;
using System.Linq;
using Utilities.Aspects.Autofac;
using Castle.Core.Resource;

namespace OptimaProject.Repositories.Concrete
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly OptimaDbContext _context;
        public SettingsRepository(OptimaDbContext context)
        {
            _context = context;
        }

        [SecuredOperation("Admin")]
        public IResult AddCustomer(Customer customer)
        {
            try
            {
                var addedEntity = _context.Entry(customer);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new SuccessResult("Müştəri uğurla əlavə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult AddDiscount(Discount discount)
        {
            try
            {
                var addedEntity = _context.Entry(discount);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new SuccessResult("Endirim uğurla əlavə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult AddInvoiceType(InvoiceType invoiceType)
        {
            try
            {
                var addedEntity = _context.Entry(invoiceType);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new SuccessResult("Qaimə növü uğurla əlavə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult AddOperationClaim(OperationClaim operationClaim)
        {
            try
            {
                var addedEntity = _context.Entry(operationClaim);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new SuccessResult("Səlahiyyət uğurla əlavə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult AddProduct(Product product)
        {
            try
            {
                var addedEntity = _context.Entry(product);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new SuccessResult("Məhsul uğurla əlavə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult AddUserOperationClaim(UserOperationClaim userOperationClaim)
        {
            try
            {
                var addedEntity = _context.Entry(userOperationClaim);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new SuccessResult("İstifadəçiyə səlahiyyət verildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult DeleteCustomer(Customer customer)
        {
            try
            {
                var selectedEntity = _context.Customers.Find(customer.Id);
                selectedEntity.Status = false;
                _context.Customers.Update(selectedEntity);
                _context.SaveChangesAsync();

                return new SuccessResult("Müştəri uğurla silindi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult DeleteDiscount(Discount discount)
        {
            try
            {
                var selectedEntity = _context.Discounts.Find(discount.Id);
                selectedEntity.Status = false;
                _context.Discounts.Update(selectedEntity);
                _context.SaveChangesAsync();

                return new SuccessResult("Endirim uğurla silindi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult DeleteProduct(Product product)
        {
            try
            {
                var selectedEntity = _context.Products.Find(product.Id);
                selectedEntity.Status = false;
                _context.Products.Update(selectedEntity);
                _context.SaveChangesAsync();

                return new SuccessResult("Məhsul uğurla silindi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        public IDataResult<List<Customer>> GetCustomerList()
        {
            var listOfCustomers = _context.Customers.Where(x => x.Status == true).ToList();
            return new SuccessDataResult<List<Customer>>(listOfCustomers, "Müştəri siyahısı uğurla gətirildi");
        }

        public IDataResult<List<Discount>> GetDiscountList()
        {
            var listOfDiscounts = _context.Discounts.Where(x => x.Status == true).ToList();
            return new SuccessDataResult<List<Discount>>(listOfDiscounts, "Endirim siyahısı uğurla gətirildi");
        }

        public IDataResult<List<Product>> GetProductList()
        {
            var listOfProducts = _context.Products.Where(x => x.Status == true).ToList();
            return new SuccessDataResult<List<Product>>(listOfProducts, "Məhsul siyahısı uğurla gətirildi");
        }

        [SecuredOperation("Admin")]
        public IResult UpdateCustomer(Customer customer)
        {
            try
            {
                var updatedEntity = _context.Entry(customer);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return new SuccessResult("Müştəri uğurla redaktə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult UpdateDiscount(Discount discount)
        {
            try
            {
                var updatedEntity = _context.Entry(discount);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return new SuccessResult("Endirim uğurla redaktə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }

        [SecuredOperation("Admin")]
        public IResult UpdateProduct(Product product)
        {
            try
            {
                var updatedEntity = _context.Entry(product);
                updatedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return new SuccessResult("Məhsul uğurla redaktə edildi");
            }
            catch (Exception ex)
            {

                return new ErrorResult(ex.Message);
            }
        }
    }
}
