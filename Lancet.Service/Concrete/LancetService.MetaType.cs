using Lancet.Models.Domain.Model;
using Lancet.Service.Abstract;
using Lancet.Models.Domain.Dtos;
using System;

namespace Lancet.Service.Concrete
{
    public partial class LancetService : ILancetService
    {
        public MetaTypeDto GetMetaTypeById(Guid metaTypeId)
        {
            var metaType = _unitOfWork.MetaTypeRepository.GetByID(metaTypeId);
            var metaTypeDto = _mapper.Map<MetaTypeDto>(metaType);
            return metaTypeDto;
        }


        public Guid CreateMetaType(MetaTypeDto metaTypeDto)
        {
            var metaType = _mapper.Map<MetaObject>(metaTypeDto);
            metaType.Id = Guid.NewGuid();
            metaType.CreateDate = DateTime.UtcNow;

            if (_unitOfWork.MetaObjectRepository.Add(metaType))
            {
                return metaType.Id;
            }
            return new Guid();
        }
    }
}
