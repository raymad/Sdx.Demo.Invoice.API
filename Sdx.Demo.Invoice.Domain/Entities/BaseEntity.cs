using System;
using System.Collections.Generic;
using System.Text;

namespace Sdx.Demo.Invoice.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }

        public BaseEntity()
        {
        }

        public BaseEntity(int id)
        {
            Id = id;
        }
    }
}
