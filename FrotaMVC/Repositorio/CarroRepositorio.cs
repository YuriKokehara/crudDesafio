using FrotaMVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrotaMVC.Repositorio
{
    public class CarroRepositorio
    {

        private SqlConnection connection;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            connection = new SqlConnection(constr);
        }

        public bool AdicionarCarro(Carros carroObj)
        {
            Connection();

            int i;

            using (SqlCommand cmd = new SqlCommand("IncluirCarro", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Marca", carroObj.Marca);
                cmd.Parameters.AddWithValue("@Modelo", carroObj.Modelo);
                cmd.Parameters.AddWithValue("@Cor", carroObj.Cor);
                cmd.Parameters.AddWithValue("@AnoFabric", carroObj.AnoFabric);

                connection.Open();

                i = cmd.ExecuteNonQuery();

            }

            connection.Close();

            return i >= 1;
        }

        public List<Carros> ListarCarros()
        {
            Connection();
            List<Carros> carrosList = new List<Carros>();

            using (SqlCommand cmd = new SqlCommand("ListarCarros", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Carros carro = new Carros()
                    {
                        IdCarro = Convert.ToInt32(reader["IdCarro"]),
                        Marca = Convert.ToString(reader["Marca"]),
                        Modelo = Convert.ToString(reader["Modelo"]),
                        Cor = Convert.ToString(reader["Cor"]),
                        AnoFabric = Convert.ToInt32(reader["AnoFabric"])
                    };

                    carrosList.Add(carro);
                }

                connection.Close();

                return carrosList;

            }
        }

        public bool AtualizarCarro(Carros carroObj)
        {
            Connection();

            int i;

            using (SqlCommand cmd = new SqlCommand("AtualizarCarro", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCarro", carroObj.IdCarro);
                cmd.Parameters.AddWithValue("@Marca", carroObj.Marca);
                cmd.Parameters.AddWithValue("@Modelo", carroObj.Modelo);
                cmd.Parameters.AddWithValue("@Cor", carroObj.Cor);
                cmd.Parameters.AddWithValue("@AnoFabric", carroObj.AnoFabric);

                connection.Open();

                i = cmd.ExecuteNonQuery();

            }

            connection.Close();

            return i >= 1;
        }

        public bool ExcluirCarro(int id)
        {
            Connection();

            int i;

            using (SqlCommand cmd = new SqlCommand("ExcluirCarroPorId", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCarro", id);

                connection.Open();

                i = cmd.ExecuteNonQuery();

            }

            connection.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
        }
    }
}