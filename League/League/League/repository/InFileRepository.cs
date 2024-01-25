using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using League.domain;
using League.validator;

namespace League.repository
{
    public delegate E CreateEntity<E>(string line);
    public delegate string WriteEntity<E>(E e);

    public abstract class InFileRepository<ID, E> : InMemoryRepository<ID, E> where E : Entity<ID>
    {
        protected string fileName;
        protected CreateEntity<E> createEntity;
        protected WriteEntity<E> writeEntity;

        public InFileRepository(IValidator<E> validator, String fileName, CreateEntity<E> createEntity/* WriteEntity<E> writeEntity*/) : base(validator)
        {
            this.fileName = fileName;
            this.createEntity = createEntity;
            //this.writeEntity = writeEntity;
            if (createEntity != null)
                LoadFromFile();
        }

        protected virtual void LoadFromFile()
        {
            List<E> list = DataReader.ReadData(fileName, createEntity);
            list.ForEach(x => entities[x.Id] = x);
        }

       //protected virtual void WriteToFile(E entity)
       // {
       //     List<E> list = DataWriter.DataWriter(fileName, writeEntity);
       //     list.ForEach(x => entities[x.Id] = x);
       // }

        //public override E Save(E entity)
        //{
        //    E e = base.Save(entity);
        //    if(e == null)
        //    {
        //        WriteToFile(entity);
        //    }
        //    return entity;
        //}
        //public override E Save(E entity)
        //{
        //    using (StreamWriter file =
        //    new StreamWriter(fileName, true))
        //    {
        //        file.WriteLine(writeEntity(entity));
        //    }
        //    return base.Save(entity);
        //}
    }
}