using System;
using System.Collections.Generic;
using System.Text;

namespace Lancet.Models.Domain.Dtos
{
    public class RelationDto
    {
        public Guid Id { get; set; }
        public List<Guid> MetaObjects { get; set; }
        public Guid MetaTypeId { get; set; }
    }
}
