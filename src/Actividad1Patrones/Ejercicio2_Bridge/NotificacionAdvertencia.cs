namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: advertencia preventiva.</summary>
    public sealed class NotificacionAdvertencia : Notificacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotificacionAdvertencia"/>.
        /// </summary>
        /// <param name="plataforma"></param>
        public NotificacionAdvertencia(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        /// <summary>
        /// Envía la notificación de advertencia utilizando la plataforma de visualización configurada.
        /// </summary>
        /// <param name="mensaje"></param>
        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("Advertencia del Sistema", $"[Precaución] {mensaje}");
        }
    }
}
