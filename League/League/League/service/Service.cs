using System;
using System.Collections.Generic;
using System.Text;
using League.domain;
using League.repository;

namespace League.service
{
    public class Service<ID, E> where E : Entity<ID>
    {
        protected InFileRepository<ID, E> fileRepository;

        public Service(InFileRepository<ID, E> fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public E FindOne(ID id)
        {
            return fileRepository.FindOne(id);
            
        }

        public IEnumerable<E> FindAll()
        {
            return fileRepository.FindAll();
        }

        public E Save(E entity)
        {
            return fileRepository.Save(entity);
        }

        public E Update(E entity)
        {
            return fileRepository.Update(entity);
        }

        public E Delete(ID id)
        {
            return fileRepository.Delete(id);
        }

        public void WriteAllToFile()
        {
            //fileRepository.WriteAllToFile();
        }

    }
}
