
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors((item) =>
{
    item.AddPolicy("default", (opt) =>
    {
        opt.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
    });
});
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            // if (app.Environment.IsDevelopment())
            // {
            //     app.UseSwagger();
            //     app.UseSwaggerUI();
            // }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors("default");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication1 API V1");
                    c.RoutePrefix = string.Empty; // Optional: shows Swagger at root URL
                });

app.UseSwagger(options => options.SerializeAsV2 = true);
            app.MapControllers();

            app.Run();
        }
    }
}
