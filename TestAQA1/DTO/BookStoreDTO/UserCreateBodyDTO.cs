using System;
namespace BookStore.DTO
{
public record UserCreateBodyDTO(
string UserName,
string Password
 );
}