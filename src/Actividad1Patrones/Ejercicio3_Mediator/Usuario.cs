using System;

namespace Ejercicio3_Mediator
{
    /// <summary>
    /// Colega abstracto: conoce únicamente la interfaz del mediador,
    /// nunca a otros usuarios.
    /// </summary>
    public abstract class Usuario
    {
        protected readonly IChatMediator _mediator;
        protected readonly string _nombre;

        public string Nombre => _nombre;

        protected Usuario(IChatMediator mediator, string nombre)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }

        public abstract void Enviar(string mensaje);
        public abstract void Recibir(string mensaje, string emisor);
    }
}
