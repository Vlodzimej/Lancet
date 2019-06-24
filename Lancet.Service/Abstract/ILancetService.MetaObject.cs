using Lancet.Models.Domain.Dtos;
using Lancet.Models.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Service.Abstract
{
    public partial interface ILancetService
    {
        MetaObjectDto GetMetaObjectById(Guid metaObjectId);
        Guid CreateMetaObject(MetaObjectDto metaObjectDto);
    }
}
