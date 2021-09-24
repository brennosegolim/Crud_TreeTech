using Crud_TreeTech_API.Builder;
using Crud_TreeTech_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Facade
{
    public class ClassificacaoAlarmeFacade
    {
        public List<ClassificacaoAlarmesDTO> ListarTodos()
        {
            return ClassificacaoAlarmeBuilder.NovaClassificaoAlarme().ListaTodos();
        }

        public ClassificacaoAlarmesDTO ListaUm(int idClassificacaoAlarme)
        {
            return ClassificacaoAlarmeBuilder.NovaClassificaoAlarme().comIdClassificacaoAlarme(idClassificacaoAlarme).ListaUm();
        }

        public string CadastrarClassificaoAlarme(string nmClassificacaoAlarme, bool enviarEmail ,string observacao)
        {
            if (ClassificacaoAlarmeBuilder.NovaClassificaoAlarme().comNmClassificacaoAlarme(nmClassificacaoAlarme).comEnviarEmail(enviarEmail).comObservacao(observacao).GravarClassificacaoAlarme())
            {
                return "Classificação de alarme cadastrada com sucesso!";
            }
            else
            {
                return "Erro durante o processo de cadastro de classificação de alarme";
            }
        }

        public string AtualizarClassificacaoAlarme(int idClassificacaoAlarme, string nmClassificacaoAlarme, bool enviarEmail, string observacao)
        {
            if (ClassificacaoAlarmeBuilder.NovaClassificaoAlarme().comIdClassificacaoAlarme(idClassificacaoAlarme).comNmClassificacaoAlarme(nmClassificacaoAlarme)
                                          .comEnviarEmail(enviarEmail).comObservacao(observacao).AtualizarClassificacaoAlarme())
            {
                return "Classificação de alarme atualizada com sucesso!";
            }
            else
            {
                return "Erro durante o processo de atualização de classificação de alarme";
            }
        }

        public string DeletarClassificacaoAlarme(int idClassificacaoAlarme)
        {
            if (ClassificacaoAlarmeBuilder.NovaClassificaoAlarme().comIdClassificacaoAlarme(idClassificacaoAlarme).DeletarClassificaoAlarme())
            {
                return "Classificação de alarme deletada com sucesso!";
            }
            else
            {
                return "Erro durante o processo de remoção de classificação de alarme";
            }
        }
    }
}
