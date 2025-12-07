using PeladaPatronato.Application.Participante;
using PeladaPatronato.Application.Response.Participante;
using PeladaPatronato.Domain.Interfaces;

namespace PeladaPatronato.Application.Core.Participante
{
  public class ParticipanteApplication : IParticipanteApplication
  {
    private readonly IParticipanteRepository _participanteRepository;
    public ParticipanteApplication(IParticipanteRepository participanteRepository)
    {
      _participanteRepository = participanteRepository;
    }
    public async Task<ParticipanteResponse> Consultar(Guid Id)
    {
      return (await _participanteRepository.Consultar(Id)).ToResponse();
    }

    public async Task<ParticipanteResponse> Inativar()
    {
      return (await _participanteRepository.Inativar()).ToResponse();
    }

    public async Task<IEnumerable<ParticipanteResponse>> Listar()
    {
      return (await _participanteRepository.Listar()).ToResponse();   
    }

    public async Task<ParticipanteResponse> Salvar()
    {
      return (await _participanteRepository.Salvar()).ToResponse(); 
    }
  }
}
