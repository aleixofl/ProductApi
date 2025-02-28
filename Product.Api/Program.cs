using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Product.API.Data;
using Product.Repository;

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddSwaggerGen(c =>
{
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "Product API", Version = "v1" });
});

// Configura o contexto do banco de dados
builder.Services.AddDbContext<ProductContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configura o pipeline de requisição
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

// Habilita o Swagger e Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
	c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
	c.RoutePrefix = "swagger"; // Torna a URL do Swagger em http://localhost:5000/swagger
});
app.UseRouting();

// Mapeia os controllers
app.MapControllers();

app.Run();
