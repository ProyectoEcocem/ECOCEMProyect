

namespace ECOCEMProject;

    public interface IAutorizacionService
    {

        Task<AutorizacionResponse> DevolverToken(LoginModel autorizacion);
        // Task<AutorizacionResponse> DevolverRefreshToken(RefreshTokenRequest refreshTokenRequest, int idUsuario);
    }
