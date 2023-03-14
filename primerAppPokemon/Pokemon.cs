using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace primerAppPokemon
{
    internal class Pokemon
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public string UrlImagen { get; set; }

        //Creo la nueva propiedad que va a ser el Tipo (es de tipo Elemento, la clase q cree)
        public Elemento Tipo { get; set; }

        public Elemento Debilidad { get; set; }
    }
}
