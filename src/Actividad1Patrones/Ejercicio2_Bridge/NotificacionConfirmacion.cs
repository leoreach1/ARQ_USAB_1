namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: confirmación de una operación.</summary>
    public sealed class NotificacionConfirmacion : Notificacion
    {
        public NotificacionConfirmacion(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("Operación Confirmada", $"[OK] {mensaje}");
        }
    }
}
