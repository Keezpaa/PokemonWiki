using System;

namespace PokemonWiki.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
