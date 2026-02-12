using PeladaPatronato.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeladaPatronato.Application.Request.Acesso
{
  public class DefinirAcessoRequest
  {
    public Guid ParticipanteId { get; set; }
    public string Senha { get; set; } = string.Empty;
    public PerfilAcesso Perfil { get; set; }
  }
}
