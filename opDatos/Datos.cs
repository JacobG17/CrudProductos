using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace opDatos
{
    public class Datos
    {
        string cadenaConexion = "Data Source = localhost; Initial Catalog = Productos; User ID = sa; Password = Admin2023;";
        string query;
        DataTable tabla = new DataTable();
        List<Producto> productos = new List<Producto>();

        //Funcion para obtener los datos de la tabla Productos
        public DataTable obtenerProductos()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    tabla.Clear();
                    connection.Open();
                    query = "SELECT * FROM Productos";
                    using (SqlDataAdapter command = new SqlDataAdapter(query, connection))
                    {
                        command.Fill(tabla);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabla;
        }

        //Funcion para insertar datos en la tabla Productos
        public void agregarProducto(int id, string descripcion, int precio, int saldo)
        {
            try
            {
                using (SqlConnection connecion = new SqlConnection(cadenaConexion))
                {
                    query = $"INSERT INTO Productos (ProductID, Descripcion, PrecioVenta, Saldo) VALUES({id}, '{descripcion}', {precio}, {saldo})";
                    connecion.Open();
                    using (SqlCommand comand = new SqlCommand(query, connecion))
                    {
                        comand.ExecuteNonQuery();
                    }
                    connecion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Funcion para actualizar datos en la tabla Productos
        public void actualizarProducto(int id, string descripcion, int precio, int saldo)
        {
            try
            {
                using (SqlConnection connecion = new SqlConnection(cadenaConexion))
                {
                    query = $"UPDATE Productos SET Descripcion = '{descripcion}', PrecioVenta = {precio}, Saldo = {saldo} WHERE ProductID = {id};";
                    connecion.Open();
                    using (SqlCommand comand = new SqlCommand(query, connecion))
                    {
                        comand.ExecuteNonQuery();
                    }
                    connecion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Funcion para obtener los datos de un producto de la tabla Productos
        public string[] ObtenerDatosProducto(int idProducto)
        {
            string[] datosProducto = new string[4];
            try
            {
                query = $"SELECT ProductID, Descripcion, PrecioVenta, Saldo FROM Productos WHERE ProductID = {idProducto}";

                using (SqlConnection connction = new SqlConnection(cadenaConexion))
                {
                    connction.Open();

                    using (SqlCommand command = new SqlCommand(query, connction))
                    {
                        using (SqlDataReader lector = command.ExecuteReader())
                        {
                            if (lector.Read())
                            {
                                datosProducto[0] = lector["ProductID"].ToString();
                                datosProducto[1] = lector["Descripcion"].ToString();
                                datosProducto[2] = lector["PrecioVenta"].ToString();
                                datosProducto[3] = lector["Saldo"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            return datosProducto;
        }

        //Funcion para hacer un conteo de los datos dentro de la tabla Productos
        public int obtenerConteoProductos(int opcion)
        {
            if(opcion == 1)
            {
                query = "SELECT MAX(ProductID) FROM Productos";
            }
            else
            {
                query = "SELECT COUNT(*) FROM Inventario";
            }
            int cantidad = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        cantidad = (int)command.ExecuteScalar();
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
            return cantidad;
        }

        //Funcion para eliminar los datos de un producto de la tabla Productos
        public void eliminarProducto(int idProducto)
        {
            query = $"DELETE FROM Productos WHERE ProductID = {idProducto}";

            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Funcion que realiza Transaccion de los datos
        public void transaccionGuardarDatos(List<Producto> Datosproductos, int folio)
        {
            productos.Clear();
            productos = Datosproductos;
            HashSet<int> productIDsProcesados = new HashSet<int>();
            productIDsProcesados.Clear();

            //Obtiene la suma total de los productos
            decimal sumaPrecioVentaTotal = productos.Sum(p => p.PrecioVenta);

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                try
                {
                    foreach (Producto producto in productos)
                    {
                        connection.Open();
                        // Ejecuta Store Procedure para realizar transaccion de productos
                        SqlCommand comando = new SqlCommand($"EXEC GuardarDatosVenta @Folio = {folio}, @sumaPrecioVentaTotal = {sumaPrecioVentaTotal}, @ProductID = {producto.ProductID}, @cantidad = {producto.Cantidad}", connection);

                        comando.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        //Funcion para deshacer transaccion de los datos
        public void rollbackTransaccion(List<DatosVentaDetalle> DatosVenta)
        {
            int folio = obtenerConteoProductos(2);

            int folioNuevo = obtenerConteoProductos(2) + 1;

            using (SqlConnection connection = new SqlConnection(cadenaConexion))
            {
                try
                {
                    foreach (DatosVentaDetalle datosDetalle in DatosVenta)
                    {
                        //Obtiene la suma total de los productos
                        decimal sumaPrecioVentaTotal = datosDetalle.Total;

                        //Obtiene cantidad de elementos de la lista productos
                        int cantidad = datosDetalle.Cantidad;

                        int productoID = datosDetalle.ProductID;

                        connection.Open();
                        // Ejecuta Store Procedure para realizar transaccion de productos
                        SqlCommand comando = new SqlCommand($"EXEC DeshacerTransaccion @Folio = {folio}, @folioNuevo = {folioNuevo}, @ProductID = {productoID}, @cantidad = {cantidad}, @sumaPrecioVentaTotal = {sumaPrecioVentaTotal}", connection);

                        comando.ExecuteNonQuery();

                        connection.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        //Funcion para obtener los datos de la tabla InventarioDetalle
        public DataTable obtenerInventarioDetalle()
        {
            tabla.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    query = "EXEC ObtenerDatosInventario;";
                    using (SqlDataAdapter command = new SqlDataAdapter(query, connection))
                    {
                        command.Fill(tabla);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return tabla;
        }

        //Funcion para obtener los datos de un Producto mediante su ID
        public List<Producto> datosProducto(int ID)
        {
            productos.Clear();
            try
            {
                using (SqlConnection connection = new SqlConnection(cadenaConexion))
                {
                    connection.Open();
                    query = $"SELECT * FROM Productos WHERE ProductID = {ID}";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader lector = command.ExecuteReader())
                        {
                            while (lector.Read())
                            {
                                Producto datosProducto = new Producto
                                {
                                    ProductID = Convert.ToInt32(lector["ProductID"]),
                                    Descripcion = lector["Descripcion"].ToString(),
                                    Cantidad = Convert.ToInt32(lector["Saldo"]),
                                    PrecioVenta = Convert.ToDecimal(lector["PrecioVenta"])
                                };
                                productos.Add(datosProducto);
                            }
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return productos;
        }
    }
}
