using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TazkartiBusinessLayer.Auth;
using TazkartiBusinessLayer.Handlers;
using TazkartiBusinessLayer.Handlers.Match;
using TazkartiDataAccessLayer.DAOs;
using TazkartiDataAccessLayer.DAOs.Match;
using TazkartiDataAccessLayer.DAOs.Seat;
using TazkartiDataAccessLayer.DAOs.Stadium;
using TazkartiDataAccessLayer.DataTypes;
using TazkartiDataAccessLayer.DbContexts;

namespace TazkartiService;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TazkartiApi", Version = "v1" });
        });
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        services.AddAuthentication("Bearer")
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    // validate issuer signing key 
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = this.Configuration["Authentication:Audience"],
                    ValidIssuer = this.Configuration["Authentication:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["Authentication:SecretForKey"]??string.Empty))
                };
            });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("MustBeApprovedFan", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(Roles.Fan);
                policy.RequireClaim("status", UserStatus.Approved.ToString());
            });
            options.AddPolicy("MustBeApprovedEFAManager", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(Roles.EFAManager);
                policy.RequireClaim("status", UserStatus.Approved.ToString());
            });
        });
        
        this.DependencyRegistry(services);
        
        services.AddDbContext<TazkartiDbContext>(options =>
            options.UseSqlite(this.Configuration["ConnectionStrings:TazkartiDbContextConnection"] ?? string.Empty));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API Name v1"));
        }
        
        app.UseCors(builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });

        app.UseHttpsRedirection();
        
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
    
    public void DependencyRegistry(IServiceCollection services)
    {
        // register daos
        services.AddScoped<IUserDao, UserDao>();
        services.AddScoped<IStadiumDao, StadiumDao>();
        services.AddScoped<IMatchDao, MatchDao>();
        services.AddScoped<ISeatDao, SeatDao>();
        
        // register handlers
        services.AddScoped<IUserHandler, UserHandler>();
        services.AddScoped<IStadiumHandler, StadiumHandler>();
        services.AddScoped<IMatchHandler, MatchHandler>();
        services.AddScoped<AuthHandler>();
        
        // password hasher
        services.AddSingleton<PasswordHasherUtility>();
    }
}