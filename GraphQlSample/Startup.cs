using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQlSample.GraphqlCore;
using GraphQlSample.Infrastructure.DBContext;
using GraphQlSample.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

            services.AddDbContext<TechEventDBContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("GraphQLDBConnection")));
            services.AddSwaggerGen();

            services.AddTransient<ITechEventRepository, TechEventRepository>();
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
             
            services.AddTransient<EventParticipants>();

            services.AddTransient<TechEventInputType>();
            services.AddTransient<TechEventMutation>();
            services.AddTransient<TechEventInfoType>();
            services.AddTransient<TechEventQuery>();
            //builder.Services.AddSingleton<ISchema, TechEventSchema>();

            //services.AddTransient<ISchemaMapper>(_ => new SchemaMapper(new Dictionary<string, ISchema> {
            //{"TechEventSchema", new TechEventSchema(new FuncDependencyResolver(type => (IGraphType)_.GetRequiredService(type))) },
            //{"ParticipantSchema", new ParticipantSchema(new FuncDependencyResolver(type => (IGraphType)_.GetRequiredService(type))) } }));


            var sp = services.BuildServiceProvider();

           
             services.AddSingleton<ISchema>(new TechEventSchema(new FuncDependencyResolver(type => sp.GetService(type))));


            services.AddTransient<ParticipantInputType>();
            services.AddTransient<ParticipantMutation>();
            services.AddTransient<ParticipantType>();
            services.AddTransient<ParticipantQuery>();
            //services.AddSingleton<ISchema>(new ParticipantSchema(new FuncDependencyResolver(type => services.BuildServiceProvider().GetService(type))));

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



        }
    }
}
