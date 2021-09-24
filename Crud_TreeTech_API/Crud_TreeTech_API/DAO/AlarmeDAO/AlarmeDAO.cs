using Crud_TreeTech_API.Data;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.AlarmeDAO
{
    public class AlarmeDAO : IAlarmeDAO
    {
        /// <summary>
        /// Método para retornar todos os registros da tabela de alarmes.
        /// </summary>
        /// <returns>Lista de alarmes</returns>
        public List<AlarmesDTO> ListarTodos()
        {
            List<AlarmesDTO> alarmes = new List<AlarmesDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("SelectAll_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AlarmesDTO alarmesDTO = new AlarmesDTO()
                        {
                            IdAlarme = Int32.Parse(reader["ID_Alarme"].ToString()),
                            NomeAlarme = reader["NM_Alarme"].ToString(),
                            IdClassificacaoAlarme = Int32.Parse(reader["ID_Classificacao_Alarme"].ToString()),
                            IdEquipamento = Int32.Parse(reader["ID_Equipamento"].ToString()),
                            DataCadastro = Convert.ToDateTime(reader["DT_Cadastro"].ToString()),
                            Status = Convert.ToBoolean(reader["Status"].ToString())
                        };

                        alarmes.Add(alarmesDTO);
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

            return alarmes;
        }

        /// <summary>
        /// Método para retornar apenas um registro da tabela de alarmes
        /// </summary>
        /// <param name="alarmes">Objeto Modelo de alarme</param>
        /// <returns>Objeto de alarmes</returns>
        public AlarmesDTO ListarUm(Alarmes alarmes)
        {
            AlarmesDTO alarmesDTO = new AlarmesDTO();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Select_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Alarme", alarmes.IdAlarme));
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        alarmesDTO = new AlarmesDTO()
                        {
                            IdAlarme = Int32.Parse(reader["ID_Alarme"].ToString()),
                            NomeAlarme = reader["NM_Alarme"].ToString(),
                            IdClassificacaoAlarme = Int32.Parse(reader["ID_Classificacao_Alarme"].ToString()),
                            IdEquipamento = Int32.Parse(reader["ID_Equipamento"].ToString()),
                            DataCadastro = Convert.ToDateTime(reader["DT_Cadastro"].ToString()),
                            Status = Convert.ToBoolean(reader["Status"].ToString())
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
            return alarmesDTO;
        }

        /// <summary>
        /// Método para cadastrar um novo alarme
        /// </summary>
        /// <param name="alarmes">Objeto modelo de alarme</param>
        /// <returns>
        ///     True  - Sucesso
        ///     False - Falha 
        /// </returns>
        public bool Cadastrar(Alarmes alarmes)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Insert_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@NM_Alarme", alarmes.IdAlarme));
                    command.Parameters.Add(new SqlParameter("@ID_Classificacao_Alarme", alarmes.IdClassificacaoAlarme));
                    command.Parameters.Add(new SqlParameter("@ID_Equipamento", alarmes.IdEquipamento));
                    command.Parameters.Add(new SqlParameter("@DT_Cadastro", alarmes.DataCadastro));
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
        /// Método para atualizar os valores da tabela de alarmes
        /// </summary>
        /// <param name="alarmes">Objeto modelo de alarmes</param>
        /// <returns>
        ///     True  - Sucesso |
        ///     False - Falha 
        /// </returns>
        public bool Atualizar(Alarmes alarmes)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Update_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Alarme", alarmes.IdAlarme));
                    command.Parameters.Add(new SqlParameter("@NM_Alarme", alarmes.IdAlarme));
                    command.Parameters.Add(new SqlParameter("@ID_Classificacao_Alarme", alarmes.IdClassificacaoAlarme));
                    command.Parameters.Add(new SqlParameter("@ID_Equipamento", alarmes.IdEquipamento));
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
        /// Método para deletar registro da tabela de alarmes
        /// </summary>
        /// <param name="alarmes">Objeto modelo de alarmes</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Deletar(Alarmes alarmes)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Delete_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Alarme", alarmes.IdAlarme));
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
