using War.Backend.Application;
using War.Persistence;
using War.Protocol;
using static War.Backend.Application.ApplicationFailureKind;

namespace War.Backend.Features.Accounts;

public sealed class AccountApplicationService
{
    private readonly AccountStore _accounts;

    public AccountApplicationService(AccountStore accounts)
    {
        _accounts = accounts;
    }

    public async Task<ApplicationResult<AccountSession>> RegisterAsync(RegisterRequest request,
        CancellationToken cancellationToken)
    {
        if (!AccountStore.ValidCredentials(request.Username, request.Password) ||
            !AccountStore.ValidLocale(request.Locale))
        {
            return ApplicationResult<AccountSession>.Reject(InvalidRequest, "invalid_registration",
                "Use a lowercase 3-24 character username, 12-128 character password, and valid locale.");
        }

        AccountSession? session = await _accounts.Register(request, cancellationToken);
        return session == null
            ? ApplicationResult<AccountSession>.Reject(Conflict, "account_exists", "Account already exists.")
            : ApplicationResult<AccountSession>.Success(session);
    }

    public async Task<ApplicationResult<AccountSession>> LoginAsync(LoginRequest request,
        CancellationToken cancellationToken)
    {
        AccountSession? session = await _accounts.Login(request, cancellationToken);
        return session == null
            ? ApplicationResult<AccountSession>.Reject(Unauthorized, "invalid_credentials", "Invalid credentials.")
            : ApplicationResult<AccountSession>.Success(session);
    }

    public Task<PlayerProfile?> AuthenticateAsync(string token, CancellationToken cancellationToken)
    {
        return _accounts.Authenticate(token, cancellationToken);
    }
}
