using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using League.domain;
using League.validator;

namespace League.repository
{
    public class InMemoryRepository<ID, E> : IRepository<ID, E> where E : Entity<ID>
    {
        protected IValidator<E> validator;

        protected IDictionary<ID, E> entities = new Dictionary<ID, E>();

        public InMemoryRepository(IValidator<E> validator)
        {
            this.validator = validator;
            entities = new Dictionary<ID, E>();
        }

        public E FindOne(ID id)
        {
            if (id == null)
                throw new ArgumentNullException("Id must not be null!");
            if(entities.ContainsKey(id))
                return entities[id];
            return null;
        }

        public IEnumerable<E> FindAll()
        {
            return entities.Values.ToList<E>();
        }

        public virtual E Save(E entity)
        {
            validator.Validate(entity);
            if (entity == null)
                throw new ArgumentNullException("Entity must not be null!");
            this.validator.Validate(entity);
            if (this.entities.ContainsKey(entity.Id))
            {
                return entity;
            }
            this.entities[entity.Id] = entity;
            return default(E);
        }

        public E Update(E entity)
        {
            E e = FindOne(entity.Id);
            if (entity == null)
                throw new ArgumentNullException("Id must not be null!");
            validator.Validate(entity);
            if(!entities.ContainsKey(entity.Id))
                return entity;
            entities[entity.Id] = entity;
            return null;
        }

        public E Delete(ID id)
        {
            E e = FindOne(id);
            if (id == null)
                throw new ArgumentNullException("Id must not be null!");
            if(!entities.ContainsKey(id))
                return null;
            E entity = entities[id];
            entities.Remove(id);
            return  entity;
        }

    }
}