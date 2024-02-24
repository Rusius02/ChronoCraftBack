
using System.Text;
using Application.UseCases.User;
using Infrastructure;
using Infrastructure.SqlServer.Repository.User;
using Infrastructure.SqlServer.System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace WebApi
{
    public class Startup
    {
        public static readonly string MyOrigins1 = "MyOrigins1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<Database>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors(options =>
            {
                options.AddPolicy(MyOrigins1, builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });

            });
            //Add repos
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IDatabaseManager, DatabaseManager>();
            //Add use Case
            //User
            services.AddSingleton<UseCaseCreateUser>();

            //Authentication
            var key = "This is my secret Test key";
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            services.AddSingleton<IJwtAuthentificationManager>(new JwtAuthentificationManager(key));


            //Sport
            services.AddSingleton<UseCaseCreateUser>();

            //Activity


            //Post

           
            services.AddControllers();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v2", new OpenApiInfo { Title = "My API", Version = "v2" }); c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHttpsRedirection();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2"); });

            app.UseCors(MyOrigins1);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}