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

            //AGREGO: FILTRO CONTRA BD
            comboBoxCampo.Items.Add("Número");
            comboBoxCampo.Items.Add("Nombre");
            comboBoxCampo.Items.Add("Descripción");
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


        //FILTRADO RAPIDO - Cambio boton a evento Text Changed del Text Box
         private void textBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltrada;   //Creo una nueva lista. Esta lista es la que creo arriba como privada
            string filtro = textBoxFiltro.Text;

            if (filtro != "")  //Si hay algo en el filtro..
            {
                listaFiltrada = listaPokemons.FindAll(x =>
                x.Nombre.ToLower().Contains(textBoxFiltro.Text.ToLower()) ||
                x.Tipo.Descripcion.ToLower().Contains(textBoxFiltro.Text.ToLower()) ||
                x.Debilidad.Descripcion.ToLower().Contains(textBoxFiltro.Text.ToLower())
                );
                //El findAll (metodo de los tipo collection) requiere como parámetro una expresióm lamda, es una especie de ForEach:
                //En cada vuelta, el nombre si es igual al filtro, lo devuelve y lo  muestra
                //El Contains para que no tengas que escribir toda la palabra para que filtre
            }
            else
            {
                listaFiltrada = listaPokemons;    //si no hay nada en el filtro, devuelve la lista original
            }
            //una vez que tenga mi lista filtrada
            dgvPokemons.DataSource = null;   //1 paso: limpio la lista
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = comboBoxCampo.SelectedItem.ToString(); //cuando selecciono el campo
            if (opcion == "Número")
            {
                comboBoxCriterio.Items.Clear();
                comboBoxCriterio.Items.Add("Mayor a");
                comboBoxCriterio.Items.Add("Menor a");
                comboBoxCriterio.Items.Add("Igual a");
            }
            else  //si no es numero, entonces es descripcion o nombre (ambos texto)
            {
                comboBoxCriterio.Items.Clear();
                comboBoxCriterio.Items.Add("Comienza con");
                comboBoxCriterio.Items.Add("Termina con");
                comboBoxCriterio.Items.Add("Contiene");
            }
        }


        //FUNCION para validar si hay algo seleccionado en el filtro avanzado
        private bool validarFiltro()
        {
            //como sé si el cbo está cargado: Si el index del combo es mayor o igual a 0, significa que hay algo seleccionado
            //Si esta el index en -1, significa que no hay NADA seleccionado
            if(comboBoxCampo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el campo para filtrar");
                return true;
            }
            if (comboBoxCriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el criterio para filtrar");
                return true;
            }

            //Si la persona eligio el campo Numeros...
            if(comboBoxCampo.SelectedItem.ToString() == "Número")
            {
                //Pregunto primero si no está vacío
                if (string.IsNullOrEmpty(textBoxFiltroAv.Text))
                {
                    MessageBox.Show("Ingrese algún valor para filtrar");
                    return true;
                }
                //Pregunto si está escribiendo numeros. Si NO está escribiendo numeros
                if (!soloNumeros(textBoxFiltroAv.Text))
                {
                    MessageBox.Show("Solo Numeros por favor");
                    return true;
                }
           
            }

            return false;
        }

        //Funcion para validar que si eligen NUMERO como Campo, se ingresen numeros
        private bool soloNumeros(string cadena)
        {
            foreach  ( char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                {
                    return false;
                }
            }
            return true;
        }



        //BOTON PARA FILTRAR AVANZADO
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                //AGREGO ESTO HOY
                if (validarFiltro())
                {
                    return;   //Si da positivo, o sea que SI necesita validar, corta la ejecucion del evento
                }

                string campo = comboBoxCampo.SelectedItem.ToString();
                string criterio = comboBoxCriterio.SelectedItem.ToString();
                string filtro = textBoxFiltroAv.Text;
                dgvPokemons.DataSource = negocio.filtrarContraBD(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

    
}