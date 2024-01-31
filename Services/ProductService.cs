using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services 
{
	public class ProductService
	{
		TestDbContext _ctx;

		public ProductService(TestDbContext ctx)
		{
			_ctx = ctx;
		}

		public ProductList  ListProducts(int page)
		{
			List<Product> prods =  _ctx.Products.Skip((page - 1) * 10).Take(10).ToList();
			bool hasNext = _ctx.Products.OrderBy(x => x.Id).Last() == _ctx.Products.OrderBy(s => s.Id).Skip((page - 1) * 10).Take(10).Last()? false:true;


            return new ProductList() {  HasNext= hasNext, TotalCount = _ctx.Products.Count(), Products = prods };
		}

	}
}
