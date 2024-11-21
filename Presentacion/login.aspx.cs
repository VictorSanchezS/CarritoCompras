using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String user = txtUsername.Text.Trim();
            String pass= txtPassword.Text.Trim();

            if (user == null || pass == null)
            {
                lblMensaje.Text = "Ingrese usuario y contraseña";
                lblMensaje.Visible = true;
                return;
            }
            if (validarUsuario(user, pass))
            {
                Response.Redirect("Principal.aspx");
            }
            else
            {
                lblMensaje.Text = "Ingrese usuario y contraseña";
                lblMensaje.Visible = true;
            }
        }

        private bool validarUsuario(string user, string pass)
        {
            bool validado = false;

            string cadena = ConfigurationManager.ConnectionStrings["Carrito"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("sp_loginUsuario", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.Parameters.AddWithValue("@pass", pass);
                    
                    object resultado = cmd.ExecuteScalar();

                    if (resultado != null)
                    {
                        validado = true;
                        Session["UserId"] = Convert.ToInt32(resultado);
                    }
                }
            }
            
            return validado;
        }
        
    }
}