using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
