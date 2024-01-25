using System;
using System.Collections.Generic;
using System.Text;

namespace League.domain
{
    public class Entity<ID>
    {
        public Entity(ID id)
        {
            Id = id;
        }

        public ID Id { get; set; }
    }
}