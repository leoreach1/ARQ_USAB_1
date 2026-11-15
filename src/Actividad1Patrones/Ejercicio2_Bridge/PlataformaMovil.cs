using System;

namespace Ejercicio2_Bridge
{
    /// <summary>Implementador concreto: notificación push en el dispositivo móvil.</summary>
    public sealed class PlataformaMovil : IPlataformaVisualizacion
    {
        /// <summary>
        /// Renderiza la notificación como una notificación push en el dispositivo móvil.
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="cuerpo"></param>
        public void Renderizar(string titulo, string cuerpo)
        {
            Console.WriteLine($"[MÓVIL - Push Notification] ({titulo.ToUpper()}) -> {cuerpo}");
        }
    }
}
