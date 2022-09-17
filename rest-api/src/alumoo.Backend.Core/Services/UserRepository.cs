using alumoo.Backend.Core.Database;
using alumoo.Backend.Core.Database.Entities;
using alumoo.Backend.Core.Domain.Models.User;
using alumoo.Backend.Core.Services.Abstracts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alumoo.Backend.Core.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;
        private readonly IMapper _mapper;

        public UserRepository(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
        {
            _dbContextFactory = dbContextFactory;
            _mapper = mapper;
        }

        public async Task<int> AddUserToVolunteers(UserToVolunteerModel volunteer)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var user = await context.Users.FindAsync(volunteer.UserId);

                var volunteerEntity = new VolunteerEntity
                {
                    Location = volunteer.Location,
                    User = user
                };

                await context.Volunteers.AddAsync(volunteerEntity);
                await context.SaveChangesAsync();

                return context.Volunteers.FirstOrDefault(v => v.User.UserId == volunteer.UserId).VolunteerId;
            }
        }

        public async Task<int> CreateUser(CreateUserModel user)
        {
            using (var context = await _dbContextFactory.CreateDbContextAsync())
            {
                var userEntity = new UserEntity
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                };

                await context.Users.AddAsync(userEntity);
                await context.SaveChangesAsync();

                return context.Users.FirstOrDefault(u => u.Email == user.Email).UserId;
            }
        }
    }
}
