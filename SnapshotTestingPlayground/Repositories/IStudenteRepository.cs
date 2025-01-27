using SnapshotTestingPlayground.Models;

namespace SnapshotTestingPlayground.Repositories
{
    public interface IStudenteRepository
    {
        public Task<Studente?> GetStudenteByMatricolaAsync(string matricola);
    }
}
