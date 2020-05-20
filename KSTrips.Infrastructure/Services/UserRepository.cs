﻿using KSTrips.Domain.Entities;
using KSTrips.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSTrips.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private TripContext Context { get; }

        public UserRepository(TripContext context)
        {
            Context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return await Context.Users.ToListAsync();
        }

        public async Task<List<User>> GetUserByAuthZeroId(string authZeroId)
        {
            return await Context.Users.Where(ls => ls.AuthZeroId == authZeroId).ToListAsync();
        }

        public bool SaveUsers(User user)
        {
            try
            {
                Task<List<User>> existUser = Context.Users.Where(ls => ls.Name == user.Name).ToListAsync();

                if (existUser.Result.Count == 0)
                {
                    user.DateCreated = DateTime.Now;
                    user.CreatedBy = "Administrator";
                    Context.Users.Add(user);
                    Context.SaveChanges();
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool UpdateUsers(IEnumerable<User> users)
        {
            try
            {
                foreach (User us in users)
                {
                    //Context.Entry(us).State = EntityState.Modified;
                    us.DateModified = DateTime.Now;

                    Context.Entry(us).Property(p => p.DateModified).IsModified = true;
                    Context.Entry(us).Property(p => p.IsActive).IsModified = true;
                    Context.Entry(us).Property(p => p.NotificationDays).IsModified = true;

                }

                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }

        }

        public bool UpdateSpecificUser(User user)
        {
            try
            {
                
                user.DateModified = DateTime.Now;

               // Context.Attach(user).State = EntityState.Modified;
                Context.Entry(user).Property(p => p.DateModified).IsModified = true;
                Context.Entry(user).Property(p => p.IsActive).IsModified = true;
                Context.Entry(user).Property(p => p.DateInitial).IsModified = true;
                Context.Entry(user).Property(p => p.DateUse).IsModified = true;
                Context.Entry(user).Property(p => p.NotificationDays).IsModified = true;
                Context.Entry(user).Property(p => p.DateInitSubscription).IsModified = true;
                Context.Entry(user).Property(p => p.DateEndSubscription).IsModified = true;



                Context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
