using Microsoft.AspNetCore.Mvc;
using Product.Domain;
using Product.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<ProdutoResult>>> Get()
		{
			var products = await _productRepository.GetAllAsync();
			return Ok(products);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Produto>> Get(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] ProdutoRequest produto)
		{
			if (string.IsNullOrEmpty(produto.Nome) || produto.Preco <= 0 || produto.QuantidadeEstoque < 0)
			{
				return BadRequest("Dados inválidos do produto.");
			}
			await _productRepository.AddAsync(produto);
			return CreatedAtAction(nameof(Get), new { id = produto.ProdutoId }, produto);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] ProdutoRequest produto)
		{
			if (id != produto.ProdutoId || string.IsNullOrEmpty(produto.Nome) || produto.Preco <= 0 || produto.QuantidadeEstoque < 0)
			{
				return BadRequest("Dados inválidos do produto.");
			}
			var existingProduct = await _productRepository.GetByIdAsync(id);
			if (existingProduct == null)
			{
				return NotFound();
			}
			await _productRepository.UpdateAsync(produto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			await _productRepository.DeleteAsync(id);
			return NoContent();
		}
	}
}