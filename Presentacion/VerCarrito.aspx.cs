using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Presentacion
{
    public partial class VerCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarCarrito();
            }
        }

        

        protected void ConfirmarCompra_Click(object sender, EventArgs e)
        {
            List<int> carrito = Session["Carrito"] as List<int>;
            if (carrito == null || carrito.Count == 0)
            {
                PanelCarritoVacio.Visible = true;
                PanelCarritoCompras.Visible = false;
                
                return;
            }
            String cadena = ConfigurationManager.ConnectionStrings["Carrito"].ConnectionString;
            String sp = "sp_ObtenerDatosCarrito";
            Decimal total = 0;
            List<dynamic> productos = new List<dynamic>();
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                string id = string.Join(",", carrito);
                using (SqlCommand comando = new SqlCommand(sp, con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@idPro", SqlDbType.VarChar)).Value = id;

                    using (SqlDataReader read = comando.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            int idPro = read.GetInt32(0);
                            decimal precio = read.GetDecimal(2);
                            total += precio;
                            productos.Add(new { IdProducto = idPro, Cantidad = 1, Precio = precio });

                        }
                    }
                }
            }

            string productosJ = JsonConvert.SerializeObject(productos);
            using (SqlConnection con = new SqlConnection(cadena))
            {
                con.Open();
                string proc = "sp_ConfirmarCompra";

                using (SqlCommand comando = new SqlCommand(proc, con))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdUSuario", SqlDbType.Int)).Value = 1;
                    comando.Parameters.Add(new SqlParameter("@total", SqlDbType.Decimal)).Value = total;
                    comando.Parameters.Add(new SqlParameter("@fecha", SqlDbType.DateTime)).Value = DateTime.Now;
                    comando.Parameters.Add(new SqlParameter("@productos", SqlDbType.VarChar)).Value = productosJ;
                    comando.ExecuteNonQuery();
                }
                Response.Redirect("ListaProductos.aspx");
            }
        }

        public void cargarCarrito()
        {
            List<int> carrito = Session["Carrito"] as List<int>;
            decimal total = 0;
            if (carrito == null)
            {
                PanelCarritoVacio.Visible = true;
                PanelCarritoCompras.Visible = false;
                ConfirmarCompra.Visible = false;
                return;
            }

            string cadena = ConfigurationManager.ConnectionStrings["Carrito"].ConnectionString;
            string sp = "sp_ObtenerDatosCarrito";
            DataTable tabla = new DataTable();
            using (SqlConnection conn = new SqlConnection(cadena))
            {
                conn.Open();
                string ids = string.Join(",", carrito);
                using (SqlCommand cmd = new SqlCommand(sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@idPro", SqlDbType.VarChar)).Value = ids;
                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {
                        adap.Fill(tabla);
                    }
                }
                foreach (DataRow row in tabla.Rows)
                {
                    total += Convert.ToDecimal(row["precio"]);
                }
            }
            Repeater1.DataSource = tabla;
            Repeater1.DataBind();
            lblTotal.Text = total.ToString("F2");
            PanelCarritoVacio.Visible = false;
            PanelCarritoCompras.Visible = true;

        }
    }
}