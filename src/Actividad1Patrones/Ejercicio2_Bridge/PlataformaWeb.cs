using System;

namespace Ejercicio2_Bridge
{
    /// <summary>Implementador concreto: notificación tipo toast en el navegador.</summary>
    public sealed class PlataformaWeb : IPlataformaVisualizacion
    {
        /// <summary>
        /// Renderiza la notificación como un toast HTML5 en el navegador web.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="cuerpo"></param>
        public void Renderizar(string titulo, string cuerpo)
        {
            Console.WriteLine($"[WEB - Toast HTML5] <h4>{titulo}</h4><p>{cuerpo}</p>");
        }
    }
}
