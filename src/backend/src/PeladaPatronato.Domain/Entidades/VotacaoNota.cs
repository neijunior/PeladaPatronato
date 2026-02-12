using PeladaPatronato.Infra.CrossCutting.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class VotacaoNota : Entity
  {
    public string PeriodoVotacao { get; private set; } = null!; 
    public Guid ParticipanteId { get; private set; }
    public string HashVotante { get; private set; } = null!; //Quem votou;
    public decimal Nota { get; private set; }
    public DateTime DataVoto { get; private set; }
    protected VotacaoNota() { } // EF

    public VotacaoNota(string periodoVotacao, Guid participanteId, string hashVotante, decimal nota)
    {
      PeriodoVotacao = periodoVotacao;
      ParticipanteId = participanteId;
      HashVotante = hashVotante;
      Nota = nota;
      DataVoto = DateTime.Now;
    }

  }

  //Validação de voto;
//  var hash = GeradorHashVotacao.GerarHashVotante(
//    jogadorVotanteId,
//    partidaId,
//    chaveSecreta);

//    var jaVotou = await _context.VotosNotaJogador
//        .AnyAsync(x => x.PartidaId == partidaId
//                    && x.HashVotante == hash);

//if (jaVotou)
//{
//    throw new Exception("Você já votou nesta partida.");
//}
}
