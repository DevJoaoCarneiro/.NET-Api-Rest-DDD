using Application.Request;
using Application.Response;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IUserServices
    {
        Task<UserResponseDTO> createUser(UserRequestDTO user);
    }
}
