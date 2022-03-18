using Clases.Accesos;
using Clases.Entidades;
using System;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class LoginUsuarios : Form
    {
        public LoginUsuarios()
        {
            InitializeComponent();
        }

        private void LoginUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void AceptarButton_Click(object sender, EventArgs e)
        {
            ClaseUsuario usuario = new ClaseUsuario();
            Usuarios usuarios = new Usuarios();

            usuarios = usuario.LoginUsuarios(NombreUsuarioTextBox.Text, ClaveTextBox.Text);

            if (usuario == null)
            {
                MessageBox.Show("Datos erroneos");
                return;
            }
          

            FormUsuarios frmUsuarios = new FormUsuarios();
            frmUsuarios.Show();
            this.Hide();

        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
