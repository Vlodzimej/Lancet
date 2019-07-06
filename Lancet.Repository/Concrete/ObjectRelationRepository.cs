using Lancet.Models.Domain.Model;
using Lancet.Repository.Abstract;

namespace Lancet.Repository.Concrete
{
    public class ObjectRelationRepository : GenericRepository<ObjectRelation>, IObjectRelationRepository
    {
        public ObjectRelationRepository(LancetContext _LancetContext) : base(_LancetContext)
        { }
    }
}
