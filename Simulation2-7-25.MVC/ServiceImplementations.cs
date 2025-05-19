using Microsoft.AspNetCore.Identity;
using Simulation2_7_25.BL.Services.Concretes;
using Simulation2_7_25.DAL.Contexts;
using Simulation2_7_25.DAL.Models;
using Simulation2_7_25.DAL.Repositories.Abstactions;
using Simulation2_7_25.DAL.Repositories.Concretes;

namespace Simulation2_7_25.MVC;

public static class ServiceImplementations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddControllersWithViews();

        services.AddIdentity<AppUser, IdentityRole>(opt =>
        {

        }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

        services.AddScoped<IRepository<Profession>, Repository<Profession>>();
        services.AddScoped<IRepository<Doctor>, Repository<Doctor>>();


        services.AddScoped<ProfessionService>();
        services.AddScoped<DoctorService>();

    }
}
