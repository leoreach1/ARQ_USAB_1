using System;

namespace Ejercicio2_Bridge
{
    /// <summary>Implementador concreto: banner del sistema operativo.</summary>
    public sealed class PlataformaEscritorio : IPlataformaVisualizacion
    {
        /// <summary>
        /// Renderiza la notificación en un banner del sistema operativo.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="cuerpo"></param>
        public void Renderizar(string titulo, string cuerpo)
        {
            Console.WriteLine($"[ESCRITORIO - Banner SO] *** {titulo} *** : {cuerpo}");
        }
    }
}
