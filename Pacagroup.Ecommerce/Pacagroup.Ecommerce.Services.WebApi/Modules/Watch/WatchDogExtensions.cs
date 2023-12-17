using WatchDog;

namespace Pacagroup.Ecommerce.Services.WebApi.Modules.Watch;

public static class WatchDogExtensions
{
    public static IServiceCollection AddWatchDog(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddWatchDogServices(options =>
        {
            options.SetExternalDbConnString = configuration.GetConnectionString("NorthwindConnection");
            options.DbDriverOption = WatchDog.src.Enums.WatchDogDbDriverEnum.MSSQL;
            options.IsAutoClear = true;
            options.ClearTimeSchedule = WatchDog.src.Enums.WatchDogAutoClearScheduleEnum.Monthly;
        });

        return services;
    }
}
