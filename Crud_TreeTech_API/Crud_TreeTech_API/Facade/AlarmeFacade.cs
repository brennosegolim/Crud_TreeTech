using Crud_TreeTech_API.Builder;
using Crud_TreeTech_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Facade
{
    public class AlarmeFacade
    {
        public List<AlarmesDTO> ListarTodos()
        {
            return AlarmeBuilder.NovoAlarme().ListaTodos();
        }

        public AlarmesDTO ListaUm(int idAlarme)
        {
            return AlarmeBuilder.NovoAlarme().comIdAlarme(idAlarme).ListaUm();
        }

        public string CadastrarAlarme(string nmAlarme, int idClassificacaoAlarme, int idEquipamento, DateTime dtCadastro, bool status)
        {
            if (AlarmeBuilder.NovoAlarme().comNmAlarme(nmAlarme).comIdClassificacaoAlarme(idClassificacaoAlarme).comIdEquipamento(idEquipamento).comDtCadastro(dtCadastro).comStatus(status).GravarAlarme())
            {
                return "Alarme cadastrado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de cadastro de alarme";
            }
        }

        public string AtualizarAlarme(int idAlarme, string nmAlarme, int idClassificacaoAlarme, int idEquipamento, bool status)
        {
            if (AlarmeBuilder.NovoAlarme().comIdAlarme(idAlarme).comNmAlarme(nmAlarme).comIdClassificacaoAlarme(idClassificacaoAlarme).comIdEquipamento(idEquipamento)
                             .comStatus(status).AtualizarAlarme())
            {
                return "Alarme atualizado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de atualização de de alarme";
            }
        }

        public string DeletarAlarme(int idAlarme)
        {
            if (AlarmeBuilder.NovoAlarme().comIdAlarme(idAlarme).DeletarAlarme())
            {
                return "Alarme deletado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de remoção de alarme";
            }
        }
    }
}
