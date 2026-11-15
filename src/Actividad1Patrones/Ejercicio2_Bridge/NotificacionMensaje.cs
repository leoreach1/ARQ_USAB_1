namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: mensaje informativo.</summary>
    public sealed class NotificacionMensaje : Notificacion
    {
        public NotificacionMensaje(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("Nuevo Mensaje", mensaje);
        }
    }
}
