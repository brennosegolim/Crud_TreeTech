using Crud_TreeTech_API.Data;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.TipoEquipamentoDAO
{
    public class TipoEquipamentoDAO : ITipoEquipamentoDAO
    {
        /// <summary>
        /// Método para retornar todos os registros da tabela de tipo de equipamento.
        /// </summary>
        /// <returns>Lista de tipo de equipamentos</returns>
        public List<TipoEquipamentoDTO> ListarTodos()
        {
            List<TipoEquipamentoDTO> tipoEquipamentos = new List<TipoEquipamentoDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("SelectAll_Tipo_Equipamento", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TipoEquipamentoDTO tipoEquipamentoDTO = new TipoEquipamentoDTO()
                        {
                            IdTipoEquipamento = Int32.Parse(reader["ID_Tipo_Equipamento"].ToString()),
                            NomeTipoEquipamento = reader["NM_Tipo_Equipamento"].ToString(),
                            Observacao = reader["Observacao"].ToString()
                        };

                        tipoEquipamentos.Add(tipoEquipamentoDTO);
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

            return tipoEquipamentos;
        }

        /// <summary>
        /// Método para retornar apenas um registro da Tabela de tipos de equipamento
        /// </summary>
        /// <param name="tipoEquipamento">Objeto Modelo do tipo de equipamentos</param>
        /// <returns>Objeto de Tipo de equipamento</returns>
        public TipoEquipamentoDTO ListarUm(TipoEquipamento tipoEquipamento)
        {
            TipoEquipamentoDTO tipoEquipamentoDTO = new TipoEquipamentoDTO();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Select_Tipo_Equipamento", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Tipo_Equipamento", tipoEquipamento.IdTipoEquipamento));
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        tipoEquipamentoDTO = new TipoEquipamentoDTO()
                        {
                            IdTipoEquipamento = Int32.Parse(reader["ID_Tipo_Equipamento"].ToString()),
                            NomeTipoEquipamento = reader["NM_Tipo_Equipamento"].ToString(),
                            Observacao = reader["Observacao"].ToString()
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
            return tipoEquipamentoDTO;
        }

        /// <summary>
        /// Método para cadastrar um novo tipo de equipamento
        /// </summary>
        /// <param name="tipoEquipamento">Objeto modelo do tipo de equipamento</param>
        /// <returns>
        ///     True  - Sucesso
        ///     False - Falha 
        /// </returns>
        public bool Cadastrar(TipoEquipamento tipoEquipamento)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Insert_Tipo_Equipamento",conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@NM_Tipo_Equipamento", tipoEquipamento.NomeTipoEquipamento));
                    command.Parameters.Add(new SqlParameter("@Observacao",tipoEquipamento.Observacao));
                    conn.Open();
                    command.ExecuteNonQuery();

                    aux = true;
                }
            }
            catch(SqlException ex)
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
        /// Método para atualizar os valores da tabela de tipo de equipamento
        /// </summary>
        /// <param name="tipoEquipamento">Objeto modelo do tipo de equipamento</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Atualizar(TipoEquipamento tipoEquipamento)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Update_Tipo_Equipamento", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Tipo_Equipamento",tipoEquipamento.IdTipoEquipamento));
                    command.Parameters.Add(new SqlParameter("@NM_Tipo_Equipamento", tipoEquipamento.NomeTipoEquipamento));
                    command.Parameters.Add(new SqlParameter("@Observacao", tipoEquipamento.Observacao));
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
        /// Método para deletar registro da 
        /// </summary>
        /// <param name="tipoEquipamento">Objeto modelo do tipo equipamento</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Deletar(TipoEquipamento tipoEquipamento)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Delete_Tipo_Equipamento", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Tipo_Equipamento", tipoEquipamento.IdTipoEquipamento));
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
