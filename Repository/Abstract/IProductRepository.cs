using WebAPI.Models.Domain;

namespace WebAPI.Repository.Abstract
{
    public interface IProductRepository
    {
        bool add(AngularProduct model);
        IEnumerable<AngularProduct> getAll();
    }
}
