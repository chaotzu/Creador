using System;
using Newtonsoft.Json;

namespace Creador
{
    class Principal
    {
        static void Main(string[] args)
        {
            //Transformar  planetas en un arreglo de Planetas (transforma JSON a objeto c#)
            var planetasStarWars = JsonConvert.DeserializeObject < ViaLacteaStarWars > (Constantes.MisPlanetas); 
            //planetasStarWars  es el objeto que contiene el resultado, en propiedad planetas se encuentran los planetas como un arreglo
            Console.WriteLine(planetasStarWars.planetas[0].Name);//Acceder al nombre del primer planeta
        }
    }
}
