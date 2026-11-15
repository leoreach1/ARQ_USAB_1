namespace Ejercicio2_Bridge
{
    /// <summary>
    /// Implementador del Bridge: define cómo y dónde se muestra una notificación.
    /// </summary>
    public interface IPlataformaVisualizacion
    {
        void Renderizar(string titulo, string cuerpo);
    }
}
