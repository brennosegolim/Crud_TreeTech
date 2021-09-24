using Crud_TreeTech_API.Data;
using Crud_TreeTech_API.DTO;
using Crud_TreeTech_API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.DAO.ClassificacaoAlarmeDAO
{
    public class ClassificacaoAlarmeDAO : IClassificacaoAlarmeDAO
    {
        /// <summary>
        /// Método para retornar todos os registros da tabela de classificação de alarme.
        /// </summary>
        /// <returns>Lista de classificação de alarme</returns>
        public List<ClassificacaoAlarmesDTO> ListarTodos()
        {
            List<ClassificacaoAlarmesDTO> classificacaoAlarmes = new List<ClassificacaoAlarmesDTO>();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("SelectAll_Classificacao_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassificacaoAlarmesDTO classificacaoAlarmesDTO = new ClassificacaoAlarmesDTO()
                        {
                            IdClassificacaoAlarme = Int32.Parse(reader["ID_Classificacao_Alarme"].ToString()),
                            NomeClassificacaoAlarme = reader["NM_Classificacao_Alarme"].ToString(),
                            EnviarEmail = Convert.ToBoolean(reader["Enviar_Email"].ToString()),
                            Observacao = reader["Observacao"].ToString()
                        };

                        classificacaoAlarmes.Add(classificacaoAlarmesDTO);
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

            return classificacaoAlarmes;
        }

        /// <summary>
        /// Método para retornar apenas um registro da Tabela de Classificacao de alarmes
        /// </summary>
        /// <param name="classificacaoAlarmes">Objeto Modelo de classificação de alarmes</param>
        /// <returns>Objeto de classificação de alarme</returns>
        public ClassificacaoAlarmesDTO ListarUm(ClassificacaoAlarmes classificacaoAlarmes)
        {
            ClassificacaoAlarmesDTO classificacaoAlarmesDTO = new ClassificacaoAlarmesDTO();

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Select_Classificacao_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Classificacao_Alarme", classificacaoAlarmes.IdClassificacaoAlarme));
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        classificacaoAlarmesDTO = new ClassificacaoAlarmesDTO()
                        {
                            IdClassificacaoAlarme = Int32.Parse(reader["ID_Classificacao_Alarme"].ToString()),
                            NomeClassificacaoAlarme = reader["NM_Classificacao_Alarme"].ToString(),
                            EnviarEmail = Convert.ToBoolean(reader["Enviar_Email"].ToString()),
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
            return classificacaoAlarmesDTO;
        }

        /// <summary>
        /// Método para cadastrar um novo classificação de alarme
        /// </summary>
        /// <param name="classificacaoAlarmes">Objeto modelo de classificação de alarmes</param>
        /// <returns>
        ///     True  - Sucesso
        ///     False - Falha 
        /// </returns>
        public bool Cadastrar(ClassificacaoAlarmes classificacaoAlarmes)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Insert_Classificacao_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@NM_Classificacao_Alarme", classificacaoAlarmes.NomeClassificacaoAlarme));
                    command.Parameters.Add(new SqlParameter("@Enviar_Email", classificacaoAlarmes.EnviarEmail));
                    command.Parameters.Add(new SqlParameter("@Observacao", classificacaoAlarmes.Observacao));
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
        /// Método para atualizar os valores da tabela de tipo de equipamento
        /// </summary>
        /// <param name="classificacaoAlarmes">Objeto modelo de classificacao de alarme</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Atualizar(ClassificacaoAlarmes classificacaoAlarmes)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Update_Classificacao_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Tipo_Equipamento", classificacaoAlarmes.IdClassificacaoAlarme));
                    command.Parameters.Add(new SqlParameter("@NM_Classificacao_Alarme", classificacaoAlarmes.NomeClassificacaoAlarme));
                    command.Parameters.Add(new SqlParameter("@Enviar_Email", classificacaoAlarmes.EnviarEmail));
                    command.Parameters.Add(new SqlParameter("@Observacao", classificacaoAlarmes.Observacao));
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
        /// Método para deletar registro da tabela de classificação Alarme
        /// </summary>
        /// <param name="classificacaoAlarmes">Objeto modelo de classificação de alarmes</param>
        /// <returns>
        ///     True  - Sucesso 
        ///     False - Falha 
        /// </returns>
        public bool Deletar(ClassificacaoAlarmes classificacaoAlarmes)
        {
            bool aux = false;

            SqlConnection conn = new ConnectSQLServer().GetConnection();

            try
            {
                using (SqlCommand command = new SqlCommand("Delete_Classificacao_Alarmes", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@ID_Classficacao_Alarme", classificacaoAlarmes.IdClassificacaoAlarme));
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
