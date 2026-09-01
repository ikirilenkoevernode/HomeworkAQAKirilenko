using BookStore.DTO;
using Pets;
using Refit;
using System;
using BookStore.DTO;
namespace BookStore.interfaces
{
    public interface IBookAPI
    {
        [Post ("/Account/v1/User")]
        Task<UserResponseDTO> CreateUserAsync([Body] UserCreateBodyDTO credentials);
        [Post("/Account/v1/GenerateToken")]
        Task<TokenUserResponseDTO> GetUserTokenAsync([Body] UserCreateBodyDTO credentials);
    }
}