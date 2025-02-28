using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Domain;

namespace Product.Repository
{
	public interface IProductRepository
	{
		Task<IEnumerable<ProdutoResult>> GetAllAsync();
		Task<ProdutoResult> GetByIdAsync(int id);
		Task AddAsync(ProdutoRequest product);
		Task<bool> UpdateAsync(ProdutoRequest product);
		Task DeleteAsync(int id);
	}
}