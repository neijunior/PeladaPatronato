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
    public Guid Id { get; set; }
    public DateTime DataHora { get; set; }
    public decimal ValorDiarista { get; set; }
    public string? Observacao { get; set; }
    public string? DescricaoStatus { get; set; }
    public ICollection<RodadaParticipanteResponse> participantes { get; set; } = new List<RodadaParticipanteResponse>();
  }
}
