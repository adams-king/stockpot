using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Stockpot.BusinessLogic.Ingredients;
using Stockpot.BusinessLogic.PreparationSteps;
using Stockpot.BusinessLogic.RecipeIngredients;
using Stockpot.BusinessLogic.Recipes;
using Stockpot.BusinessLogic.RecipeTags;
using Stockpot.BusinessLogic.Tags;
using Stockpot.DataAccess;
using Stockpot.DataAccess.Repositories;
using Stockpot.WebApi.Misc;
using Swashbuckle.AspNetCore.Swagger;

namespace Stockpot.WebApi
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add DataAccess
            services.AddSingleton<IConnectionStringProvider>(provider =>
                new ConnectionStringProvider(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContextProvider>();

            // Add repositories
            services.AddScoped<IngredientsRepository>();
            services.AddScoped<PreparationStepsRepository>();
            services.AddScoped<RecipesRepository>();
            services.AddScoped<TagsRepository>();

            // Add services
            services.AddScoped<IngredientsService>();
            services.AddScoped<PreparationStepsService>();
            services.AddScoped<RecipesService>();
            services.AddScoped<TagsService>();

            // Add dto mappers
            services.AddScoped<IngredientsDtoMapper>();
            services.AddScoped<PreparationStepsDtoMapper>();
            services.AddScoped<RecipeIngredientsDtoMapper>();
            services.AddScoped<RecipesDtoMapper>();
            services.AddScoped<RecipeTagsDtoMapper>();
            services.AddScoped<TagsDtoMapper>();

            // Enforce lower case urls.
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            // Add Mvc.
            services.AddMvc(options =>
            {
                options.Filters.Add(new ValidateModelFilterAttribute());
            });

            // Register the Swagger generator, defining one or more Swagger documents.
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info { Title = "Stockpot API", Version = "v1" });
            });

            // Enable CORS
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, DbContextProvider dbContextProvider)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandler("/api/error/exception");
            app.UseStatusCodePagesWithReExecute("/api/error/{0}");

            // Initialize database
            DbInitializer.Initialize(dbContextProvider);

            // Add CORS
            app.UseCors(builder => builder.WithOrigins("*"));

            // Add swagger when in development
            if (env.IsDevelopment())
            {
                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Stockpot API V1");
                });
            }

            app.UseMvc();
        }
    }
}