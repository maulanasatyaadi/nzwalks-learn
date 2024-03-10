using Microsoft.AspNetCore.Identity;

namespace NZWalks.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWT(IdentityUser identityUser, List<string> roles);
    }
}
