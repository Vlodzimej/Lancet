using Lancet.Models.Domain.Model;
using Lancet.Repository.Abstract;

namespace Lancet.Repository.Concrete
{
    public class MetaTypeRepository : GenericRepository<MetaType>, IMetaTypeRepository
    {
        public MetaTypeRepository(LancetContext _LancetContext) : base(_LancetContext)
        { }
    }
}
