using System;

namespace Ejercicio3_Mediator
{
    /// <summary>
    /// Colega abstracto: conoce únicamente la interfaz del mediador,
    /// nunca a otros usuarios.
    /// </summary>
    public abstract class Usuario
    {
        /// <summary>
        /// Referencia al mediador que administra la comunicación entre los usuarios.
        /// </summary>
        protected readonly IChatMediator _mediator;
        /// <summary>
        /// Nombre del usuario, utilizado para identificar los mensajes en la consola.
        /// </summary>
        protected readonly string _nombre;

        /// <summary>
        /// Obtiene el nombre del usuario.
        /// </summary>
        public string Nombre => _nombre;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        /// <param name="mediator">Mediador de la sala de chat.</param>
        /// <param name="nombre">Nombre del usuario.</param>
        /// <exception cref="ArgumentNullException">Se lanza si <paramref name="mediator"/> o <paramref name="nombre"/> son nulos.</exception>
        protected Usuario(IChatMediator mediator, string nombre)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        }

        /// <summary>
        /// Envía un mensaje a través del mediador, que se encargará de difundirlo a todos los usuarios registrados.
        /// </summary>
        /// <param name="mensaje"></param>  
        public abstract void Enviar(string mensaje);

        /// <summary>
        /// Recibe un mensaje del mediador.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="emisor"></param>
        public abstract void Recibir(string mensaje, string emisor);
    }
}
