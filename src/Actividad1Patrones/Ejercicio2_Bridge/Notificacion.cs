using System;

namespace Ejercicio2_Bridge
{
    /// <summary>
    /// Abstracción del Bridge: define qué se notifica y delega la visualización
    /// en la plataforma que recibe por constructor.
    /// </summary>
    public abstract class Notificacion
    {
        protected IPlataformaVisualizacion _plataforma;

        protected Notificacion(IPlataformaVisualizacion plataforma)
        {
            _plataforma = plataforma ?? throw new ArgumentNullException(nameof(plataforma));
        }

        // Cambia la plataforma en tiempo de ejecución sin crear otra notificación.
        public void CambiarPlataforma(IPlataformaVisualizacion nuevaPlataforma)
        {
            _plataforma = nuevaPlataforma ?? throw new ArgumentNullException(nameof(nuevaPlataforma));
        }

        public abstract void Enviar(string mensaje);
    }
}
