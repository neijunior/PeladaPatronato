using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PeladaPatronato.Domain.Enums;

namespace PeladaPatronato.Domain.Entidades
{
  public class Posicao
  {
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public eCategoriaPosicao CategoriaPosicao { get; private set; }
    public virtual ICollection<Participante> Participantes { get; private set; }
    public Posicao(int id, string nome, eCategoriaPosicao categoriaPosicao)
    {
      Id = id;
      Nome = nome;
      CategoriaPosicao = categoriaPosicao;
    }
  }
}
