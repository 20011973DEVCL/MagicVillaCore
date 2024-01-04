using MagicVilla.Models.Custom;

namespace MagicVilla.Services
{
    public interface IAutorizacionService
    {
        Task<AutorizacionResponse> DevolverToken(AutorizacionRequest autorizacion);
    }
}