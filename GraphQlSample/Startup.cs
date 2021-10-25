using GraphQL.Types;
using GraphQlSample.GraphqlCore;
using GraphQlSample.Infrastructure.DBContext;
using GraphQlSample.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GraphiQl;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Mvc;
using GraphQL;

namespace GraphQlSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddDbContext<TechEventDBContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("GraphQLDBConnection")));
            services.AddSwaggerGen();

            services.AddTransient<ITechEventRepository, TechEventRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();

            services.AddTransient<TechEventInfoType>();
            services.AddTransient<ParticipantType>();
            services.AddTransient<TechEventQuery>();
            services.AddTransient<TechEventInputType>();
            services.AddTransient<TechEventMutation>();


            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new TechEventSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseHttpsRedirection();
           
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseGraphiQl("/graphql");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V2");
            });
            //   app.UseMvc();
        }
    }
}
