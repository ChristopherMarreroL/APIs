public class Otros
{
    public static void Ejecutar(ref WebApplication app)
    {
        var TagNameee = "OTROS:";

        app.MapGet("/segundo/grado", SegundoGrado
        ).Produces<ServerResult>().WithTags(TagNameee);

        app.MapGet("/frase", Frase
         ).Produces<ServerResult>().WithTags(TagNameee);

         app.MapGet("/calcular/pasaje", Pasaje
         ).Produces<ServerResult>().WithTags(TagNameee);

         app.MapGet("/calcular/MegaBytes", MegaBytes
         ).Produces<ServerResult>().WithTags(TagNameee);

        app.MapPost("/CambioPesos/a/Dolar", Dolares
         ).Produces<ServerResult>().WithTags(TagNameee);
         
         app.MapGet("/acercade", AcercaDe
         ).Produces<Persona>().WithTags(TagNameee);
    } 

    public static ServerResult SegundoGrado(int a, int b, int c)
    {
        var resultado = new ServerResult();
        double resolver = Math.Pow(b, 2) - 4 * a * c;

        if (resolver > 0)
        {
            resultado.Resultado = new double[] {
            (-b + Math.Sqrt(resolver)) / (2 * a),
            (-b - Math.Sqrt(resolver)) / (2 * a)
        };
            resultado.Mensaje = "Dos soluciones encontradas.";
        }
        else if (resolver == 0)
        {
            resultado.Resultado = new double[] { -b / (2 * a) };
            resultado.Mensaje = "Una solución encontrada.";
        }
        else
        {
            resultado.Resultado = new double[0];
            resultado.Mensaje = "No hay soluciones.";
        }
        return resultado;
    }
    public static ServerResult Frase(string palabras){
        var resultado = new ServerResult();
        int contar;
        resultado.Resultado = contar = palabras.Length;
        resultado.Mensaje = "Frase contada correctamente.";
       
        return resultado;
    }
    public static ServerResult Pasaje (int dinero, int costo){
        var resultado = new ServerResult();

        if(costo == 25){
            resultado.Resultado = dinero/25 ;
        }else if(costo == 50) {
            resultado.Resultado = dinero/50 ;
        }else if (costo >= 50){
            resultado.Mensaje = "No existen un pasaje de esa cantidad.";
            resultado.Exito = false;
        }else{
            resultado.Mensaje = "Viajes calculados correctamente" ;
        }
        return resultado;
    }
    public static ServerResult MegaBytes(double megabytes){
        var resultado = new ServerResult();
        double G = megabytes/1024;
        double T = megabytes/1000000;
        resultado.Resultado = $"La cantidad de GB es: {G} y la cantidad de TB es: {T}.";
        resultado.Mensaje = "El calculo ha sido realizado correctamente.";

        return resultado;
    }
    public static ServerResult Dolares(double pesos, double precioDolar){
        var resultado = new ServerResult();
        resultado.Resultado = pesos/precioDolar;
        resultado.Mensaje = "Cambio de pesos a dolar exitosamente.";

        return resultado;
    }
    public static Persona AcercaDe(){
        var resultado = new Persona();
        resultado.Nombre= "Christopher";
        resultado.Nombre2 = "Enrique";
        resultado.Apellido= "Marrero";
        resultado.Apellido2= "Liriano";
        resultado.Correo = "20220997@itla.edu.do / christophermarrero35@gmail.com";
        resultado.Telegram = "https://t.me/ElChrispuntocom";
        resultado.foto = "https://itlaedudo-my.sharepoint.com/:i:/g/personal/20220997_itla_edu_do/EdcPlb5XHyhGmPaJEe9jyiMBYeJuwGtfAhzB9RWhfrWzcQ?e=DBpSIg";

        return resultado;
    }
}