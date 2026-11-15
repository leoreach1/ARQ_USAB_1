using System;

namespace PatronesDiseno.Ejercicio1
{
    /// <summary>
    /// Builder concreto con interfaz fluida (<i>fluent interface</i>).
    /// <para>
    /// Mantiene el estado mutable temporal durante la configuración;
    /// cada propiedad arranca con un valor por defecto sensato, de modo que
    /// el cliente solo necesita especificar las opciones que desea personalizar
    /// (patrón "optional-parameter builder", alternativa limpia al constructor
    /// telescópico).
    /// </para>
    /// <para>
    /// La visibilidad <c>internal</c> de las propiedades impide que código
    /// externo al ensamblado acceda al estado intermedio del builder y garantiza
    /// que únicamente <see cref="Automovil"/> pueda leer esos valores.
    /// </para>
    /// </summary>
    public sealed class AutomovilBuilder : IAutomovilBuilder
    {
        // ── Estado interno (mutable durante la construcción) ────────────────
        internal string Motor         { get; private set; } = "Gasolina 1.6L Estándar";
        internal string Color         { get; private set; } = "Blanco";
        internal string Llantas       { get; private set; } = "Rin 16 Aleación";
        internal string SistemaSonido { get; private set; } = "Básico 4 parlantes";
        internal string Interiores    { get; private set; } = "Tela";
        internal bool   TieneTechoSolar { get; private set; }
        internal bool   TieneGps        { get; private set; }

        // ── Métodos fluidos de configuración ───────────────────────────────

        /// <inheritdoc/>
        public IAutomovilBuilder SetMotor(string motor)
        {
            Motor = Validar(motor, nameof(motor));
            return this;
        }

        /// <inheritdoc/>
        public IAutomovilBuilder SetColor(string color)
        {
            Color = Validar(color, nameof(color));
            return this;
        }

        /// <inheritdoc/>
        public IAutomovilBuilder SetLlantas(string llantas)
        {
            Llantas = Validar(llantas, nameof(llantas));
            return this;
        }

        /// <inheritdoc/>
        public IAutomovilBuilder SetSistemaSonido(string sonido)
        {
            SistemaSonido = Validar(sonido, nameof(sonido));
            return this;
        }

        /// <inheritdoc/>
        public IAutomovilBuilder SetInteriores(string interiores)
        {
            Interiores = Validar(interiores, nameof(interiores));
            return this;
        }

        /// <inheritdoc/>
        public IAutomovilBuilder ConTechoSolar()
        {
            TieneTechoSolar = true;
            return this;
        }

        /// <inheritdoc/>
        public IAutomovilBuilder ConGps()
        {
            TieneGps = true;
            return this;
        }

        // ── Método terminal ─────────────────────────────────────────────────

        /// <summary>
        /// Materializa el <see cref="Automovil"/> con la configuración acumulada.
        /// A partir de este punto el objeto producto es inmutable.
        /// </summary>
        public Automovil Build() => new Automovil(this);

        // ── Helpers privados ────────────────────────────────────────────────

        /// <summary>
        /// Garantiza que ninguna opción textual quede vacía o en blanco,
        /// previniendo objetos en estado inconsistente ("Fail Fast").
        /// </summary>
        private static string Validar(string valor, string nombreParametro)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("La opción no puede estar vacía.", nombreParametro);

            return valor.Trim();
        }
    }
}
