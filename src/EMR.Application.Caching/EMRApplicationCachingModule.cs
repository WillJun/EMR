using EMR.Domain;
using EMR.Domain.Configurations;

using Microsoft.Extensions.DependencyInjection;

using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace EMR.Application.Caching
{
    [DependsOn(
           typeof(AbpCachingModule),
        typeof(EMRDomainModule)
       )]
    public class EMRApplicationCachingModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = AppSettings.Caching.RedisConnectionString;
                //options.InstanceName
                //options.ConfigurationOptions
            });
            //base.ConfigureServices(context);
        }
    }
}