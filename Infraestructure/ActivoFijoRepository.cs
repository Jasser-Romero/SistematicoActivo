using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infraestructure
{
    public class ActivoFijoRepository : IActivoFijoRepository
    {
        private ActivoFijo[] activoFijos;

        public void Create(ActivoFijo activoFijo)
        {
            if (activoFijos == null)
            {
                activoFijos = new ActivoFijo[1];
                activoFijos[activoFijos.Length - 1] = activoFijo;
                return;
            }

            ActivoFijo[] temp = new ActivoFijo[activoFijos.Length + 1];
            Array.Copy(activoFijos, temp, activoFijos.Length);

            temp[temp.Length - 1] = activoFijo;
            activoFijos = temp;
        }

        public ActivoFijo[] FindAll()
        {
            return activoFijos;
        }

        public int GetLastActivoFijoID()
        {
            return (activoFijos == null) ? 0 : activoFijos[activoFijos.Length - 1].Id;
        }
    }
}
