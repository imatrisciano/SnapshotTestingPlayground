using SnapshotTestingPlayground.Models;

namespace SnapshotTestingPlayground.Repositories
{
    public class StudenteRepositoryFinta : IStudenteRepository
    {
        public Task<Studente?> GetStudenteByMatricolaAsync(string matricola)
        {
            var studente = new Studente(
                Nome: "Mario",
                Cognome: "Rossi",
                Matricola: matricola);

            return Task.FromResult<Studente?>(studente);
        }
    }
}
