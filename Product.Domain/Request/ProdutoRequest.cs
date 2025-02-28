namespace Product.Domain
{
    public class ProdutoRequest
	{
		public int ProdutoId { get; set; }
		public string Nome { get; set; }
		public decimal Preco { get; set; }
		public int QuantidadeEstoque { get; set; }
	}   
}
