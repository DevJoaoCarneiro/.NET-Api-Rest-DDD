using Application.Interfaces;
using Application.Request;
using Application.Response;
using Domain.entities;
using Domain.Interfaces;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Application.Service
{
    public class UserService : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityService _securityService;

        public UserService(IUserRepository userRepository, ISecurityService securityService)
        {
            _userRepository = userRepository;
            _securityService = securityService;
        }

        public async Task<UserResponseDTO> createUser(UserRequestDTO userRequestDTO)
        {
            try
            {
                if (userRequestDTO == null)
                {
                    return new UserResponseDTO
                    {
                        message = "Parameters is empty or null",
                        status = "invalid_argument",
                        data = null
                    };
                }

                string passwordHash = _securityService.HashPassword(userRequestDTO.password);

                var newUser = new User
                (
                    userRequestDTO.name,
                    userRequestDTO.email,
                    passwordHash
                );

                await _userRepository.AddAsync(newUser);

                return new UserResponseDTO
                {
                    message = "User created successfully",
                    status = "Success",
                    data = new UserData
                    {
                        name = newUser.name,
                        email = newUser.email
                    }
                };
            }
            catch (Exception ex)
            {

                return new UserResponseDTO
                {
                    message = $"An error occurred: {ex.Message}",
                    status = "error",
                    data = null
                };
            }
            
        }
    }
}
