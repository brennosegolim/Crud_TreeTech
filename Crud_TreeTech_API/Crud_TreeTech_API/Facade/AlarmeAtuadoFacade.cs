using Crud_TreeTech_API.Builder;
using Crud_TreeTech_API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_TreeTech_API.Facade
{
    public class AlarmeAtuadoFacade
    {
        public List<AlarmesAtuadosDTO> ListarTodos()
        {
            return AlarmeAtuadoBuilder.NovoAlarmeAtuado().ListaTodos();
        }

        public AlarmesAtuadosDTO ListaUm(int idAlarmeAtuado)
        {
            return AlarmeAtuadoBuilder.NovoAlarmeAtuado().comIdAlarmeAtuado(idAlarmeAtuado).ListaUm();
        }

        public string CadastrarAlarmeAtuado(DateTime dtEntrada, int IdAlarme)
        {
            if (AlarmeAtuadoBuilder.NovoAlarmeAtuado().comDtEntrada(dtEntrada).comIdAlarme(IdAlarme).GravarAlarmeAtuado())
            {
                return "Alarme atuado cadastrado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de cadastro de alarme atuado";
            }
        }

        public string AtualizarAlarmeAtuado(DateTime dtSaida, int idAlarme)
        {
            if (AlarmeAtuadoBuilder.NovoAlarmeAtuado().comDtSaida(dtSaida).comIdAlarme(idAlarme).AtualizarAlarmeAtuado())
            {
                return "Alarme atuado atualizado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de atualização de de alarme atuado";
            }
        }

        public string DeletarAlarmeAtuado(int idAlarmeAtuado)
        {
            if (AlarmeAtuadoBuilder.NovoAlarmeAtuado().comIdAlarmeAtuado(idAlarmeAtuado).DeletarAlarmeAtuado())
            {
                return "Alarme atuado deletado com sucesso!";
            }
            else
            {
                return "Erro durante o processo de remoção de alarme atuado";
            }
        }
    }
}
