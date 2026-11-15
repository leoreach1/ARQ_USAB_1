namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: advertencia preventiva.</summary>
    public sealed class NotificacionAdvertencia : Notificacion
    {
        public NotificacionAdvertencia(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("Advertencia del Sistema", $"[Precaución] {mensaje}");
        }
    }
}
