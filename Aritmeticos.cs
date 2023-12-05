public class Aritmeticos
{
    public static void Aplicar(ref WebApplication app)
    {
        var TagNameee = "ARITMETICOS:"; 

        app.MapPost("/suma", Suma
        ).Produces<ServerResult>().WithTags(TagNameee);

        app.MapGet("/promedio", Promedio)
        .Produces<ServerResult>().WithTags(TagNameee);
    }

    public static ServerResult Suma(int a, int b)
    {
        var resultado = new ServerResult();
        resultado.Resultado = a + b;
        resultado.Mensaje = "Suma realizada correctamente";
       
        return resultado;
    }

    public static ServerResult Promedio(int a, int b){
        var resultado = new ServerResult();
        resultado.Resultado = (a + b)/2;
        resultado.Mensaje = "El promedio ha sido realizado correctamente";
      
        return resultado;
    }
}