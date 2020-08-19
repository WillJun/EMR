using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace EMR.Application
{

    [DependsOn(
       typeof(AbpIdentityApplicationModule), typeof(AbpAutoMapperModule)
   )]
    public class EMRApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<EMRApplicationModule>();
            });
        }
    }
}
