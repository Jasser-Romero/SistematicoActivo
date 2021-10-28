using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore.Interfaces;
using AppCore.Services;
using Autofac;
using Domain.Interfaces;
using Infraestructure;

namespace ActivosFijos
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ActivoFijoRepository>().As<IActivoFijoRepository>();
            builder.RegisterType<ActivoFijoService>().As<IActivoFijoService>();

            var container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmGestionActivos(container.Resolve<IActivoFijoService>()));
        }
    }
}
