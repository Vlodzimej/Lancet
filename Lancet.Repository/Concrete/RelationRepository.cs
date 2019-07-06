using Lancet.Models.Domain.Model;
using Lancet.Repository.Abstract;

namespace Lancet.Repository.Concrete
{
    public class RelationRepository : GenericRepository<Relation>, IRelationRepository
    {
        public RelationRepository(LancetContext _LancetContext) : base(_LancetContext)
        { }
    }
}
