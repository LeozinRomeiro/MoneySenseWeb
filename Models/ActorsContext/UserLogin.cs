using MessagePack;
using Microsoft.AspNetCore.Identity;

namespace MoneySenseWeb.Models.ActorsContext
{
    public class UserLogin : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
    }
}
