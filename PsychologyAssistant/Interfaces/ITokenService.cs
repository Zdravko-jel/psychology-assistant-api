using PsychologyAssistant.Models;

namespace PsychologyAssistant.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
