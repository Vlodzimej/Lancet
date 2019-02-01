using System;

namespace Lancet.Models.Domain.Model
{
    /// <summary>
    /// Метатипы объектов и связей
    /// </summary>
    public class MetaType
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
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
