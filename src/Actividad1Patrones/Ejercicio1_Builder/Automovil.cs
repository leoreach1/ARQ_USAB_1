namespace PatronesDiseno.Ejercicio1
{
    /// <summary>
    /// Producto final del patrón Builder.
    /// Es inmutable: todas sus propiedades son de solo lectura
    /// y se inicializan una única vez desde <see cref="AutomovilBuilder"/>.
    /// Un cliente externo NO puede instanciar directamente esta clase
    /// (constructor internal), lo que garantiza que toda creación pase
    /// por el flujo controlado del Builder.
    /// </summary>
    public sealed class Automovil
    {
        // ── Propiedades de solo lectura (get-only) ──────────────────────────
        public string Motor          { get; }
        public string Color          { get; }
        public string Llantas        { get; }
        public string SistemaSonido  { get; }
        public string Interiores     { get; }
        public bool   TieneTechoSolar { get; }
        public bool   TieneGps       { get; }

        // ── Constructor internal: solo AutomovilBuilder puede crear instancias ──
        internal Automovil(AutomovilBuilder builder)
        {
            Motor           = builder.Motor;
            Color           = builder.Color;
            Llantas         = builder.Llantas;
            SistemaSonido   = builder.SistemaSonido;
            Interiores      = builder.Interiores;
            TieneTechoSolar = builder.TieneTechoSolar;
            TieneGps        = builder.TieneGps;
        }

        public override string ToString() =>
            $"Automóvil [" +
            $"Motor: {Motor} | " +
            $"Color: {Color} | " +
            $"Llantas: {Llantas} | " +
            $"Sonido: {SistemaSonido} | " +
            $"Interiores: {Interiores} | " +
            $"Techo solar: {(TieneTechoSolar ? "Sí" : "No")} | " +
            $"GPS: {(TieneGps ? "Sí" : "No")}]";
    }
}
