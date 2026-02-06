using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class Posicao
  {
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public virtual ICollection<Participante> Participantes { get; private set; }
    public Posicao(int id, string nome)
    {
      Id = id;
      Nome = nome;
    }
  }
}
