using System;
using System.Collections.Generic;
using System.Text;
using League.domain;

namespace League.repository
{
    interface IRepository<ID, E> where E : Entity<ID>
    {
        E FindOne(ID id);

        IEnumerable<E> FindAll();

        E Save(E entity);

        E Update(E entity);

        E Delete(ID id);
    }
}
