using EMR.Domain;

using Microsoft.AspNetCore.Builder;

using Volo.Abp;
using Volo.Abp.Modularity;

namespace EMR.Swagger
{
    [DependsOn(
             typeof(EMRDomainModule)
         )]
    public class EMRSwaggerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSwagger();
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            context.GetApplicationBuilder().UseSwagger().UseSwaggerUI();
        }
    }
}