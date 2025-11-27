using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class Rodada
  {
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public Guid IdLocal { get; set; }
    public Guid CriadorId { get; set; }
    public string Observacao { get; set; }

    public Rodada()
    {
      
    }
  }
}
