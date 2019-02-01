using System;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Метаданные объектов
    /// </summary>
    public class MetaData
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Содержание
        /// </summary>
        public string Content { get; set; }        
        /// <summary>
        /// Метатип
        /// </summary>
        public Guid MetaTypeId { get; set; }
        /// <summary>
        /// Объект-владелец
        /// </summary>
        public Guid MetaObjectId { get; set; }
    }
}
