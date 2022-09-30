using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorks2019BE.Entity
{
    public class BaseEntity<T>
    {
        public T _Id { get; set; }
        public string _Tabella { get; set; }
        public List<string> _ChiavePrimaria { get; set; }

    }
}
