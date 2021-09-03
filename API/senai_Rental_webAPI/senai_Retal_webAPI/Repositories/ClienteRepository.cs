using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using senai_Rental_webAPI.Domains;
using senai_Rental_webAPI.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace senai_Rental_webAPI.Repositories
{
        public class ClienteRepository : IClienteRepository
        {
            private string stringConexao = "DATA SOURCE = DESKTOP-OAGJCNA\\SQLEXPRESS; initial catalog = T_Rental; user Id = SA; pwd = SENAI@132";
            public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdate = "UPDATE CLIENTE SET nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente, cnhCliente = @cnhCliente WHERE idCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                        cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                        cmd.Parameters.AddWithValue("@cnhCliente", clienteAtualizado.cnhCliente);
                        cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public ClienteDomain BuscarPorId(int idCliente)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySearch = "SELECT idCliente AS Id, CONCAT(nomeCliente, ' ', sobrenomeCliente) AS Nome, cnhCliente AS CNH FROM Cliente WHERE idCliente = @idCliente";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySearch, con))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        rdr = cmd.ExecuteReader();

                        if (rdr.Read())
                        {
                            ClienteDomain clienteBuscado = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[0]),
                                nomeCliente = rdr[1].ToString(),
                                cnhCliente = Convert.ToInt32(rdr[2])
                            };

                            return clienteBuscado;
                        }

                        return null;
                    }
                }
            }

            public void Cadastrar(ClienteDomain novoCliente)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryInsert = "INSERT INTO CLIENTE (nomeCliente, sobrenomeCliente, cnhCliente) VALUES (@nomeCliente, @sobrenomeCliente, @cnhCliente)";

                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                    {
                        cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                        cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                        cmd.Parameters.AddWithValue("@cnhCliente", novoCliente.cnhCliente);

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public void Deletar(int idCliente)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryDelete = "DELETE FROM CLIENTE WHERE idCliente = @idCliente";

                    using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                    {
                        cmd.Parameters.AddWithValue("@idCliente", idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }

            public List<ClienteDomain> ListarTodos()
            {
                List<ClienteDomain> listaClientes = new List<ClienteDomain>();

                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string querySelectAll = "SELECT idCliente AS Id, CONCAT(nomeCliente, ' ', sobrenomeCliente) AS Nome, cnhCliente AS CNH FROM Cliente";

                    con.Open();

                    SqlDataReader rdr;

                    using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                    {
                        rdr = cmd.ExecuteReader();

                        while (rdr.Read())
                        {
                            ClienteDomain cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(rdr[0]),
                                nomeCliente = rdr[1].ToString(),
                                cnhCliente = Convert.ToInt32(rdr[2])
                            };

                            listaClientes.Add(cliente);
                        }
                    }

                };

                return listaClientes;
            }
        }
    }

