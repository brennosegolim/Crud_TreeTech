using Crud_TreeTech_API.Data;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.EquipamentoDAO
{
    public class EquipamentoDAO : IEquipamentoDAO
    {
        /// <summary>
        /// Método para retornar todos os registros da tabela de tipo de equipamento.
        /// </summary>
        /// <returns>Lista de equipamentos</returns>
        public List<EquipamentosDTO> ListarTodos()
        {
            List<EquipamentosDTO> equipamentos = new List<EquipamentosDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("SelectAll_Equipamentos", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        EquipamentosDTO tipoEquipamentoDTO = new EquipamentosDTO()
                        {
                            IdEquipamento = Int32.Parse(reader["ID_Equipamento"].ToString()),
                            NomeEquipamento = reader["NM_Equipamento"].ToString(),
                            NumeroSerie = Int32.Parse(reader["NO_Serie"].ToString()),
                            IdTipoEquipamento = Int32.Parse(reader["ID_Tipo_Equipamento"].ToString()),
                            DataCadastro = Convert.ToDateTime(reader["DT_Cadastro"].ToString())
                        };

                        equipamentos.Add(tipoEquipamentoDTO);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return equipamentos;
        }

        /// <summary>
        /// Método para retornar apenas um registro da tabela de equipamentos
        /// </summary>
        /// <param name="equipamento">Objeto Modelo de equipamentos</param>
        /// <returns>Objeto de equipamentos</returns>
        public EquipamentosDTO ListarUm(Equipamentos equipamento)
        {
            EquipamentosDTO equipamentoDTO = new EquipamentosDTO();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Select_Equipamentos", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Equipamento", equipamento.IdEquipamento));
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        equipamentoDTO = new EquipamentosDTO()
                        {
                            IdEquipamento = Int32.Parse(reader["ID_Equipamento"].ToString()),
                            NomeEquipamento = reader["NM_Equipamento"].ToString(),
                            NumeroSerie = Int32.Parse(reader["NO_Serie"].ToString()),
                            IdTipoEquipamento = Int32.Parse(reader["ID_Tipo_Equipamento"].ToString()),
                            DataCadastro = Convert.ToDateTime(reader["DT_Cadastro"].ToString())
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return equipamentoDTO;
        }

        /// <summary>
        /// Método para cadastrar um novo equipamento
        /// </summary>
        /// <param name="equipamento">Objeto modelo de equipamento</param>
        /// <returns>
        ///     True  - Sucesso
        ///     False - Falha 
        /// </returns>
        public bool Cadastrar(Equipamentos equipamento)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Insert_Equipamentos", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@NM_Equipamento", equipamento.NomeEquipamento));
                    command.Parameters.Add(new SqlParameter("@NO_Serie", equipamento.NumeroSerie));
                    command.Parameters.Add(new SqlParameter("@ID_Tipo_Equipamento", equipamento.IdTipoEquipamento));
                    command.Parameters.Add(new SqlParameter("@DT_Cadastro", equipamento.DataCadastro));
                    conn.Open();
                    command.ExecuteNonQuery();

                    aux = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return aux;
        }

        /// <summary>
        /// Método para atualizar os valores da tabela de equipamentos
        /// </summary>
        /// <param name="equipamento">Objeto modelo de equipamentos</param>
        /// <returns>
        ///     True  - Sucesso |
        ///     False - Falha 
        /// </returns>
        public bool Atualizar(Equipamentos equipamento)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Update_Equipamentos", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@IdEquipamento", equipamento.IdEquipamento));
                    command.Parameters.Add(new SqlParameter("@NM_Equipamento", equipamento.NomeEquipamento));
                    command.Parameters.Add(new SqlParameter("@NO_Serie", equipamento.NumeroSerie));
                    command.Parameters.Add(new SqlParameter("@ID_Tipo_Equipamento", equipamento.IdTipoEquipamento));
                    conn.Open();
                    command.ExecuteNonQuery();

                    aux = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return aux;
        }

        /// <summary>
        /// Método para deletar registro da tabela de equipamento
        /// </summary>
        /// <param name="equipamento">Objeto modelo de equipamentos</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Deletar(Equipamentos equipamento)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Delete_Equipamentos", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Equipamento", equipamento.IdEquipamento));
                    conn.Open();
                    command.ExecuteNonQuery();

                    aux = true;
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return aux;
        }
    }
}
