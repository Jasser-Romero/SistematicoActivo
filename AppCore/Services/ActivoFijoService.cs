using AppCore.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.Services
{
    public class ActivoFijoService : IActivoFijoService
    {
        private IActivoFijoService activoFijoService;

        public ActivoFijoService(IActivoFijoService activoFijoService)
        {
            this.activoFijoService = activoFijoService;
        }

        public void Create(ActivoFijo t)
        {
            activoFijoService.Create(t);
        }

        public ActivoFijo[] FindAll()
        {
            return activoFijoService.FindAll();
        }

        public int GetLastActivoFijoID()
        {
            return activoFijoService.GetLastActivoFijoID();
        }
    }
}
