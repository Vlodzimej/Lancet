using Lancet.Models.Domain.Dtos;
using Lancet.Models.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Service.Abstract
{
    public partial interface ILancetService
    {
        List<RelationDto> GetRelationsByMetaObjectId(Guid metaObjectId, Guid metaTypeId);
    }
}
