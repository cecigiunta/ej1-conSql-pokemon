﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public frmAlta()
        {
            InitializeComponent();
        }

        private void labelNumero_Click(object sender, EventArgs e)
        {

        }

        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); //Boton cancelar: Lo programo para que cierre el form
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Creo un nuevo objeto
            Pokemon nuevoPokemon = new Pokemon();
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {
                //Cargo los datos en mi nuevo objeto
                nuevoPokemon.Numero = int.Parse(textBoxNumero.Text);
                nuevoPokemon.Nombre = textBoxNombre.Text;
                nuevoPokemon.Descripcion = textBoxDescrip.Text;

                //AGREGAMOS DESPLEGABLES
                nuevoPokemon.Tipo = (Elemento)comboTipo.SelectedItem; //El combo devuelve un object, entonces hago la conversion a elemento
                nuevoPokemon.Debilidad = (Elemento)comboDebilidad.SelectedItem;


                //Mando los datos a la BD
                //Eso en PokemonNegocio, en el metodo AGREGAR
                negocio.agregar(nuevoPokemon);
                MessageBox.Show("Agregado exitosamente!");
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
                comboDebilidad.DataSource = elementoNegocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void comboDebilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
