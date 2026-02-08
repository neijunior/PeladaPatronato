using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Domain.Entidades
{
  public class RodadaPartida
  {
    public Guid Id { get; private set; }
    public Guid RodadaTimeAId { get; private set; }
    public Guid RodadaTimeBId { get; private set; }

    public int GolsTimeA { get; private set; }
    public int GolsTimeB { get; private set; }

    protected RodadaPartida() { }

    public RodadaPartida(Guid timeAId, Guid timeBId, int golsA, int golsB)
    {
      Id = Guid.NewGuid();
      RodadaTimeAId = timeAId;
      RodadaTimeBId = timeBId;
      GolsTimeA = golsA;
      GolsTimeB = golsB;
    }
  }

}
