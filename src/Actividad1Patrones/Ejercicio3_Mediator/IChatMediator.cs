namespace Ejercicio3_Mediator
{
    /// <summary>
    /// Contrato del mediador: único punto de comunicación entre los usuarios.
    /// </summary>
    public interface IChatMediator
    {
        /// <summary>
        /// Registra un usuario en el chat para que pueda enviar y recibir mensajes a través del mediador.
        /// </summary>
        /// <param name="usuario"></param>
        void RegistrarUsuario(Usuario usuario);
        
        /// <summary>
        /// Elimina un usuario del chat.
        /// </summary>
        /// <param name="usuario"></param>
        void EliminarUsuario(Usuario usuario);

        /// <summary>
        /// Envía un mensaje a todos los usuarios registrados en el chat.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="emisor"></param>
        void EnviarMensaje(string mensaje, Usuario emisor);
    }
}
