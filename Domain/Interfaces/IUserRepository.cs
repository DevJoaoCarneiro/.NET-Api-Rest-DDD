using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);

    }
}
