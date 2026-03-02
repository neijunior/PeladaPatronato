using PeladaPatronato.Infra.CrossCutting.Response.Participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Response.Rodada
{
  public class RodadaResponse
  {
    public Guid Id { get; private set; }
    public DateTime DataHora { get; private set; }
    public decimal ValorDiarista { get; private set; }
    public string? Observacao { get; private set; }
    public ICollection<ParticipanteResponse> ListaParticipantes { get; set; } = new List<ParticipanteResponse>();
  }
}
