using Microsoft.AspNetCore.Components;
using ProWebbCore.Shared;
using ProWebbCore.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProWebbCore.UI.Pages
{
    public class ResumeBase : ComponentBase
    {
        [Parameter]
        public string UserId { get; set; }
        public Resume Resume { get; set; } //= new Resume();

        [Inject]
        public IUserDataService UserDataService { get; set; }

        public User User { get; set; } = new User();

        protected override async Task OnInitializedAsync()
        {
            User = await UserDataService.GetUserDetails(int.Parse(UserId));
            // Resume = User.Resumes[0];
        }

    }
}
