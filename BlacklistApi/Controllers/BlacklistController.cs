using BlacklistApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlacklistApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BlacklistController : ControllerBase
{
    private static List<Blacklist> blacklists = new List<Blacklist>();

    [HttpPost]
    public void AddBlacklist([FromBody] Blacklist blacklist)
    {
        blacklists.Add(blacklist);
    }

    [HttpGet]
    public IEnumerable<Blacklist> GetBlacklist()
    {
        return blacklists;  
    }

    [HttpDelete]
    public void DeleteBlacklist(Blacklist blacklist)
    {
        blacklists.Remove(blacklist);
    }

    [HttpPut]
    public void AtualizaBlacklist(int posicao, Blacklist blacklistAtualizado)
    {
        var blacklistExiste = blacklists
            .Find(b => b.Posicao == posicao);

        if (blacklistExiste is null)
        {
            NotFound();
        }

        blacklistExiste.Nome = blacklistAtualizado.Nome;
        blacklistExiste.Carro = blacklistAtualizado.Carro;
        blacklistExiste.Posicao = blacklistAtualizado.Posicao;
    }
}
