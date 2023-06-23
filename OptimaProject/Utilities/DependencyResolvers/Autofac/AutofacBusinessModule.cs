using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OptimaProject.Entities.Concrete;
using OptimaProject.Repositories.Abstract;
using OptimaProject.Repositories.Concrete;
using OptimaProject.Utilities.ValidationRules;
using Utilities.Interceptors;
using Utilities.Security.Jwt;

namespace OptimaProject.Utilities.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<InvoiceRepository>().As<IInvoiceRepository>();
            builder.RegisterType<SettingsRepository>().As<ISettingsRepository>();
            builder.RegisterType<CustomerValidator>().As<IValidator<Customer>>();
            builder.RegisterType<ProductValidator>().As<IValidator<Product>>();
            builder.RegisterType<InvoiceDetailValidator>().As<IValidator<InvoiceDetail>>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
