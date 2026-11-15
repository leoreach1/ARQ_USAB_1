namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: confirmación de una operación.</summary>
    public sealed class NotificacionConfirmacion : Notificacion
    {   
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotificacionConfirmacion"/>.
        /// </summary>
        /// <param name="plataforma"></param>           
        public NotificacionConfirmacion(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        /// <summary>
        /// Envía la notificación de confirmación utilizando la plataforma de visualización configurada.
        /// </summary>
        /// <param name="mensaje"></param>
        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("Operación Confirmada", $"[OK] {mensaje}");
        }
    }
}
