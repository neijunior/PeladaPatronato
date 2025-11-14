using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class Participante
  {
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Apelido { get; set; }
    public ePosicao PosicaoPreferida { get; set; }
    public bool Ativo { get; set; }

    public Participante()
    {
      
    }

    public enum ePosicao
    {
      Goleiro = 1,
      Fixo = 2,
      Ala = 3,
      Pivo = 4
    }
  }
}
