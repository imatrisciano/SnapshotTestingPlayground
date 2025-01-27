using SnapshotTestingPlayground.Models;

namespace SnapshotTestingPlayground.Repositories
{
    public class RegistrazioneEsameRepositoryFinta : IRegistrazioneEsameRepository
    {
        private readonly Corso Corso1 = new Corso("Corso 1", Cfu: 9);
        private readonly Corso Corso2 = new Corso("Corso 2", Cfu: 6);

        public Task<List<RegistrazioneEsame>> GetEsamiStudenteAsync(Studente studente)
        {
            return Task.FromResult(new List<RegistrazioneEsame>()
            {
                new RegistrazioneEsame(studente, Corso1, 30, Lode: true),
                new RegistrazioneEsame(studente, Corso2, 20, Lode: false),
            });
        }
    }
}
