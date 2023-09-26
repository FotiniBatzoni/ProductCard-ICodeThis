using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private ClaimsPrincipal _user = new ClaimsPrincipal();

    public void SetAuthenticationState(ClaimsPrincipal user)
    {
        _user = user;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public void ClearAuthenticationState()
    {
        _user = new ClaimsPrincipal();
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var authState = new AuthenticationState(_user);
        return Task.FromResult(authState);
    }
}
