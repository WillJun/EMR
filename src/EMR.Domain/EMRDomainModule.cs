using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace EMR.Domain
{
    [DependsOn(

        typeof(AbpIdentityDomainModule)

        )]
    public class EMRDomainModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            //BlogDomainObjectExtensions.Configure();
        }

        //public override void ConfigureServices(ServiceConfigurationContext context)
        //{
        //    Configure<AbpMultiTenancyOptions>(options =>
        //    {
        //        options.IsEnabled = MultiTenancyConsts.IsEnabled;
        //    });
        //}
    }
}