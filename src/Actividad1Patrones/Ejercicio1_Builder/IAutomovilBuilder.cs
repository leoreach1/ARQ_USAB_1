namespace PatronesDiseno.Ejercicio1
{
    /// <summary>
    /// Contrato GoF del Builder. Define las operaciones de configuración
    /// y el método terminal <see cref="Build"/> que materializa el producto.
    /// Desacopla al cliente de la implementación concreta del builder,
    /// permitiendo intercambiar estrategias de construcción en el futuro
    /// (ej. AutomovilElectricoBuilder, AutomovilDeportivoCOnfigurador, etc.)
    /// sin modificar el código de los clientes (OCP – Open/Closed Principle).
    /// </summary>
    public interface IAutomovilBuilder
    {
        IAutomovilBuilder SetMotor(string motor);
        IAutomovilBuilder SetColor(string color);
        IAutomovilBuilder SetLlantas(string llantas);
        IAutomovilBuilder SetSistemaSonido(string sonido);
        IAutomovilBuilder SetInteriores(string interiores);
        IAutomovilBuilder ConTechoSolar();
        IAutomovilBuilder ConGps();

        /// <summary>Construye y devuelve el objeto <see cref="Automovil"/> inmutable.</summary>
        Automovil Build();
    }
}
