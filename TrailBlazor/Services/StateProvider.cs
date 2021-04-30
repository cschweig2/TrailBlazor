using Blazored.LocalStorage;
using TrailBlazor.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

#region Region
namespace TrailBlazor.Services
{
    public class StateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public StateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                if (CurrentUser.IsAuthenticated)
                {
                    var _userId = await _localStorage.GetItemAsync<string>("userId");
                    if (_userId == CurrentUser.Uid)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, CurrentUser.UserName),
                            new Claim(ClaimTypes.Role, CurrentUser.Role)
                        };
                        identity = new ClaimsIdentity(claims, "authentication");
                        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
                    }
                    else
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, CurrentUser.UserName),
                            new Claim(ClaimTypes.Role, "Basic User")
                        };
                        identity = new ClaimsIdentity(claims, "authentication");
                        return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(identity)));
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }
            AuthenticationState authState = new AuthenticationState(new ClaimsPrincipal(identity));
            return authState;
        }

        public void ManageUser()
        { 
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
#endregion