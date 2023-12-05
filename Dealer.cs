using Newtonsoft.Json;
using System.IO;
using Microsoft.AspNetCore.Http;

public class Dealer
{
    private static readonly string jsonFilePath = "vehiculos.json";

    //Cargar los vehiculos ya existentes
    public static void CargarVehiculos()
    {
        if (File.Exists(jsonFilePath))
        {
            string json = File.ReadAllText(jsonFilePath);
            ListaVehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(json);
        }
        else
        {
            ListaVehiculos = new List<Vehiculo>();
        }
    }

    //Guardar los vehiculos
    public static void GuardarVehiculos()
    {
        string json = JsonConvert.SerializeObject(ListaVehiculos);
        File.WriteAllText(jsonFilePath, json);
    }

    //Lista
    public static List<Vehiculo> ListaVehiculos;

    public static void Usar(ref WebApplication app)
    {
        var TagNameee = "CRUD:";

        app.MapPost("/crud/agregar/vehiculo", Agregar)
            .Produces<ServerResult>().WithTags(TagNameee);

        app.MapGet("/crud/listar/vehiculo", Listar)
            .Produces<ServerResult>().WithTags(TagNameee);

        app.MapPut("/crud/modificar/vehiculo", Modificar)
            .Produces<ServerResult>().WithTags(TagNameee);

        app.MapDelete("/crud/eliminar/vehiculo", Eliminar)
            .Produces<ServerResult>().WithTags(TagNameee);

        CargarVehiculos();
    }
    public static ServerResult Agregar(Vehiculo vehiculo)
    {
        var resultado = new ServerResult();

        //Verificar si existe
        var vehiculoEncontrado = ListaVehiculos.Find(v => v.Codigo == vehiculo.Codigo);

        if (vehiculoEncontrado != null)
        {
            resultado.Exito = false;
            resultado.Mensaje = "Vehiculo ya existe";
        }
        else
        {
            //Agregar vehiculo
            ListaVehiculos.Add(vehiculo);
            resultado.Resultado = vehiculo;
            GuardarVehiculos();
            resultado.Mensaje = "Vehiculo agregado correctamente";
        }
        return resultado;
    }

    //Listar vehiculos existentes
    public static ServerResult Listar()
    {
        var resultado = new ServerResult();
        CargarVehiculos();
        resultado.Resultado = ListaVehiculos;
        resultado.Mensaje = "Vehiculos listados correctamente";
        return resultado;
    }

    //Modificar vehiculo
    public static ServerResult Modificar(Vehiculo vehiculo)
    {
        var resultado = new ServerResult();
        var vehiculoEncontrado = ListaVehiculos.Find(v => v.Codigo == vehiculo.Codigo);

        if (vehiculoEncontrado != null)
        {
            vehiculoEncontrado.Marca = vehiculo.Marca;
            vehiculoEncontrado.Modelo = vehiculo.Modelo;
            vehiculoEncontrado.Color = vehiculo.Color;
            vehiculoEncontrado.Anoo = vehiculo.Anoo;
            vehiculoEncontrado.Costo = vehiculo.Costo;
            resultado.Resultado = vehiculoEncontrado;
            GuardarVehiculos();
            resultado.Mensaje = "Vehiculo modificado correctamente";
        }
        else
        {
            resultado.Exito = false;
            resultado.Mensaje = "Vehiculo no encontrado";
        }
        return resultado;
    }

    //Eliminar vehiculo
    public static ServerResult Eliminar(string codigo, IHttpContextAccessor httpContextAccessor)
    {
        var resultado = new ServerResult();
        var vehiculoEncontrado = ListaVehiculos.Find(v => v.Codigo == codigo);

        if (vehiculoEncontrado != null)
        {
            ListaVehiculos.Remove(vehiculoEncontrado);
            GuardarVehiculos();
            resultado.Resultado = vehiculoEncontrado;
            resultado.Mensaje = "Vehiculo eliminado correctamente";
        }
        else
        {
            resultado.Exito = false;
            resultado.Mensaje = "Vehiculo no encontrado";
            httpContextAccessor.HttpContext.Response.StatusCode = 404;
        }
        return resultado;
    }
}

public class Vehiculo
{
    public string Codigo { get; set; } = "";
    public string Marca { get; set; } = "";
    public string Modelo { get; set; } = "";
    public string Color { get; set; } = "";
    public int Anoo { get; set; } = 0;
    public double Costo { get; set; } = 0;
}

public interface IHttpContextAccessor
{
    HttpContext HttpContext { get; }
}

public class HttpContextAccessor : IHttpContextAccessor
{
    public HttpContext ?HttpContext { get; set; }
}

