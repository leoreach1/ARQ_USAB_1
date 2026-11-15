using System;

namespace Ejercicio2_Bridge
{
    /// <summary>Implementador concreto: banner del sistema operativo.</summary>
    public sealed class PlataformaEscritorio : IPlataformaVisualizacion
    {
        public void Renderizar(string titulo, string cuerpo)
        {
            Console.WriteLine($"[ESCRITORIO - Banner SO] *** {titulo} *** : {cuerpo}");
        }
    }
}
