using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Models.Domain.Dtos
{
    public class MetaObjectDto
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
