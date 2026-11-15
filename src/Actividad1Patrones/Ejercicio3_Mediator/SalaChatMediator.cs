using System;
using System.Collections.Generic;

namespace Ejercicio3_Mediator
{
    /// <summary>
    /// Mediador concreto: administra los miembros de la sala y difunde los mensajes.
    /// </summary>
    public sealed class SalaChatMediator : IChatMediator
    {
        /// <summary>
        /// Nombre de la sala de chat, utilizado para identificar los mensajes en la consola.
        /// </summary>
        private readonly string _nombreSala;

        /// <summary>
        /// Lista de usuarios registrados en la sala de chat. El mediador mantiene esta lista para poder difundir los mensajes a todos los miembros.
        /// </summary>
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SalaChatMediator"/>.
        /// </summary>
        /// <param name="nombreSala">Nombre de la sala de chat.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="nombreSala"/> es nulo.</exception>
        public SalaChatMediator(string nombreSala)
        {
            _nombreSala = nombreSala ?? throw new ArgumentNullException(nameof(nombreSala));
        }

        /// <summary>
        /// Registra un usuario en la sala de chat para que pueda enviar y recibir mensajes a través del mediador.
        /// </summary>
        /// <param name="usuario">Usuario a registrar.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="usuario"/> es nulo.</exception>
        public void RegistrarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (!_usuarios.Contains(usuario))
            {
                _usuarios.Add(usuario);
                Console.WriteLine($"[Sala '{_nombreSala}'] -> {usuario.Nombre} se unió al chat.");
            }
        }

        /// <summary>
        /// Elimina un usuario de la sala de chat.
        /// </summary>
        /// <param name="usuario">Usuario a eliminar.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="usuario"/> es nulo.</exception>
        public void EliminarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (_usuarios.Remove(usuario))
            {
                Console.WriteLine($"[Sala '{_nombreSala}'] <- {usuario.Nombre} salió del chat.");
            }
        }

        /// <summary>
        /// Envía un mensaje a todos los usuarios registrados en la sala de chat.
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar.</param>
        /// <param name="emisor">Usuario que envía el mensaje.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="mensaje"/> o <paramref name="emisor"/> son nulos.</exception>
        public void EnviarMensaje(string mensaje, Usuario emisor)
        {
            if (emisor == null) throw new ArgumentNullException(nameof(emisor));

            // Solo los miembros de la sala pueden escribir en ella.
            if (!_usuarios.Contains(emisor))
            {
                Console.WriteLine($"\n[{_nombreSala}] {emisor.Nombre} no pertenece a la sala; mensaje descartado.");
                return;
            }

            Console.WriteLine($"\n[{_nombreSala}] {emisor.Nombre} envía: \"{mensaje}\"");

            foreach (Usuario usuario in _usuarios)
            {
                // El emisor no recibe su propio mensaje.
                if (usuario != emisor)
                {
                    usuario.Recibir(mensaje, emisor.Nombre);
                }
            }
        }
    }
}
