using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Creador
{
    class Principal
    {
        static void Main(string[] args)
        {
            List<Universo> universos = new List<Universo>();
            bool salir = false;
            int i,k = 0;
            int universoElegido = 0;

            //Transformar  planetas en un arreglo de Planetas (transforma JSON a objeto c#)
            var planetasStarWars = JsonConvert.DeserializeObject < ViaLacteaStarWars > (Constantes.MisPlanetas); 
            //planetasStarWars  es el objeto que contiene el resultado, en propiedad planetas se encuentran los planetas como un arreglo
            Console.WriteLine(planetasStarWars.planetas[0].Name);//Acceder al nombre del primer planeta
            //Arreglo a lista
            universos.Add(new Universo(nombre: "Universo madre", planetas: planetasStarWars.planetas));            
 
            while (!salir) {
 
                try
                {
                     
                    Console.WriteLine("1. Crear planeta");
                    Console.WriteLine("2. Ver planetas");
                    Console.WriteLine("3. Eliminar planeta");
                    Console.WriteLine("4. Crear universo");
                    Console.WriteLine("5. Transferir planetas");
                    Console.WriteLine("6. Salir");
                    Console.WriteLine("Elige una de las opciones");
                    int opcion = Convert.ToInt32(Console.ReadLine());
 
                    switch (opcion)
                    {
                        case 1:
                            Console.WriteLine("Crear planeta");                            
                            Console.WriteLine("Nombre del planeta");
                            String nombre = Console.ReadLine();   
                            //TODO: Aqui se agregarían todos los atributos de planeta para crearlo con el constructor ....   
                            try{                      
                                Console.WriteLine("¿En qué universo agregarás el planeta?");
                                i = 0;
                                //Mostrar universos a usuario
                                foreach(var item in universos){
                                    i++;
                                    Console.WriteLine(i.ToString() + " " + item.nombre);
                                }
                                universoElegido = Convert.ToInt32(Console.ReadLine());
                            }catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            //Agregar planeta a universo elegido
                            universos[universoElegido-1].planetas.Add(new Planeta(nombre: nombre));                            
                            break;
 
                        case 2:
                            Console.WriteLine("Ver planetas");
                            try{
                                Console.WriteLine("¿Qué universo deseas mirar?");
                                i = 0;
                                //Mostrar universos a usuario
                                foreach(var item in universos){
                                    i++;
                                    Console.WriteLine(i.ToString() + " " + item.nombre);
                                }
                                universoElegido = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            foreach(var item in universos[universoElegido-1].planetas){
                                Console.WriteLine(item.Name);
                            }
                            break;
 
                        case 3:
                            Console.WriteLine("Eliminar planeta");
                            try{
                                Console.WriteLine("¿De qué universo eliminarás planeta?");
                                i = 0;
                                //Mostrar universos a usuario
                                foreach(var item in universos){
                                    i++;
                                    Console.WriteLine(i.ToString() + " " + item.nombre);
                                }
                                universoElegido = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }

                            Console.WriteLine("Elige un planeta a eliminar");
                            int j = 0;
                            foreach(var item in universos[universoElegido-1].planetas){
                                j++;
                                Console.WriteLine(j.ToString() + " " + item.Name);
                            }
                            try{
                                j = Convert.ToInt32(Console.ReadLine());
                                universos[universoElegido-1].planetas.RemoveAt(j-1);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Crear universo");                            
                            Console.WriteLine("Nombre deluniverso");
                            nombre = Console.ReadLine();                                                                                       
                            universos.Add(new Universo(nombre: nombre, planetas: new List<Planeta>()));                            
                            break; 
                        case 5:
                            Console.WriteLine("Transferir planetas");                            
                            try{
                                Console.WriteLine("¿De qué universo transferirás planeta?");
                                i = 0;
                                //Mostrar universos a usuario
                                foreach(var item in universos){
                                    i++;
                                    Console.WriteLine(i.ToString() + " " + item.nombre);
                                }
                                universoElegido = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            Console.WriteLine("Elige un planeta a transferir");
                            j = 0;
                            foreach(var item in universos[universoElegido-1].planetas){
                                j++;
                                Console.WriteLine(j.ToString() + " " + item.Name);
                            }
                            try{
                                j = Convert.ToInt32(Console.ReadLine());                                
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }                            
                            try{
                                Console.WriteLine("¿A qué universo transferirás planeta?");
                                k = 0;
                                //Mostrar universos a usuario
                                foreach(var item in universos){
                                    k++;
                                    Console.WriteLine(k.ToString() + " " + item.nombre);
                                }
                                k = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            universos[k-1].planetas.Add(universos[universoElegido-1].planetas[j-1]);                            
                            universos[universoElegido-1].planetas.RemoveAt(j-1);
                            break;
                        case 6:                            
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Elige una opcion entre 1 y 5");
                            break;
                    }
 
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
 
            Console.ReadLine();

            
        }
    }
}