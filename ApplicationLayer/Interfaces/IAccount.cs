using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.Interfaces
{
    public interface IAccount
    {
        Task<List<String>> RegisterAsync(RegisterVM model);
        Task<bool> LoginAsync(LoginVM model);
        Task LogOutAsync();
    }
}
