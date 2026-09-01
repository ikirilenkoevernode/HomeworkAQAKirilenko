using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.DTO
{
    public record TokenUserResponseDTO(
 string Token,
 string Expires,
 string Status,
 string Result
    );

}
