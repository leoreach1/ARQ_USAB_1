using System;

namespace Ejercicio2_Bridge
{
    /// <summary>
    /// Abstracción del Bridge: define qué se notifica y delega la visualización
    /// en la plataforma que recibe por constructor.
    /// </summary>
    public abstract class Notificacion
    {
        /// <summary>
        /// Referencia a la implementación concreta del Bridge, que define cómo se visualiza la notificación.
        /// </summary>
        protected IPlataformaVisualizacion _plataforma;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Notificacion"/>.
        /// </summary>
        /// <param name="plataforma"></param>
        /// <exception cref="ArgumentNullException"></exception>
        protected Notificacion(IPlataformaVisualizacion plataforma)
        {
            _plataforma = plataforma ?? throw new ArgumentNullException(nameof(plataforma));
        }

        /// <summary>
        /// Cambia la plataforma de visualización de la notificación en tiempo de ejecución.
        /// </summary>
        /// <param name="nuevaPlataforma"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CambiarPlataforma(IPlataformaVisualizacion nuevaPlataforma)
        {
            _plataforma = nuevaPlataforma ?? throw new ArgumentNullException(nameof(nuevaPlataforma));
        }

        /// <summary>
        /// Envía la notificación utilizando la plataforma de visualización configurada.
        /// </summary>
        /// <param name="mensaje"></param>
        public abstract void Enviar(string mensaje);
    }
}
