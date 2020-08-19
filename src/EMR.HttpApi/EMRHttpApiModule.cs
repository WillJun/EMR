using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace EMR.HttpApi
{
    [DependsOn(typeof(AbpIdentityHttpApiModule))]
    class EMRHttpApiModule : AbpModule
    {
    }
}
