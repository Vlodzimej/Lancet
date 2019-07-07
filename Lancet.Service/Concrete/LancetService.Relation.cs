using Lancet.Models.Domain.Model;
using Lancet.Service.Abstract;
using Lancet.Models.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lancet.Service.Concrete
{
    public partial class LancetService : ILancetService
    {
        public List<RelationDto> GetRelationsByMetaObjectId(Guid metaObjectId, Guid metaTypeId)
        {
            // Находим связи объекта с определённым типом (например, роли)
            var objectRelations = _unitOfWork.ObjectRelationRepository.Get(r => (metaObjectId != null ? r.MetaObjectId == metaObjectId : true) && (metaTypeId != null ? r.MetaTypeId == metaTypeId : true));
            var relations = _unitOfWork.RelationRepository.Get().Where(x => objectRelations.Select(or => or.RelationId == x.Id).Any()).Select(x => x.Id);
            // Находим связанные объекты
            var objects = _unitOfWork.ObjectRelationRepository.Get(r => (metaTypeId != null ? r.MetaTypeId == metaTypeId : true)).Select(or => relations.Contains(or.Id) && or.MetaObjectId != metaObjectId);
            return new List<RelationDto>()
            {
                new RelationDto()
            };
        }
    }
}
