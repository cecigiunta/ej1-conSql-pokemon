namespace primerAppPokemon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Invocar la lectura de la BD
            PokemonNegocio negocio = new PokemonNegocio();

            //a la grilla, le voy a asignar la lista que devuelve el método
            //el DataSource recibe datos y los moldea en la lista
            dgvPokemons.DataSource = negocio.listar();

        }
    }
}