using System;
namespace BookStore.DTO
{
    public record UserResponseDTO(
 string UserId,
 string Username,
 IReadOnlyList<BookDTO> Books
    );
}