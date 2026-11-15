using System;
using System.Text;
using Ejercicio1_Builder;
using Ejercicio2_Bridge;
using Ejercicio3_Mediator;

namespace Actividad1Patrones
{
    /// <summary>
    /// Punto de entrada único. Sin argumentos ejecuta los tres ejercicios;
    /// con 1, 2 o 3 ejecuta solo ese ejercicio (ej.: dotnet run -- 2).
    /// </summary>
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string opcion = args.Length > 0 ? args[0] : "todos";

            switch (opcion)
            {
                case "1":
                    EjecutarBuilder();
                    break;
                case "2":
                    EjecutarBridge();
                    break;
                case "3":
                    EjecutarMediator();
                    break;
                case "todos":
                    EjecutarBuilder();
                    EjecutarBridge();
                    EjecutarMediator();
                    break;
                default:
                    Console.WriteLine("Uso: dotnet run [-- 1|2|3]");
                    break;
            }
        }

        /// <summary>
        /// Ejecuta el ejercicio 1, que implementa el patrón Builder para la construcción de automóviles
        /// </summary>
        private static void EjecutarBuilder()
        {
            Titulo("EJERCICIO 1: PATRÓN CREACIONAL - BUILDER (AUTOMÓVILES)");

            Automovil autoBasico = new AutomovilBuilder()
                .SetColor("Gris Plata")
                .Build();

            Automovil autoFull = new AutomovilBuilder()
                .SetMotor("Híbrido Turbo 2.5L")
                .SetColor("Azul Noche")
                .SetLlantas("Rin 19 Deportivas")
                .SetSistemaSonido("Bose 12 parlantes")
                .SetInteriores("Cuero Nappa")
                .ConTechoSolar()
                .ConGps()
                .Build();

            Console.WriteLine("Configuración 1 (omitiendo opcionales): " + autoBasico);
            Console.WriteLine("Configuración 2 (personalizado completo): " + autoFull);

            // Inmutabilidad: la siguiente línea no compila (error CS0200) porque
            // las propiedades de Automovil no tienen descriptor 'set'.
            // autoFull.Color = "Rojo";

            try
            {
                new AutomovilBuilder().SetMotor("   ").Build();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Configuración 3 (opción vacía) rechazada: " + ex.Message);
            }
        }


        /// <summary>
        /// Ejecuta el ejercicio 2, que implementa el patrón Bridge para enviar notificaciones
        /// </summary>
        private static void EjecutarBridge()
        {
            Titulo("EJERCICIO 2: PATRÓN ESTRUCTURAL - BRIDGE (NOTIFICACIONES)");

            IPlataformaVisualizacion web = new PlataformaWeb();
            IPlataformaVisualizacion movil = new PlataformaMovil();
            IPlataformaVisualizacion escritorio = new PlataformaEscritorio();

            Notificacion mensaje = new NotificacionMensaje(movil);
            mensaje.Enviar("Camilo comentó en el documento de la actividad.");

            Notificacion alerta = new NotificacionAlerta(web);
            alerta.Enviar("Uso de CPU al 95% en servidor de producción.");

            // Cambio de plataforma en tiempo de ejecución sobre el mismo objeto.
            alerta.CambiarPlataforma(movil);
            alerta.Enviar("Uso de CPU al 95% en servidor de producción.");

            Notificacion advertencia = new NotificacionAdvertencia(escritorio);
            advertencia.Enviar("Su sesión expirará en 5 minutos.");

            Notificacion confirmacion = new NotificacionConfirmacion(web);
            confirmacion.Enviar("Orden #4589 procesada exitosamente.");
        }

        /// <summary>
        /// Ejecuta el ejercicio 3, que implementa el patrón Mediator para un chat grupal
        /// </summary>
        private static void EjecutarMediator()
        {
            Titulo("EJERCICIO 3: PATRÓN DE COMPORTAMIENTO - MEDIATOR (CHAT GRUPAL)");

            IChatMediator sala = new SalaChatMediator("Arquitectura de Software - Grupo 2");

            Usuario leonardo = new UsuarioChat(sala, "Leonardo");
            Usuario camilo = new UsuarioChat(sala, "Camilo");
            Usuario cristian = new UsuarioChat(sala, "Cristian");

            sala.RegistrarUsuario(leonardo);
            sala.RegistrarUsuario(camilo);
            sala.RegistrarUsuario(cristian);

            leonardo.Enviar("Hola equipo, ya subí los diagramas UML corregidos.");
            camilo.Enviar("Perfecto, yo ejecuto las pruebas en C# ahora mismo.");

            // Baja dinámica de un usuario sin afectar a los demás.
            Console.WriteLine();
            sala.EliminarUsuario(cristian);

            leonardo.Enviar("Listo para consolidar el entregable final.");
            cristian.Enviar("¿Siguen ahí?");
        }
        
        /// <summary>
        /// Muestra un título con líneas de separación en la consola
        /// </summary>
        /// <param name="texto"></param>
        private static void Titulo(string texto)
        {
            string linea = new string('=', 66);
            Console.WriteLine();
            Console.WriteLine(linea);
            Console.WriteLine(texto);
            Console.WriteLine(linea);
        }
    }
}
