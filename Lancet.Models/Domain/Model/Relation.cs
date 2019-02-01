using System;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Объект привязки
    /// </summary>
    public class Relation
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
