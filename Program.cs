using System;
using System.Collections.Generic;
using System.Linq;

class IdeaDeNegocio
{
    public int Codigo { get; }
    public string Nombre { get; set; }
    public string ImpactoSocialEconomico { get; set; }
    public List<Departamento> DepartamentosBeneficiados { get; set; }
    public decimal ValorInversion { get; set; }
    public decimal IngresosPrimeros3Anios { get; set; }
    public List<IntegranteEquipo> IntegrantesEquipo { get; set; }
    public List<string> Herramientas4RI { get; set; }

    public IdeaDeNegocio(int codigo)
    {
        Codigo = codigo;
        DepartamentosBeneficiados = new List<Departamento>();
        IntegrantesEquipo = new List<IntegranteEquipo>();
        Herramientas4RI = new List<string>();
    }
}

class Departamento
{
    public int Codigo { get; set; }
    public string Nombre { get; set; }
}

class IntegranteEquipo
{
    public string Identificacion { get; set; }
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    public string Rol { get; set; }
    public string Email { get; set; }
}

class Program
{
    static List<IdeaDeNegocio> ideasDeNegocio = new List<IdeaDeNegocio>();

    static void Main()
    {
        int codIdeaDeNegocio = 0;

        while (true)
        {
            Console.WriteLine("MENU:");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("1. Registrar nueva idea de negocio");
            Console.WriteLine("2. Agregar integrantes");
            Console.WriteLine("3. Eliminar integrantes");
            Console.WriteLine("4. Modificar valor de inversión");
            Console.WriteLine("5. Mostrar resultados de las estadisticas");
            Console.WriteLine("6. Mostrar integrantes de una idea de negocio");
            Console.WriteLine("7. Salir");

            int opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarIdeaDeNegocio(codIdeaDeNegocio++);
                    break;
                case 2:
                    AgregarIntegrante();
                    break;
                case 3:
                    EliminarIntegrante();
                    break;
                case 4:
                    CambiarValorInversion();
                    break;
                case 5:
                    MostrarResultadosEstadisticas();
                    break;
                case 6:
                    MostrarIntegrantesIdeaNegocioPorCodigo();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción ivalida. Por favor, seleccione una opción entre el 1 y 7.");
                    break;
            }
        }
    }

    static void RegistrarIdeaDeNegocio(int codigo)
    {
        var ideaNegocio = new IdeaDeNegocio(codigo);

        Console.WriteLine("Escriba el nombre de la idea de negocio:");
        ideaNegocio.Nombre = Console.ReadLine();

        Console.WriteLine("Describa el impacto social o económico que tendra la idea d:");
        ideaNegocio.ImpactoSocialEconomico = Console.ReadLine();


        Console.WriteLine("Ingrese los departamentos beneficiados (separados por comas):");
        var departamentosInput = Console.ReadLine().Split(',');
        foreach (var depto in departamentosInput)
        {
            var departamento = new Departamento();
            departamento.Codigo = ideasDeNegocio.Count + 1;
            departamento.Nombre = depto.Trim();
            ideaNegocio.DepartamentosBeneficiados.Add(departamento);
        }

        Console.WriteLine("Ingrese el valor de la inversión:");
        ideaNegocio.ValorInversion = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Ingrese el total de ingresos en los primeros 3 años:");
        ideaNegocio.IngresosPrimeros3Anios = decimal.Parse(Console.ReadLine());


        Console.WriteLine("Ingrese las herramientas de la 4RI utilizadas (separadas por comas):");
        var herramientas4RIInput = Console.ReadLine().Split(',');
        foreach (var herramienta in herramientas4RIInput)
        {
            ideaNegocio.Herramientas4RI.Add(herramienta.Trim());
        }

        ideasDeNegocio.Add(ideaNegocio);


        Console.WriteLine($"Idea de negocio registrada exitosamente. Código de la idea: {ideaNegocio.Codigo}");
    }


    static void AgregarIntegrante()
    {
        Console.WriteLine("Ingrese el código de la idea de negocio:");
        int codigoIdea = int.Parse(Console.ReadLine());

        var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigoIdea);

        if (idea != null)
        {
            var integrante = new IntegranteEquipo();

            Console.WriteLine("Ingrese la identificación del integrante:");
            integrante.Identificacion = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre del integrante:");
            integrante.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese los apellidos del integrante:");
            integrante.Apellidos = Console.ReadLine();

            Console.WriteLine("Ingrese el rol del integrante:");
            integrante.Rol = Console.ReadLine();

            Console.WriteLine("Ingrese el email del integrante:");
            integrante.Email = Console.ReadLine();

            idea.IntegrantesEquipo.Add(integrante);
            Console.WriteLine("Integrante agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró una idea de negocio con ese código.");
        }
    }

    static void EliminarIntegrante()
    {
        Console.WriteLine("Ingrese el código de la idea de negocio:");
        int codigoIdea = int.Parse(Console.ReadLine());

        var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigoIdea);

        if (idea != null)
        {
            Console.WriteLine("Ingrese la identificación del integrante a eliminar:");
            string identificacion = Console.ReadLine();

            var integrante = idea.IntegrantesEquipo.FirstOrDefault(i => i.Identificacion == identificacion);

            if (integrante != null)
            {
                idea.IntegrantesEquipo.Remove(integrante);
                Console.WriteLine("Integrante eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("No se encontró un integrante con esa identificación.");
            }
        }
        else
        {
            Console.WriteLine("No se encontró una idea de negocio con ese código.");
        }
    }

    static void CambiarValorInversion()
    {
        Console.WriteLine("Ingrese el código de la idea de negocio:");
        int codigoIdea = int.Parse(Console.ReadLine());

        var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigoIdea);

        if (idea != null)
        {
            Console.WriteLine("Ingrese el nuevo valor de la inversión:");
            idea.ValorInversion = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Valor de inversión modificado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se encontró una idea de negocio con ese código.");
        }
    }

    static void MostrarIntegrantesIdeaNegocioPorCodigo()
    {
        Console.WriteLine("Ingrese el código de la idea de negocio para ver sus integrantes:");
        int codigoIdea = int.Parse(Console.ReadLine());

        var idea = ideasDeNegocio.FirstOrDefault(i => i.Codigo == codigoIdea);

        if (idea != null)
        {
            Console.WriteLine($"Integrantes de la Idea de Negocio ({idea.Nombre}):");
            foreach (var integrante in idea.IntegrantesEquipo)
            {
                Console.WriteLine($"Identificación: {integrante.Identificacion}");
                Console.WriteLine($"Nombre: {integrante.Nombre}");
                Console.WriteLine($"Apellidos: {integrante.Apellidos}");
                Console.WriteLine($"Rol: {integrante.Rol}");
                Console.WriteLine($"Email: {integrante.Email}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No se encontró una idea de negocio con ese código.");
        }
    }
    static void MostrarResultadosEstadisticas()
    {
        Console.WriteLine("Información de la idea de negocio que impacta más departamentos:");
        var maxDepartamentos = ideasDeNegocio.OrderByDescending(i => i.DepartamentosBeneficiados.Count).FirstOrDefault();
        MostrarIdea(maxDepartamentos);

        Console.WriteLine("\nInformación de la idea de negocio con mayor total de ingresos en los primeros 3 años:");
        var maxIngresos = ideasDeNegocio.OrderByDescending(i => i.IngresosPrimeros3Anios).FirstOrDefault();
        MostrarIdea(maxIngresos);

        Console.WriteLine("\nNombres de las 3 ideas de negocio que generan más rentabilidad:");
        var ideasRentables = ideasDeNegocio.OrderByDescending(i => i.IngresosPrimeros3Anios).Take(3);
        MostrarIdeas(ideasRentables);

        Console.WriteLine("\nNombres de las ideas de negocio que impactan más de 3 departamentos:");
        var ideasDepartamentos = ideasDeNegocio.Where(i => i.DepartamentosBeneficiados.Count > 3);
        MostrarIdeas(ideasDepartamentos);

        decimal sumaTotalIngresos = ideasDeNegocio.Sum(i => i.IngresosPrimeros3Anios);
        decimal sumaTotalInversion = ideasDeNegocio.Sum(i => i.ValorInversion);

        Console.WriteLine($"\nSuma Total de Ingresos de Todas las Ideas de Negocio: {sumaTotalIngresos}");
        Console.WriteLine($"Suma Total de la Inversión Necesaria en Todas las Ideas de Negocio: {sumaTotalInversion}");

        Console.WriteLine("\nLa idea de negocio con mas herramientad 4RI:");
        MostrarIdeaConMasHerramientas4RI();


        int ideasConIA = ideasDeNegocio.Count(i => i.Herramientas4RI.Contains("Inteligencia Artificial"));
        Console.WriteLine($"\nCantidad de Ideas de Negocio que tienen Inteligencia Artificial: {ideasConIA}");
    }

    static void MostrarIdea(IdeaDeNegocio idea)
    {
        if (idea != null)
        {
            Console.WriteLine($"Nombre: {idea.Nombre}");
            Console.WriteLine($"Impacto Social o Económico: {idea.ImpactoSocialEconomico}");
            Console.WriteLine("Departamentos Beneficiados:");
            foreach (var depto in idea.DepartamentosBeneficiados)
            {
                Console.WriteLine($"{depto.Nombre}");
            }
        }
    }

    static void MostrarIdeas(IEnumerable<IdeaDeNegocio> ideas)
    {
        foreach (var idea in ideas)
        {
            MostrarIdea(idea);
        }
    }
    static void MostrarIdeaConMasHerramientas4RI()
    {
        var ideaConMasHerramientas4RI = ideasDeNegocio
            .OrderByDescending(i => i.Herramientas4RI.Count)
            .FirstOrDefault();

        if (ideaConMasHerramientas4RI != null)
        {
            Console.WriteLine($"Idea de negocio con más herramientas 4RI: {ideaConMasHerramientas4RI.Nombre}");


        }
        else
        {
            Console.WriteLine("No se encontró ninguna idea de negocio con herramientas 4RI.");
        }
    }


}