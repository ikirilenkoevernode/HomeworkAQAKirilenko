using Refit;
using System;
using Pets;
using TestsPets.DTO;
namespace Pets.interfaces
{
    //[Headers("x-Tenant-ID: 550e8400-e29b-41d4-a716-446655440000")]
    public interface IPetAPI
    {
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsAsync() ;
        [Get("/pets/{id}")]
        Task<Pet> GetPetByIdAsync(string id);
        [Get("/pets")]
        Task<DataOfAllPetsDTO> GetAllPetsFilteredByAgeMinAndLimitedAsync([Query] int ageMin, [Query] int limit);
    }
}