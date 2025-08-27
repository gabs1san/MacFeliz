using MacFeliz.Models;

namespace MacFeliz.Repositories.Interfaces
{
    public interface ILancheRopository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }
        Lanche GeLancheById(int LancheId);
    }
}
