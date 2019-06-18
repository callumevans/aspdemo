using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AspBehaviour.Test
{
    public class TestApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {           
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();
                
                services.AddDbContextPool<UsersDbContext>(options => 
                {
                    options.UseInMemoryDatabase("users");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<UsersDbContext>();

                    db.Database.EnsureCreated();
                    
                    db.Users.AddRange(DatabaseSeeding.Users);

                    db.SaveChanges();
                }
            });
            
            base.ConfigureWebHost(builder);
        }
    }
}