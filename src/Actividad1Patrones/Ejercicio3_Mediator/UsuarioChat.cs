using System;

namespace Ejercicio3_Mediator
{
    /// <summary>Colega concreto: participante de la sala de chat.</summary>
    public sealed class UsuarioChat : Usuario
    {
        public UsuarioChat(IChatMediator mediator, string nombre) : base(mediator, nombre) { }

        public override void Enviar(string mensaje)
        {
            _mediator.EnviarMensaje(mensaje, this);
        }

        public override void Recibir(string mensaje, string emisor)
        {
            Console.WriteLine($"   -> Pantalla de {_nombre} | Mensaje de {emisor}: {mensaje}");
        }
    }
}
