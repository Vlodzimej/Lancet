using Lancet.Models.Domain.Dtos;
using Lancet.Models.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Service.Abstract
{
    public partial interface ILancetService
    {
        MetaTypeDto GetMetaTypeById(Guid metaTypeId);
        Guid CreateMetaType(MetaTypeDto metaTypeDto);
    }
}
