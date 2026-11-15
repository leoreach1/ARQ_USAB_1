namespace Ejercicio2_Bridge
{
    /// <summary>Abstracción refinada: alerta que exige atención inmediata.</summary>
    public sealed class NotificacionAlerta : Notificacion
    {
        public NotificacionAlerta(IPlataformaVisualizacion plataforma) : base(plataforma) { }

        public override void Enviar(string mensaje)
        {
            _plataforma.Renderizar("ALERTA CRÍTICA", $"[Atención inmediata] {mensaje}");
        }
    }
}
