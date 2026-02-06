using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.Data.EntityFrameworkCore.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.Data.EntityFrameworkCore.Repositories
{
  public class PosicaoRepository : RepositoryBase<Posicao>, IPosicaoRepository
  {
    public PosicaoRepository(PeladaPatronatoDbContext context) : base(context)
    {
    }
  }
}
