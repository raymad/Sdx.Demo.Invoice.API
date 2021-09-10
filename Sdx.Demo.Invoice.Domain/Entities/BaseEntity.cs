using System;
using System.Collections.Generic;
using System.Text;

namespace Sdx.Demo.Invoice.Domain.Entities
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; private set; }

        private BaseEntity()
        {
        }

        protected BaseEntity(int id)
        {
            Id = id;
        }
    }
}
