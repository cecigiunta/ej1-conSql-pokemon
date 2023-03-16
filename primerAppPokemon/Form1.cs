using dominio;
using negocios;

namespace primerAppPokemon
{
    public partial class Form1 : Form
    {
        //me creo una variable para guardar la lista, privada
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
            
            PokemonNegocio negocio = new PokemonNegocio();    //Invocar la lectura de la BD
            listaPokemons = negocio.listar();    //Cuando arranque la app ya lo guardo en la variable

            //el DataSource recibe datos y los moldea en la lista
            dgvPokemons.DataSource = listaPokemons;  //a la grilla, le voy a asignar la lista que devuelve el método

            dgvPokemons.Columns["UrlImagen"].Visible = false;  //no quiero que me muestre la url de la imagen
           
            cargarImagen(listaPokemons[0].UrlImagen);  //Le cargo al picture box la primere foto


        }


        //Metodo de la grilla: Selection changed. Cuando cambie la seleccion de la grilla, cambio la imagen
        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            //Selecciono la fila actual, te devuelve un object que tengo que transformar en Pokemmon
            //Entonces creo una variable llamada "seleccionado" y con el (Pokemon) transformo eso en pokemon
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

            cargarImagen(seleccionado.UrlImagen);   //entonces cuando carga le asigno la imagen, ahora por medio de la funcion
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
    }
}