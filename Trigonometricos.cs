public class Trigonometricos{
    public static void Utilizar(ref WebApplication app){
        var TagNameee = "TRIGONOMETRICOS:";

        app.MapGet("/buscar/hipotenisa", Hipotenusa
        ).Produces<ServerResult>().WithTags(TagNameee);

        app.MapGet("/encontrar/cateto", Cateto
        ).Produces<ServerResult>().WithTags(TagNameee);

        app.MapGet("/encontrar/area", Area
        ).Produces<ServerResult>().WithTags(TagNameee);

    }
    public static ServerResult Hipotenusa(int cateto1, int cateto2){
        var resultado = new ServerResult();
        resultado.Resultado = Math.Sqrt(Math.Pow(cateto1,2) + Math.Pow(cateto2,2));
        resultado.Mensaje = "Hipotenusa encontrada correctamente";
       
        return resultado;
    }
    public static ServerResult Cateto(int hipotenusa, int cateto){
        var resultado = new ServerResult();
        resultado.Resultado = Math.Sqrt(Math.Pow(hipotenusa,2) - Math.Pow(cateto,2));
        resultado.Mensaje = "Cateto encontrado correctamente";
       
        return resultado;
    }
    public static ServerResult Area(int basee, int altura){
        var resultado = new ServerResult();
        resultado.Resultado = (basee * altura)/2; 
        resultado.Mensaje = "Area encontrada correctamente";
       
        return resultado;
    }
}