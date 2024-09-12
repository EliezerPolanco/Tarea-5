using System;
using System.Collections.Generic;
using System.Linq;

class Programa
{
    class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }

    static List<Cliente> clientes = new List<Cliente>();
    static int siguienteId = 1;

    static void Main()
    {
        PrecargarClientes();

        int opcion;
        do
        {
            Console.WriteLine("\n*** Registro de clientes del Gimnasio ***");
            Console.WriteLine("1. Dar de alta un cliente");
            Console.WriteLine("2. Mostrar detalles de un cliente");
            Console.WriteLine("3. Listar clientes");
            Console.WriteLine("4. Buscar cliente (Nombre)");
            Console.WriteLine("5. Dar de baja un cliente");
            Console.WriteLine("6. Modificar un cliente");
            Console.WriteLine("7. Salir");
            Console.Write("Opción: ");

            if (int.TryParse(Console.ReadLine(), out opcion))
                EjecutarOpcion(opcion);
            else
                Console.WriteLine("Por favor, ingrese un número válido.");

        } while (opcion != 7);
    }

    static void PrecargarClientes()
    {
        clientes.Add(new Cliente { Id = siguienteId++, Nombre = "Carlos Pérez", Telefono = "123456789", Email = "carlos@gmail.com" });
        clientes.Add(new Cliente { Id = siguienteId++, Nombre = "Ana García", Telefono = "987654321", Email = "ana@hotmail.com" });
        clientes.Add(new Cliente { Id = siguienteId++, Nombre = "Luis Martínez", Telefono = "555666777", Email = "luis@yahoo.com" });
    }

    static void EjecutarOpcion(int opcion)
    {
        switch (opcion)
        {
            case 1:
                Console.WriteLine("Nombre: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Teléfono: ");
                string telefono = Console.ReadLine();
                Console.WriteLine("Email: ");
                string email = Console.ReadLine();
                clientes.Add(new Cliente { Id = siguienteId++, Nombre = nombre, Telefono = telefono, Email = email });
                Console.WriteLine("Cliente registrado.");
                break;

            case 2:
                Console.Write("ID del cliente: ");
                if (int.TryParse(Console.ReadLine(), out int id) && clientes.Any(c => c.Id == id))
                    MostrarCliente(clientes.FirstOrDefault(c => c.Id == id));
                else
                    Console.WriteLine("ID no encontrado.");
                break;

            case 3:
                foreach (var c in clientes) MostrarCliente(c);
                break;

            case 4:
                Console.Write("Nombre del cliente: ");
                string busqueda = Console.ReadLine().ToLower();
                var resultados = clientes.Where(c => c.Nombre.ToLower().Contains(busqueda)).ToList();
                if (resultados.Any()) foreach (var c in resultados) MostrarCliente(c);
                else Console.WriteLine("No se encontraron clientes.");
                break;

            case 5:
                Console.Write("ID del cliente a eliminar: ");
                if (int.TryParse(Console.ReadLine(), out int idEliminar) && clientes.Any(c => c.Id == idEliminar))
                {
                    clientes.RemoveAll(c => c.Id == idEliminar);
                    Console.WriteLine("Cliente eliminado.");
                }
                else
                    Console.WriteLine("ID no encontrado.");
                break;

            case 6:
                Console.Write("ID del cliente a modificar: ");
                if (int.TryParse(Console.ReadLine(), out int idModificar) && clientes.Any(c => c.Id == idModificar))
                {
                    var cliente = clientes.FirstOrDefault(c => c.Id == idModificar);
                    Console.Write("Nuevo nombre (actual: {0}): ", cliente.Nombre);
                    string nuevoNombre = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoNombre)) cliente.Nombre = nuevoNombre;

                    Console.Write("Nuevo teléfono (actual: {0}): ", cliente.Telefono);
                    string nuevoTelefono = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoTelefono)) cliente.Telefono = nuevoTelefono;

                    Console.Write("Nuevo email (actual: {0}): ", cliente.Email);
                    string nuevoEmail = Console.ReadLine();
                    if (!string.IsNullOrEmpty(nuevoEmail)) cliente.Email = nuevoEmail;

                    Console.WriteLine("Cliente modificado.");
                }
                else
                    Console.WriteLine("ID no encontrado.");
                break;

            case 7:
                Console.WriteLine("Saliendo...");
                break;

            default:
                Console.WriteLine("Opción no válida.");
                break;
        }
    }

    static void MostrarCliente(Cliente c)
    {
        Console.WriteLine($"ID: {c.Id} | Nombre: {c.Nombre} | Teléfono: {c.Telefono} | Email: {c.Email}");
    }
}

