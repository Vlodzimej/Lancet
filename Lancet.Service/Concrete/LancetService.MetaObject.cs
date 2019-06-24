using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Lancet.Models.Domain.Model;
using Lancet.Service.Abstract;
using Lancet.Service.Helpers;
using Lancet.Models.Domain.Dtos;
using System;

namespace Lancet.Service.Concrete
{
    public partial class LancetService : ILancetService
    {
        public MetaObjectDto GetMetaObjectById(Guid metaObjectId)
        {
            var metaObject = _unitOfWork.MetaObjectRepository.GetByID(metaObjectId);
            var metaObjectDto = _mapper.Map<MetaObjectDto>(metaObject);
            return metaObjectDto;
        }


        public Guid CreateMetaObject(MetaObjectDto metaObjectDto)
        {
            var metaObject = _mapper.Map<MetaObject>(metaObjectDto);
            var idMetaObject = _unitOfWork.MetaObjectRepository.Add(metaObject).Id;
            return idMetaObject;
        }
    }
}
