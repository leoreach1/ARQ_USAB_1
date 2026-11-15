namespace Ejercicio3_Mediator
{
    /// <summary>
    /// Contrato del mediador: único punto de comunicación entre los usuarios.
    /// </summary>
    public interface IChatMediator
    {
        void RegistrarUsuario(Usuario usuario);
        void EliminarUsuario(Usuario usuario);
        void EnviarMensaje(string mensaje, Usuario emisor);
    }
}
