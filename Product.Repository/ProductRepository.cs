using Product.API.Data;
using Product.Domain;
using Microsoft.EntityFrameworkCore;
using Azure.Core;

namespace Product.Repository
{
	public class ProductRepository : IProductRepository
	{
		private readonly ProductContext _context;

		// Injeção do DbContext correto
		public ProductRepository(ProductContext context)
		{
			_context = context;
		}

		// CRUD com o ProductContext (usando EF Core)
		public async Task<IEnumerable<ProdutoResult>> GetAllAsync()
		{
			return await _context.Produto
				.Select(p => new ProdutoResult
				{
					ProdutoId = p.ProductId,
					Nome = p.Name,
					Preco = p.Price,
					QuantidadeEstoque = p.StockQuantity
				})
				.OrderBy(x => x.Nome)
				.ToListAsync();

		}

		public async Task<ProdutoResult> GetByIdAsync(int id)
		{
			return await _context.Produto
					.Where(x => x.ProductId == id)
					.Select(p => new ProdutoResult
					{
						ProdutoId = p.ProductId,
						Nome = p.Name,
						Preco = p.Price,
						QuantidadeEstoque = p.StockQuantity
					})
					.FirstOrDefaultAsync();

		}

		public async Task AddAsync(ProdutoRequest produtoRequest)
		{
			var produto = new Produto()
			{
				Name = produtoRequest.Nome,
				Price = produtoRequest.Preco,
				StockQuantity = produtoRequest.QuantidadeEstoque
			};

			await _context.Produto.AddAsync(produto);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> UpdateAsync(ProdutoRequest produtoRequest)
		{			
			var produtoBD = await _context.Produto
				.FirstOrDefaultAsync(p => p.ProductId == produtoRequest.ProdutoId);

			if (produtoBD is null)
				return false; //produto não seja encontrado

			produtoBD.Name = produtoRequest.Nome;
			produtoBD.Price = produtoRequest.Preco;
			produtoBD.StockQuantity = produtoRequest.QuantidadeEstoque;

			_context.Produto.Update(produtoBD);
			await _context.SaveChangesAsync();

			return true;
		}

		public async Task DeleteAsync(int id)
		{
			var produto = await _context.Produto.FindAsync(id);
			if (produto != null)
			{
				_context.Produto.Remove(produto);
				await _context.SaveChangesAsync();
			}
		}
	}
}
