using Autofac;
using Business.Abstract;
using Business.Concrete;
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
        }
    }
}
