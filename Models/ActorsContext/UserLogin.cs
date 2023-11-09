using MessagePack;
using Microsoft.AspNetCore.Identity;

namespace MoneySenseWeb.Models.ActorsContext
{
    public class UserLogin : IdentityUserLogin<string>
    {
        public override string UserId { get => base.UserId; set => base.UserId = value; }
    }
}
