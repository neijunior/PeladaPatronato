using PeladaPatronato.Application.Acesso;
using PeladaPatronato.Application.Request.Acesso;
using PeladaPatronato.Application.Response.Acesso;
using PeladaPatronato.Domain.Entidades;
using PeladaPatronato.Domain.Interfaces;
using PeladaPatronato.Infra.CrossCutting.Foundation;
using PeladaPatronato.Infra.CrossCutting.Security.Acesso;

namespace PeladaPatronato.Application.Core.Acesso
{
  public class AutenticacaoApplication : IAutenticacaoApplication
  {
    private readonly IParticipanteRepository _participanteRepository;
    private readonly IToken _token;

    public AutenticacaoApplication(IParticipanteRepository participanteRepository, IToken token)
    {
      _participanteRepository = participanteRepository;
      _token = token;
    }

    public async Task<LoginResponse> Login(LoginRequest request)
    {
      var participante = await _participanteRepository.ObterPorEmail(request.Email);

      if (participante == null)
        throw new Exception("Usuário não encontrado.");

      if (!participante.PossuiAcesso)
        throw new Exception("Usuário não possui acesso ao sistema.");

      if (!Senha.VerificarSenha(request.Senha, participante.SenhaHash!))
        throw new Exception("Senha inválida.");

      var token = _token.GerarToken(participante);

      return new LoginResponse
      {
        Token = token,
        Nome = participante.Nome,
        Perfil = participante.Perfil!.ToString()
      };
    }

    public async Task DefinirAcesso(DefinirAcessoRequest request)
    {
      var participante = await _participanteRepository.ObterPorId(request.ParticipanteId);

      if (participante == null)
        throw new Exception("Participante não encontrado");

      var hash = Criptografia.GerarHash(request.Senha);

      participante.DefinirAcesso(hash, request.Perfil);

      await _participanteRepository.Atualizar(participante);
    }

  }
}
