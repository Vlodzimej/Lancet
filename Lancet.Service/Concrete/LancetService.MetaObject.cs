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
        /// <summary>
        /// Получение мета-объекта по Id
        /// </summary>
        /// <param name="metaObjectId">Id мета-объекта</param>
        /// <returns></returns>
        public IEnumerable<MetaObjectDto> GetMetaObjectById(Guid metaObjectId, string username = null)
        {
            var metaObject = _unitOfWork.MetaObjectRepository.GetByID(metaObjectId);
            var metaObjectDto = _mapper.Map<MetaObjectDto>(metaObject);
            if (username != null)
            {
                var accountObject = GetMetaObjectByUsername(username);
                
            }
            var result = new List<MetaObjectDto>() { metaObjectDto };
            return result;
        }

        /// <summary>
        /// Создание мета-объекта
        /// </summary>
        /// <param name="metaObjectDto"></param>
        /// <returns></returns>
        public Guid CreateMetaObject(MetaObjectDto metaObjectDto)
        {
            var metaObject = _mapper.Map<MetaObject>(metaObjectDto);
            metaObject.Id = Guid.NewGuid();
            metaObject.CreateDate = DateTime.UtcNow;

            if (_unitOfWork.MetaObjectRepository.Add(metaObject))
            {
                _unitOfWork.Save();
                return metaObject.Id;
            }
            return Guid.Empty;
        }

        /// <summary>
        /// Получить все мета-объекты
        /// </summary>
        /// <returns></returns>
        public IEnumerable<MetaObjectDto> GetAllMetaObjects()
        {
            var metaObjectDtos = _unitOfWork.MetaObjectRepository.Get();
            var result = metaObjectDtos.Select(x =>
            {
                return _mapper.Map<MetaObjectDto>(x);
            });
            return result;
        }

        /// <summary>
        /// Получить мета-объект по имени
        /// </summary>
        /// <param name="username">Имя мета-объекта</param>
        /// <returns></returns>
        public MetaObject GetMetaObjectByUsername(string username)
        {
            return _unitOfWork.MetaObjectRepository.Get(x => (username != null ? x.Name == username : true)).FirstOrDefault();
        }
    }
}
