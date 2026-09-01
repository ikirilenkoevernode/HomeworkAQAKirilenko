using System;
namespace BookStore.DTO
{
  public record BookDTO(
  string Isbn,
  string Title,
  string SubTitle,
  string Author,
  string PublishDate,
  string Publisher,
  int Pages,
  string Description,
  string Website
     );
}