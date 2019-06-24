using Lancet.Models.Domain.Model;
using Lancet.Repository.Abstract;

namespace Lancet.Repository.Concrete
{
    public class MetaObjectRepository : GenericRepository<MetaObject>, IMetaObjectRepository
    {
        public MetaObjectRepository(LancetContext _LancetContext) : base(_LancetContext)
        { }
    }
}
