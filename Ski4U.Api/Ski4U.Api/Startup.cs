using GraphQL.Server.Ui.Voyager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ski4U.Api.Mutations;
using Ski4U.Api.Queries;
using Ski4U.Api.Types;
using Ski4U.Data;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using Ski4U.Repository.Implementations;

namespace Ski4U.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ConStr")));
            //services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ConStr")), ServiceLifetime.Transient);

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddType<SkiItemType>()
                .AddType<SkiItemAttributeType>()
                .AddType<CommentType>()
                .AddFiltering()
                .AddSorting();

            //repositories
            services.AddTransient<ISkiItemRepository, SkiItemRepository>();
            services.AddTransient<ISkiItemAttributeRepository, SkiItemAttributeRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();

            //data loaders
            services.AddTransient<SkiItemBatchDataLoader>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions(), "/graphql-voyager");
        }
    }
}
