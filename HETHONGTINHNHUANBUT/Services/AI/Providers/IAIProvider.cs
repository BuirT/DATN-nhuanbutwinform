using System.Threading.Tasks;

namespace HETHONGTINHNHUANBUT.Services.AI.Providers
{
    public interface IAIProvider
    {
        Task<string> GenerateResponseAsync(string prompt);
        Task<string> ExtractJsonAsync(string prompt);
    }
}
