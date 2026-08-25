using System;
using System.Collections.Generic;
using System.Text;
using Refit;
using TestAQA1;
namespace TestAQA2  
{
    [Headers("x-api-key: free_user_3Hs5R7VxAD3zzrYAcdt3Anqc5bY")]
    public interface IUserApi
    {
        [Get("/users/{id}")]
        Task<UserResponseDTO> GetUserAync(int id);
        [Post("/users")]
        Task<CreateUserRequestDTO> CreateUserAsync([Body] CreateUserRequestDTO request);
        [Delete("/users/{id}")]
        Task<ApiResponse<string>> DeleteUserAsync(int id);
    }
}

