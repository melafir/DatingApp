using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config){
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services){
            services.AddDbContext<DataContext>(options=>{
                options.UseSqlite(_config.GetConnectionString("DefaultConnection"));
            });
            services.AddControllers();
            services.AddCors();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if(env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(policy=>{
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.WithOrigins("https://localhost:4200");
            });
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>{
                endpoints.MapControllers();
            });
        }
    }
}