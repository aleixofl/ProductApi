using Microsoft.EntityFrameworkCore;

namespace Product.API.Data
{
	public class ProductContext : DbContext
	{
		public ProductContext(DbContextOptions<ProductContext> options) : base(options)
		{
		}

		public DbSet<Domain.Produto> Produto { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configura o nome da tabela para 'Produto' (singular) se necessário
			modelBuilder.Entity<Domain.Produto>().ToTable("Product")
				.HasKey(p => p.ProductId); 
		}
	}
}
