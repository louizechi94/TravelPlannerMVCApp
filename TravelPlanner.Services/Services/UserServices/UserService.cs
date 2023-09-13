using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPlanner.Data.AppContext;
using TravelPlanner.Data.Entities;
using TravelPlanner.Models.ViewModeles.UserModels;

namespace TravelPlanner.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly TravelPlannerDbContext _context;
        private readonly IMapper _mapper;

        public UserService(TravelPlannerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> AddUser(UserCreate user)
        {
            var entity = _mapper.Map<User>(user);
            await _context.Users.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<bool> DeleteUser(int userId)
        {
            var userInDb = await _context.Users.SingleOrDefaultAsync(x => x.Id == userId);
            if (userInDb == null) 
            { return false; }

            _context.Users.Remove(userInDb);
            return await _context.SaveChangesAsync()>0;
        }


        public async Task<UserDetail> GetUser(int userId)
        {
            return _mapper.Map<UserDetail>(await _context.Users.FindAsync(userId));   
        }


        public async Task<IEnumerable<UserListItem>> GetUsers()
        {
            return await _context.Users.Select(u => _mapper.Map<UserListItem>(u)).ToListAsync();
        }


        public async Task<bool> UpdateUser(UserEdit user)
        {
            var userInDb = await _context.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == user.Id);

            if (userInDb == null)
            {
                return false;
            }
                var conversion = _mapper.Map<UserEdit, User>(user);
                _context.Users.Update(conversion);
                return await _context.SaveChangesAsync()>0;

            
        }
    }
}
