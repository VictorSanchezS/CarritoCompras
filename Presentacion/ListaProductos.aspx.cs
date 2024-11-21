using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class ListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }

        }
        private void cargarDatos()
        {
            string cadena = ConfigurationManager.ConnectionStrings["Carrito"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cadena))
            {
                using (SqlCommand comando = new SqlCommand("sp_listarProductos", con))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataAdapter adap = new SqlDataAdapter(comando))
                    {
                        DataTable dt = new DataTable();
                        adap.Fill(dt);

                        RepeaterProductos.DataSource = dt;
                        RepeaterProductos.DataBind();
                    }
                }
            }
        }

        protected void btn_Agregar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int IdPro = Convert.ToInt32(btn.CommandArgument);
            List<int> carrito = Session["carrito"] as List<int> ?? new List<int>();
            carrito.Add(IdPro);
            Session["carrito"] = carrito;

            // Corregido: Agregar paréntesis a GetType()
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Producto agregado al carrito');", true);
        }

    }
}