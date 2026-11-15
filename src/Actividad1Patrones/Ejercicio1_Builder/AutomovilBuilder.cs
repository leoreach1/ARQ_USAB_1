using System;

namespace Ejercicio1_Builder
{
    /// <summary>
    /// Builder con interfaz fluida. Guarda el estado mutable temporal y los valores
    /// de fábrica; cada opción que el cliente omite conserva su valor por defecto.
    /// </summary>
    public sealed class AutomovilBuilder
    {
        internal string Motor { get; private set; } = "Gasolina 1.6L Estándar";
        internal string Color { get; private set; } = "Blanco";
        internal string Llantas { get; private set; } = "Rin 16 Aleación";
        internal string SistemaSonido { get; private set; } = "Básico 4 parlantes";
        internal string Interiores { get; private set; } = "Tela";
        internal bool TieneTechoSolar { get; private set; }
        internal bool TieneGps { get; private set; }

        /// <summary>
        /// Establece el motor del automóvil. Lanza una excepción si el valor es nulo o vacío.
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        public AutomovilBuilder SetMotor(string motor)
        {
            Motor = Validar(motor, nameof(motor));
            return this;
        }

        /// <summary>
        /// Establece el color del automóvil. Lanza una excepción si el valor es nulo o vacío.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public AutomovilBuilder SetColor(string color)
        {
            Color = Validar(color, nameof(color));
            return this;
        }

        /// <summary>
        /// Establece las llantas del automóvil. Lanza una excepción si el valor es nulo o vacío.
        /// </summary>
        /// <param name="llantas"></param>
        /// <returns></returns>
        public AutomovilBuilder SetLlantas(string llantas)
        {
            Llantas = Validar(llantas, nameof(llantas));
            return this;
        }

        /// <summary>
        /// Establece el sistema de sonido del automóvil. Lanza una excepción si el valor es nulo o vacío.
        /// </summary>
        /// <param name="sonido"></param>
        /// <returns></returns>
        public AutomovilBuilder SetSistemaSonido(string sonido)
        {
            SistemaSonido = Validar(sonido, nameof(sonido));
            return this;
        }

        /// <summary>
        /// Establece los interiores del automóvil. Lanza una excepción si el valor es nulo o vacío.
        /// </summary>
        /// <param name="interiores"></param>
        /// <returns></returns>
        public AutomovilBuilder SetInteriores(string interiores)
        {
            Interiores = Validar(interiores, nameof(interiores));
            return this;
        }

        /// <summary>
        /// Configura el automóvil con un techo solar.
        /// </summary>
        /// <returns></returns>
        public AutomovilBuilder ConTechoSolar()
        {
            TieneTechoSolar = true;
            return this;
        }

        /// <summary>
        /// Configura el automóvil con GPS.
        /// </summary>
        /// <returns></returns>
        public AutomovilBuilder ConGps()
        {
            TieneGps = true;
            return this;
        }

        /// <summary>
        /// Construye el automóvil con las opciones configuradas.
        /// </summary>
        /// <returns></returns>
        public Automovil Build()
        {
            return new Automovil(this);
        }

        // Impide construir un automóvil con una opción vacía (estado inválido).
        private static string Validar(string valor, string nombreParametro)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("La opción no puede estar vacía.", nombreParametro);
            }

            return valor.Trim();
        }
    }
}
