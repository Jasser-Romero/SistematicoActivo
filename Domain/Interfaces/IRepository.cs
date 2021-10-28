using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IRepository<T>
    {
        void Create(ActivoFijo af);

        T[] FindAll();
    }
}
