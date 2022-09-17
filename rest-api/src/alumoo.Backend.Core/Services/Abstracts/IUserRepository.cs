using alumoo.Backend.Core.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services.Abstracts
{
    public interface IUserRepository
    {
        Task AddImpressionToVolunteer(ImpressionToVolunteerModel impression);
        Task<int> AddUserToVolunteers(UserToVolunteerModel volunteer);
        Task<int> CreateUser(CreateUserModel user);
    }
}
