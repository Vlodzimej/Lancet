using System;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Бизнес-объекты
    /// </summary>
    public class MetaObject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Заголовок
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Системное имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Метатип
        /// </summary>
        public Guid MetaTypeId { get; set; }
        /// <summary>
        /// Содержание
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Дата завершения
        /// </summary>
        public DateTime FinishDate { get; set; }
    }
}
