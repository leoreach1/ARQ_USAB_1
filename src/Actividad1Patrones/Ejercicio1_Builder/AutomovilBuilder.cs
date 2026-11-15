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

        public AutomovilBuilder SetMotor(string motor)
        {
            Motor = Validar(motor, nameof(motor));
            return this;
        }

        public AutomovilBuilder SetColor(string color)
        {
            Color = Validar(color, nameof(color));
            return this;
        }

        public AutomovilBuilder SetLlantas(string llantas)
        {
            Llantas = Validar(llantas, nameof(llantas));
            return this;
        }

        public AutomovilBuilder SetSistemaSonido(string sonido)
        {
            SistemaSonido = Validar(sonido, nameof(sonido));
            return this;
        }

        public AutomovilBuilder SetInteriores(string interiores)
        {
            Interiores = Validar(interiores, nameof(interiores));
            return this;
        }

        public AutomovilBuilder ConTechoSolar()
        {
            TieneTechoSolar = true;
            return this;
        }

        public AutomovilBuilder ConGps()
        {
            TieneGps = true;
            return this;
        }

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
