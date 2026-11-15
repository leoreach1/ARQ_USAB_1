namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: alerta que exige atención inmediata.</summary>
    public sealed class NotificacionAlerta : Notificacion
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="NotificacionAlerta"/>.
        /// </summary>
        /// <param name="plataforma"></param>
        public NotificacionAlerta(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        /// <summary>
        /// Envía la notificación de alerta utilizando la plataforma de visualización configurada.
        /// </summary>
        /// <param name="mensaje"></param>
        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("ALERTA CRÍTICA", $"[Atención inmediata] {mensaje}");
        }
    }
}
