using Lancet.Models.Domain.Dtos;
using Lancet.Models.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Service.Abstract
{
    public partial interface ILancetService
    {
        IEnumerable<MetaObjectDto> GetMetaObjectById(Guid metaObjectId, string username = null);
        Guid CreateMetaObject(MetaObjectDto metaObjectDto);
        IEnumerable<MetaObjectDto> GetAllMetaObjects();
        MetaObject GetMetaObjectByUsername(string username);
    }
}
