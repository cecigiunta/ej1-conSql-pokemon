using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Para hacer la conexion a la BD tengo que incluir una libreria:
using System.Data.SqlClient;
using dominio;

namespace negocios
{
    public class PokemonNegocio
    {
        //Creo el primer metodo, le digo qué devuelve (una lista de Pokemon)
        public List<Pokemon> listar()
        {
            //Creamos esa lista
            List<Pokemon> lista = new List<Pokemon>();

            SqlConnection conexion = new SqlConnection();

            //las acciones q realizo
            SqlCommand comando = new SqlCommand();

            //Una vez q vuelvan los datos, los guardo aca
            //No genero instancia porque voy a obtener como resultado un objeto
            SqlDataReader lector;


            //Manejar excepciones es muy importante para la conexion a la BD
            try
            //Dentro del try, todo lo que puede fallar (la conexion)
            {
                //lo primero es el servidor, lo segundo es a qué base de datos (database=EL NOMBRE DE LA BD)
                //lo tercero es como me voy  a autenticar(en este caso es cuando usamos Microsoft Auth
                //si tuviese un usuario seria : integrated security= false y le agrego el usr y contra
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security=true";

                //Lo siguiente que configuro es el comando
                //Le decimos el tipo. Hay 3:
                //1. Tipo procedimiento almacenado: le voy a pedir que ejecute una funcion guardada en la bd
                //2. Tipo enlace directo con la tabla: no se usa

                //3. Tipo texto : le inyectamos una sentencia sql -- usamos esa
                // Es recomendable hacerla PRIMERO en el sql
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion as Tipo, D.Descripcion as Debilidad From POKEMONS P, ELEMENTOS E, ELEMENTOS D Where E.Id = P.IdTipo And D.Id = P.IdDebilidad";

                comando.Connection = conexion;  //le digo al comando que esa sentencia la ejecute en la conexion que defini

                conexion.Open();  //abro la conexion
                lector = comando.ExecuteReader(); //ejecuto la lectura (da como resultado un sqldatareader)
                //los datos ahora los tengo en mi variable "lector"

                //Ahora tengo que transformar esos datos en una Lista, que defini arriba
                while (lector.Read())
                {
                    //Si da true, apunta al PRIMER registro
                    Pokemon aux = new Pokemon(); //me creo un auxiliar
                    aux.Numero = lector.GetInt32(0);  //Tengo que conocer qué tipo de dato es (int)
                    aux.Nombre = (string)lector["Nombre"];   //Le pongo el nombre de la columna. Es mas practico
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.UrlImagen = (string)lector["UrlImagen"];

                    //CARGAR TIPO Y DEBILIDAD
                    aux.Tipo = new Elemento(); //para que no de referencia nula, porque viene sin instancia la 1 vez
                    aux.Tipo.Descripcion = (string)lector["Tipo"];

                    aux.Debilidad = new Elemento();
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);        //En cada vuelta va a ir creando una nueva instancia y guardando en la lista
                }

                conexion.Close();          //Cierro la conexion
                
                return lista;              //hacemos que la devuelva. Cuando no haya más, deja de leer y la devuelve

            }
            catch(Exception ex)
            {
                throw ex;
            }




        }
    }
}
