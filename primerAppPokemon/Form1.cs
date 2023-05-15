using dominio;
using negocios;

namespace primerAppPokemon
{
    public partial class Form1 : Form
    {
        //me creo una variable para guardar la lista, privada para poder tenerla disponible y usarla en otroa evntos
        private List<Pokemon> listaPokemons;

        public Form1()
        {
            InitializeComponent();
        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarForm();
        }


        //Metodo de la grilla: Selection changed. Cuando cambie la seleccion de la grilla, cambio la imagen
        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPokemons.CurrentRow != null)
            {
                //Selecciono la fila actual, te devuelve un object que tengo que transformar en Pokemmon
                //Entonces creo una variable llamada "seleccionado" y con el (Pokemon) transformo eso en pokemon
                Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

                cargarImagen(seleccionado.UrlImagen);   //entonces cuando carga le asigno la imagen, ahora por medio de la funcion

            }
        }

        //Hacemos un metodo para capturar la excepcion de cuando no haya imagen en la url
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

        private void cargarForm()
        {
            PokemonNegocio negocio = new PokemonNegocio();    //Invocar la lectura de la BD

             try
            {
                listaPokemons = negocio.listar();    //Cuando arranque la app ya lo guardo en la variable

                //el DataSource recibe datos y los moldea en la lista
                dgvPokemons.DataSource = listaPokemons;  //a la grilla, le voy a asignar la lista que devuelve el método
                cargarImagen(listaPokemons[0].UrlImagen);  //Le cargo al picture box la primere foto
                ocultarColumnas();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }

        private void ocultarColumnas()
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false;  //no quiero que me muestre la url de la imagen
            dgvPokemons.Columns["Id"].Visible = false;
        }

        //AGREGAR UN POKEMON
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAlta alta = new frmAlta();  //Llamo al otro formulario cuando se clickee el boton
            alta.ShowDialog();
            cargarForm();   //Para que luego de agregar se actualice automáticamente
        }


        //MODIFICAR UN POKEMON
        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Le tengo que pasar como parámetro el objeto pokemon al que yo quiero modificar
            Pokemon pokemonSeleccionado;
            pokemonSeleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;  //Así obtengo el pokemon seleccionado

            //Tengo que ir a la clase frm Alta y DUPLICAR su constructor para que pueda obtener como parámetro al poke seleccionado
            frmAlta modificar = new frmAlta(pokemonSeleccionado); 
            modificar.ShowDialog();
            cargarForm();
        }


        //ELIMINAR POKEMON (FISICO) -> Se elimina de la BD
        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }


        //ELIMINAR POKEMON -> LOGICO 
        private void btnEliminarLogica_Click(object sender, EventArgs e)
        {
            eliminar(true); //acá le digo que SI es logico
            //y a la consulta del metodo listar le agrego que P.activo = 1 asi filtra solo los activos y carga eso
        }


        //Metodo eliminar GENERAL, dependiendo si es fisico o logico lo llamo de arriba
        private void eliminar(bool logico = false) //si se lo mando así, el valor es opcional y por defecto es FALSE
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                //validacion para ver si realmente quiere eliminar:
                DialogResult respuesta = MessageBox.Show("Realmente querés eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                //El metodo devuelve un Dialog Result, en ese me guardo la respuesta del metodo show

                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

                    //llamo a uno o a otro dependiendo del valor del bool
                    if (logico)
                    {
                        negocio.eliminarLogico(seleccionado.Id);
                    }
                    else
                    {
                        negocio.eliminar(seleccionado.Id);
                    }

                    //para que se actualice la grilla una vez eliminado:
                    cargarForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        //BOTON DE FILTRADO
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;   //Creo una nueva lista. Esta lista es la que creo arriba como privada
            string filtro = textBoxFiltro.Text;

            if(filtro != "")  //Si hay algo en el filtro..
            {
                listaFiltrada = listaPokemons.FindAll(x => 
                x.Nombre.ToLower().Contains(textBoxFiltro.Text.ToLower()) || 
                x.Tipo.Descripcion.ToLower().Contains(textBoxFiltro.Text.ToLower()) ||
                x.Debilidad.Descripcion.ToLower().Contains(textBoxFiltro.Text.ToLower())
                );
                //El findAll (metodo de los tipo collection) requiere como parámetro una expresióm lamda, es una especie de ForEach:
                //En cada vuelta, el nombre si es igual al filtro, lo devuelve y lo  muestra
                //El Contains para que no tengas que escribir toda la palabra para que filtre
            } else
            {
                listaFiltrada = listaPokemons;    //si no hay nada en el filtro, devuelve la lista original
            }
            //una vez que tenga mi lista filtrada
            dgvPokemons.DataSource = null;   //1 paso: limpio la lista
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumnas();
        }
    }

    
}