using dotnetnotts.Model;

namespace dotnetnotts.Services
{
    public interface ISpeakerService
    {
        Task<IEnumerable<Speakers>> GetSpeakersAsync();
    }
}
