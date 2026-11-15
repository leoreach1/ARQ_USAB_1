namespace Ejercicio1_Builder
{
    /// <summary>
    /// Producto del patrón Builder. Es inmutable: sus propiedades solo tienen
    /// descriptor <c>get</c> y se asignan una única vez en el constructor.
    /// </summary>
    public sealed class Automovil
    {
        public string Motor { get; }
        public string Color { get; }
        public string Llantas { get; }
        public string SistemaSonido { get; }
        public string Interiores { get; }
        public bool TieneTechoSolar { get; }
        public bool TieneGps { get; }

        // Constructor 'internal': un cliente externo al ensamblado no puede crear
        // un Automovil sin pasar por AutomovilBuilder.
        internal Automovil(AutomovilBuilder builder)
        {
            Motor = builder.Motor;
            Color = builder.Color;
            Llantas = builder.Llantas;
            SistemaSonido = builder.SistemaSonido;
            Interiores = builder.Interiores;
            TieneTechoSolar = builder.TieneTechoSolar;
            TieneGps = builder.TieneGps;
        }

        /// <summary>
        /// Devuelve una representación en cadena del objeto Automovil, mostrando sus propiedades y valores.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Automóvil [Motor: {Motor} | Color: {Color} | Llantas: {Llantas} | " +
                   $"Sonido: {SistemaSonido} | Interiores: {Interiores} | " +
                   $"Techo solar: {(TieneTechoSolar ? "Sí" : "No")} | GPS: {(TieneGps ? "Sí" : "No")}]";
        }
    }
}
