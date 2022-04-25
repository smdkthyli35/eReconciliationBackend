using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<AccountReconciliationManager>().As<IAccountReconciliationService>().SingleInstance();
            builder.RegisterType<EfAccountReconciliationDal>().As<IAccountReconciliationDal>().SingleInstance();

            builder.RegisterType<AccountReconciliationDetailManager>().As<IAccountReconciliationDetailService>().SingleInstance();
            builder.RegisterType<EfAccountReconciliationDetailDal>().As<IAccountReconciliationDetailDal>().SingleInstance();

            builder.RegisterType<BaBsReconciliationManager>().As<IBaBsReconciliationService>().SingleInstance();
            builder.RegisterType<EfBaBsReconciliationDal>().As<IBaBsReconciliationDal>().SingleInstance();

            builder.RegisterType<BaBsReconciliationDetailManager>().As<IBaBsReconciliationDetailService>().SingleInstance();
            builder.RegisterType<EfBaBsReconciliationDetailDal>().As<IBaBsReconciliationDetailDal>().SingleInstance();

            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<CurrencyManager>().As<ICurrencyService>().SingleInstance();
            builder.RegisterType<EfCurrencyDal>().As<ICurrencyDal>().SingleInstance();

            builder.RegisterType<CurrencyAccountManager>().As<ICurrencyAccountService>().SingleInstance();
            builder.RegisterType<EfCurrencyAccountDal>().As<ICurrencyAccountDal>().SingleInstance();

            builder.RegisterType<MailParameterManager>().As<IMailParameterService>().SingleInstance();
            builder.RegisterType<EfMailParameterDal>().As<IMailParameterDal>().SingleInstance();

            builder.RegisterType<MailTemplateManager>().As<IMailTemplateService>().SingleInstance();
            builder.RegisterType<EfMailTemplateDal>().As<IMailTemplateDal>().SingleInstance();

            builder.RegisterType<MailManager>().As<IMailService>().SingleInstance();
            builder.RegisterType<EfMailDal>().As<IMailDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
