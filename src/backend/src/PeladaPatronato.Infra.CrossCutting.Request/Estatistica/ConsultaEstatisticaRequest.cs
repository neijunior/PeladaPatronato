using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Request.Estatistica
{
  public class ConsultaEstatisticaRequest
  {
    public string NomeParticipante { get; set; } = string.Empty;
    public int? IdPosicao { get; set; }
    public string Periodo { get; set; } = string.Empty;
    public DateTime? DataInicio { get; set; }
    public DateTime? DataFim { get; set; }

    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? OrderBy { get; set; }
    public string Direction { get; set; } = "asc";

    public ICollection<Ordenacao> ordenacoes { get; set; } = new List<Ordenacao>();
  }

  public class Ordenacao
  {
    public string Campo { get; set; } = string.Empty;
    public string Direcao { get; set; } = "asc";
  }
}
