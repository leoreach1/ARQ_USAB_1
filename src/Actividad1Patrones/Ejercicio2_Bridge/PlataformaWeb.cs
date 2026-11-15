using System;

namespace Ejercicio2_Bridge
{
    /// <summary>Implementador concreto: notificación tipo toast en el navegador.</summary>
    public sealed class PlataformaWeb : IPlataformaVisualizacion
    {
        public void Renderizar(string titulo, string cuerpo)
        {
            Console.WriteLine($"[WEB - Toast HTML5] <h4>{titulo}</h4><p>{cuerpo}</p>");
        }
    }
}
