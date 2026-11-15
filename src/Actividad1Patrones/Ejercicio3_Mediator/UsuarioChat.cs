using System;

namespace Ejercicio3_Mediator
{
    /// <summary>Colega concreto: participante de la sala de chat.</summary>
    public sealed class UsuarioChat : Usuario
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UsuarioChat"/>.
        /// </summary>
        /// <param name="mediator">Mediador de la sala de chat.</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="mediator"/> o <paramref name="nombre"/> son nulos.</exception>
        public UsuarioChat(IChatMediator mediator, string nombre) : base(mediator, nombre) { }

        /// <summary>
        /// Envía un mensaje a través del mediador, que se encargará de difundirlo a todos los usuarios registrados.
        /// </summary>
        /// <param name="mensaje">Mensaje a enviar.</param>
        public override void Enviar(string mensaje)
        {
            _mediator.EnviarMensaje(mensaje, this);
        }

        /// <summary>
        /// Recibe un mensaje del mediador.
        /// </summary>
        /// <param name="mensaje">Mensaje recibido.</param>
        /// <param name="emisor">Usuario que envió el mensaje.</param>
        public override void Recibir(string mensaje, string emisor)
        {
            Console.WriteLine($"   -> Pantalla de {_nombre} | Mensaje de {emisor}: {mensaje}");
        }
    }
}
