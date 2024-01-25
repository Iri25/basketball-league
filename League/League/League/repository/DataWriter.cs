using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace League.repository
{
    class DataWriter
    {
        public static List<T> WriterData<T>(string fileName, CreateEntity<T> createEntity)
        {
            List<T> list = new List<T>();
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                string s;
                //while ((s = streamWriter.WriteLine()))
                //{
                //    T entity = createEntity(s);
                //    list.Add(entity);
                //}
            }
            return list;
        }
    } 
}
