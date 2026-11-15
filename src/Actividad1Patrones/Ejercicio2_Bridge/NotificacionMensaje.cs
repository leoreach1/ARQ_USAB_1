namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: mensaje informativo.</summary>
    public sealed class NotificacionMensaje : Notificacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotificacionMensaje"/>.
        /// </summary>      
        public NotificacionMensaje(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        /// <summary>
        /// Envía la notificación de mensaje utilizando la plataforma de visualización configurada.
        /// </summary>
        /// <param name="mensaje"></param>
        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("Nuevo Mensaje", mensaje);
        }
    }
}
