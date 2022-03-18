using Clases.Accesos;
using Clases.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio3
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        ClaseUsuario usuario = new ClaseUsuario();
        string operacion = string.Empty;
        Usuarios user = new Usuarios();



        private void ListarUsuarios()
        {
            UsuariosDataGridView.DataSource = usuario.ListarUsuarios();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            HabilitarControles();

            operacion = "Nuevo";
        }

        private void HabilitarControles()
        {
            CodigoTextBox.Enabled = true;
            NombreTextBox.Enabled = true;
            ClaveTextBox.Enabled = true;
            RolComboBox.Enabled = true;

            NuevoButton.Enabled = false;
            GuardarButton.Enabled = true;
            CancelarButton.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            CodigoTextBox.Enabled = false;
            NombreTextBox.Enabled = false;
            ClaveTextBox.Enabled = false;
            RolComboBox.Enabled = false;

            NuevoButton.Enabled = true;
            GuardarButton.Enabled = false;
            CancelarButton.Enabled = false;
        }

        private void LimpiarControles()
        {
            CodigoTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            RolComboBox.Text = string.Empty;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            user.Codigo = CodigoTextBox.Text;
            user.Nombre = NombreTextBox.Text;
            user.Clave = ClaveTextBox.Text;
            user.Rol = RolComboBox.Text;
 

            if (operacion == "Nuevo")
            {
                bool inserto = usuario.InsertarUsuario(user);
                if (inserto)
                {
                    MessageBox.Show("Usuario Creado");
                    ListarUsuarios();
                    LimpiarControles();
                    DeshabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo crear");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = usuario.ModificarUsuario(user);
                if (modifico)
                {
                    MessageBox.Show("Usuario Modificado");
                    ListarUsuarios();
                    LimpiarControles();
                    DeshabilitarControles();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo modificar");
                }
            }
        }

        private void ModificarButton_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                CodigoTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString();
                NombreTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                ClaveTextBox.Text = UsuariosDataGridView.CurrentRow.Cells["Clave"].Value.ToString();
                RolComboBox.Text = UsuariosDataGridView.CurrentRow.Cells["Rol"].Value.ToString();
                HabilitarControles();
            }
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            if (UsuariosDataGridView.SelectedRows.Count > 0)
            {
                bool elimino = usuario.EliminarUsuario(UsuariosDataGridView.CurrentRow.Cells["Codigo"].Value.ToString());
                if (elimino)
                {
                    MessageBox.Show("Usuario Eliminado");
                    ListarUsuarios();
                }
                else
                {
                    MessageBox.Show("Usuario no se pudo eliminar");
                }
            }
        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            ListarUsuarios();
        }
    }
}
