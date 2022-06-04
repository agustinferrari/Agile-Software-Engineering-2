using MinTur.Domain.BusinessEntities;
using System;

namespace MinTur.DataAccessInterface.Repositories
{
    public interface IAuthenticationTokenRepository
    {
        AuthorizationToken GetAuthenticationTokenById(Guid tokenId);
        Guid CreateNewAuthorizationTokenFor(Administrator administrator);
    }
}
