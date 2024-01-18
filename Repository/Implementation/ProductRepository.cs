using WebAPI.Repository.Abstract;
using WebAPI.Models.Domain;

namespace WebAPI.Repository.Implementation
{
    public class ProductRepostory : IProductRepository
    {
		private readonly DatabaseContext _context;
		public ProductRepostory(DatabaseContext context)
		{
			this._context = context;
		}
        public bool add(AngularProduct model)
        {
			try
			{
				_context.angularProductsTbl.Add(model);
				_context.SaveChanges();
				return true;
			}
			catch (Exception exception)
			{

				return false;
			}
        }

        public IEnumerable<AngularProduct> getAll()
		{
			return _context.angularProductsTbl.ToList();
		}


    }
}
