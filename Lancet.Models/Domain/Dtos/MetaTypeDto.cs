using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Models.Domain.Dtos
{
    public class MetaTypeDto
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
