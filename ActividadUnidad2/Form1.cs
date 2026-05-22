using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActividadUnidad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ValidateFields(object sender, EventArgs e)
        {
            Regex usernameRegex = new Regex("^[a-z]{4}.+", RegexOptions.IgnoreCase);
            string username = usernameBox.Text;

            if (!usernameRegex.IsMatch(username))
            {
                MessageBox.Show("El nombre de usuario indicado no es válido.", "Error");
                usernameBox.Focus();
                return;
            }

            Regex emailRegex = new Regex(
                "^[a-z].+@(gmail|hotmail|icloud)\\.com",
                RegexOptions.IgnoreCase
            );

            string email = emailBox.Text;
            if (!emailRegex.IsMatch(email))
            {
                MessageBox.Show(
                    "El correo electrónico indicado no es válido o no está soportado actualmente.",
                    "Error"
                );
                return;
            }

            string password = passwordBox.Text;
            if (password.Length < 8)
            {
                MessageBox.Show("La contrasenia es demasiado corta.", "Error");
                return;
            }

            MessageBox.Show(
                $"Has iniciado sesión satisfactoriamente. Bienvenido {username}!",
                "Éxito"
            );
        }

        private void OnShowPassword(object sender, EventArgs e)
        {
            char passwordChar;
            if (showPasswordCheckBox.Checked)
            {
                passwordChar = '\0';
            }
            else
            {
                passwordChar = '*';
            }

            passwordBox.PasswordChar = passwordChar;
        }

        private void OnExitButtonClicked(object sender, EventArgs e)
        {
            DialogResult reply = MessageBox.Show(
                "Estás seguro que deseas salir?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (reply == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
