using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//AGREGO
using dominio;
using negocios;

namespace primerAppPokemon
{
    public partial class frmAlta : Form
    {
        private Pokemon pokemon = null;  //MODIFICAR POKE
        private OpenFileDialog archivo = null;  //CARGAR IMG LOCAL

        public frmAlta()  //Constructor de la clase
        {
            InitializeComponent();
        }

        //NUEVO - MODIFICAR POKEMON
        public frmAlta(Pokemon pokemon)  //Constructor de la clase duplicado para que reciba parametro
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Pokemon";   //Para que cambie el texto que aparece arriba del Form y diga modificar en vez de "nuevo"
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); //Boton cancelar: Lo programo para que cierre el form
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Creo un nuevo objeto
            //MODIFICAR - YA NO NECESITO ESTO:  Pokemon nuevoPokemon = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                //Cargo los datos en mi nuevo objeto
                if(pokemon == null)  //Si el pokemon está nulo, significa que se quiere agregar uno nuevo
                    pokemon = new Pokemon();

                pokemon.Numero = int.Parse(textBoxNumero.Text);
                pokemon.Nombre = textBoxNombre.Text;
                pokemon.Descripcion = textBoxDescrip.Text;

                //AGREGO PARA DAR DE ALTA LA IMAGEN
                //Tambien al metodo agregar le tengo que agregar esta imagen
                pokemon.UrlImagen = textBoxImg.Text;

                //AGREGAMOS DESPLEGABLES
                pokemon.Tipo = (Elemento)comboTipo.SelectedItem; //El combo devuelve un object, entonces hago la conversion a elemento
                pokemon.Debilidad = (Elemento)comboDebilidad.SelectedItem;


                if(pokemon.Id != 0)
                {
                    //MODIFICAR POKEMON
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente!");
                }
                else
                {
                    //Mando los datos a la BD
                    negocio.agregar(pokemon); //Eso en PokemonNegocio, en el metodo AGREGAR
                    MessageBox.Show("Agregado exitosamente!");
                }

                //CARGAR IMAGEN LOCALMENTE
                if(archivo != null && !textBoxImg.Text.ToUpper().Contains("HTTP"))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.FileName);
                    //guardo la imagen, lo usamos haciendo usodela clase file
                    //El copy recibe un archivo de origen y una ruta de destino
                    //Para la ruta de destino tenemos q crear una carpeta en nuestra PC en el disco C (cree poke-app y la vamos a agregar por archivo de configuracion
                    //Para leerlo, agrego una referencia en el proyecto -> assembles > System.Configuration
                }
                Close();

            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.ToString());
            }
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            //Voy a cargar aca los combos con la info4
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                //estoy yendo dos veces a la BD
                comboTipo.DataSource = elementoNegocio.listar();

                //NUEVO POKEMON MODIFICAR
                //les agrego una clave - valor
                comboTipo.ValueMember = "Id";
                comboTipo.DisplayMember = "Descripcion";
                // -- FIN NUEVO


                comboDebilidad.DataSource = elementoNegocio.listar();

                //NUEVO POKEMON MODIFICAR
                comboDebilidad.ValueMember = "Id";
                comboDebilidad.DisplayMember = "Descripcion";
                // FIN



                //NUEVO - POKEMON MODIFICAR   
                //para que precargue los datos
                if (pokemon != null)
                {
                    textBoxNumero.Text = pokemon.Numero.ToString();
                    textBoxNombre.Text = pokemon.Nombre;
                    textBoxDescrip.Text = pokemon.Descripcion;
                    textBoxImg.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);

                    comboTipo.SelectedValue = pokemon.Tipo.Id;
                    comboDebilidad.SelectedValue = pokemon.Debilidad.Id;

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
  

        //AGREGAR IMAGEN ALTA: pokemon.com/el/pokedex  de aca saco las fotos
        private void textBoxImg_Leave(object sender, EventArgs e)
        {
            //ME AGREGO EL METODO ACA Y LE PASO COMO PARAMETRO LA IMAGEN URL
            cargarImagen(textBoxImg.Text);
        }  //evento Leave del TextBox Imagen

        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBoxPokemon.Load(imagen);

            }
            catch (Exception ex)
            {
                //Cargamos una imagen por defecto
                pictureBoxPokemon.Load("https://storage.googleapis.com/proudcity/mebanenc/uploads/2021/03/placeholder-image.png");

            }
        }

        private void btnAgregarImg_Click(object sender, EventArgs e)
        {
            //para poder levantar una img:
            OpenFileDialog archivo = new OpenFileDialog() ; //creamos un objeto

            //le podemos decir qué archivos permita
            archivo.Filter = "jpg|*.jpg";

            //cuando abra, si el resultado da OK osea que user le dio "Abrir" a la imagen
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                //en la caja de texto de la img, le voy a guardar la ruta completa
                textBoxImg.Text = archivo.FileName;

                //para verlo ahi en la app, vuelvo a mi metodo cargarImagen
                cargarImagen(archivo.FileName);
            }
        }
    }
}
