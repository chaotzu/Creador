using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Creador
{

    public class Universo
    {
       public String nombre;
        public List<Planeta> planetas = new List<Planeta>();

        public Universo(String nombre, Planeta[] planetas)
        {
            this.nombre = nombre;            
            foreach (var item in planetas)
            {
                this.planetas.Add(item);
            }    
                        
        }
        public Universo(String nombre, List<Planeta> planetas)
        {               
            this.nombre = nombre;            
            this.planetas = planetas;
        }
    }
}