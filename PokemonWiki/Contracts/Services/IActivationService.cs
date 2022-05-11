using System.Threading.Tasks;

namespace PokemonWiki.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
