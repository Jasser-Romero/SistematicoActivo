using Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infraestructure
{
    public class Depreciacion
    {
        public decimal[] Depreciar(ActivoFijo af)
        {
            switch (af.MetodoDepreciacion)
            {
                case MetodoDepreciacion.LineaRecta:
                    return DepreciacionLineaRecta(af);
                case MetodoDepreciacion.SDAIncremental:
                    return DepreciacionSDA(af);
            }

            return null;
        }
        private decimal[] DepreciacionLineaRecta(ActivoFijo activoFijo)
        {
            int vidaUtil = VidaUtil(activoFijo.TipoActivo);
            return Enumerable.Repeat(activoFijo.Valor / vidaUtil, vidaUtil).ToArray();
        }

        private decimal[] DepreciacionSDA(ActivoFijo activoFijo)
        {
            return null;
        }

        private int VidaUtil(TipoActivoFijo tipoActivoFijo)
        {
            switch (tipoActivoFijo)
            {
                case TipoActivoFijo.Edificio:
                    return 20;
                case TipoActivoFijo.Vehiculo:
                    return 5;
                case TipoActivoFijo.Maquinaria:
                    return 3;
                case TipoActivoFijo.Mobiliario:
                    return 2;
                case TipoActivoFijo.EquipoComputo:
                    return 1;
                default:
                    throw new ArgumentException("Tipo de activo fijo no existe.");
            }
        }
    }
}
