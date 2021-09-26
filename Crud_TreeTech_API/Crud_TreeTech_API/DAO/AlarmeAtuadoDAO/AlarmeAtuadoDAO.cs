using Crud_TreeTech_API.Data;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.AlarmeAtuadoDAO
{
    public class AlarmeAtuadoDAO : IAlarmeAtuadoDAO
    {
        /// <summary>
        /// Método para retornar todos os registros da tabela de alarmes atuados.
        /// </summary>
        /// <returns>Lista de alarmes atuados</returns>
        public List<AlarmesAtuadosDTO> ListarTodos()
        {
            List<AlarmesAtuadosDTO> alarmesAtuados = new List<AlarmesAtuadosDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("SelectAll_Alarmes_Atuados", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AlarmesAtuadosDTO alarmesAtuadosDTO = new AlarmesAtuadosDTO()
                        {
                            IdAlarmesAtuados = Int32.Parse(reader["ID_Alarme_Atuado"].ToString()),
                            DataEntrada = Convert.ToDateTime(reader["DT_Entrada"]),
                            DataSaida = Convert.ToDateTime(reader["DT_Saida"]),
                            IdAlarme = Int32.Parse(reader["ID_Alarme"].ToString())
                        };

                        alarmesAtuados.Add(alarmesAtuadosDTO);
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

            return alarmesAtuados;
        }

        /// <summary>
        /// Método para retornar apenas um registro da Tabela de tipos de equipamento
        /// </summary>
        /// <param name="alamesAtuados">Objeto Modelo do tipo de equipamentos</param>
        /// <returns>Objeto de Tipo de equipamento</returns>
        public AlarmesAtuadosDTO ListarUm(AlarmesAtuados alarmesAtuados)
        {
            AlarmesAtuadosDTO alarmesAtuadosDTO = new AlarmesAtuadosDTO();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Select_Alarmes_Atuados", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Alarme_Atuado", alarmesAtuados.IdAlarmeAtuado));
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        alarmesAtuadosDTO = new AlarmesAtuadosDTO()
                        {
                            IdAlarmesAtuados = Int32.Parse(reader["ID_Alarme_Atuado"].ToString()),
                            DataEntrada = Convert.ToDateTime(reader["DT_Entrada"]),
                            DataSaida = Convert.ToDateTime(reader["DT_Saida"]),
                            IdAlarme = Int32.Parse(reader["ID_Alarme"].ToString())
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
            return alarmesAtuadosDTO;
        }

        /// <summary>
        /// Método para cadastrar um novo alarme atuado
        /// </summary>
        /// <param name="alarmesAtuados">Objeto modelo do alarme atuado</param>
        /// <returns>
        ///     True  - Sucesso
        ///     False - Falha 
        /// </returns>
        public bool Cadastrar(AlarmesAtuados alarmesAtuados)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Insert_Alarmes_Atuados", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@DT_Entrada", alarmesAtuados.DataEntrada));
                    command.Parameters.Add(new SqlParameter("ID_Alarme", alarmesAtuados.IdAlarme));
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
        /// Método para atualizar os valores da tabela de alarmes atuados
        /// </summary>
        /// <param name="alarmesAtuados">Objeto modelo de alarme atuado</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Atualizar(AlarmesAtuados alarmesAtuados)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Update_Alarmes_Atuados", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Alarme", alarmesAtuados.IdAlarme));
                    command.Parameters.Add(new SqlParameter("@DT_Saida", alarmesAtuados.DataSaida));
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
        /// Método para deletar registro da tabela de alarmes atuados
        /// </summary>
        /// <param name="alarmesAtuados">Objeto modelo do alarme atuado</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Deletar(AlarmesAtuados alarmesAtuados)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Delete_Alarmes_Atuados", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Alarme_Atuado", alarmesAtuados.IdAlarmeAtuado));
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
        /// 
        /// </summary>
        /// <returns></returns>
        public List<AlarmesAtuadosDTO> rankingAlarmes()
        {
            List<AlarmesAtuadosDTO> alarmesAtuados = new List<AlarmesAtuadosDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            string sql = @"SELECT TOP 3 COUNT(ID_Alarme) as Qtd,
                                  ID_Alarme as Id_Alarme 
                           FROM Alarmes_Atuados 
                           GROUP BY ID_Alarme
                           ORDER BY COUNT(ID_Alarme) DESC";

            try
            {
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AlarmesAtuadosDTO alarmesAtuadosDTO = new AlarmesAtuadosDTO()
                        {
                            IdAlarme = Int32.Parse(reader["ID_Alarme"].ToString()),
                            Quantidade = Int32.Parse(reader["Qtd"].ToString())
                        };

                        alarmesAtuados.Add(alarmesAtuadosDTO);
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

            return alarmesAtuados;
        }

    }
}
