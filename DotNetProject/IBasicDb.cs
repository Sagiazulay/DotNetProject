using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    interface IBasicDb <T> where T : IPOCO
    {
        void Add(T t);

        T Get();

        List<T> GetAll();

        void Remove(long id);
    }
}
