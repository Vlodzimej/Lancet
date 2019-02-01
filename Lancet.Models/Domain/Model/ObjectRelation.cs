using System;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Класс описывающий характер связи объектов между собой
    /// </summary>
    public class ObjectRelation
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Бизнес-объект
        /// </summary>
        public Guid MetaObjectId { get; set; }
        /// <summary>
        /// Объект привязки
        /// </summary>
        public Guid RelationId { get; set; }
        /// <summary>
        /// Метатип
        /// </summary>
        public Guid MetaTypeId { get; set; }
    }
}
