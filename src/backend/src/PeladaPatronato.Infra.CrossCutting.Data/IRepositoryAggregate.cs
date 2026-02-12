using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Infra.CrossCutting.Data
{
  public interface IRepositoryAggregate<T> where T : IAggregateRoot
  {

  }
}
