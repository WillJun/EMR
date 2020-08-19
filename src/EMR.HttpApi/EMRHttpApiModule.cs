using EMR.Application;

using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace EMR.HttpApi
{
    [DependsOn(

        typeof(AbpIdentityHttpApiModule),

         typeof(EMRApplicationModule)
        )]
    public class EMRHttpApiModule : AbpModule
    {
    }
}
