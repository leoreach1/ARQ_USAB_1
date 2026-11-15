using System;
using System.Collections.Generic;

namespace Ejercicio3_Mediator
{
    /// <summary>
    /// Mediador concreto: administra los miembros de la sala y difunde los mensajes.
    /// </summary>
    public sealed class SalaChatMediator : IChatMediator
    {
        private readonly string _nombreSala;
        private readonly List<Usuario> _usuarios = new List<Usuario>();

        public SalaChatMediator(string nombreSala)
        {
            _nombreSala = nombreSala ?? throw new ArgumentNullException(nameof(nombreSala));
        }

        public void RegistrarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (!_usuarios.Contains(usuario))
            {
                _usuarios.Add(usuario);
                Console.WriteLine($"[Sala '{_nombreSala}'] -> {usuario.Nombre} se unió al chat.");
            }
        }

        public void EliminarUsuario(Usuario usuario)
        {
            if (usuario == null) throw new ArgumentNullException(nameof(usuario));

            if (_usuarios.Remove(usuario))
            {
                Console.WriteLine($"[Sala '{_nombreSala}'] <- {usuario.Nombre} salió del chat.");
            }
        }

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
