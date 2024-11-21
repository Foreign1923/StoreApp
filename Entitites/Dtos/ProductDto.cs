using System.ComponentModel.DataAnnotations;


namespace Entitites.Dtos
{
    public record ProductDto
    {

        public int ProductId { get; init; }
        [Required(ErrorMessage = "you must enter a name for product")]
        public string? ProductName { get; init; } = string.Empty;
        [Required(ErrorMessage = " you must enter a price for product")]
        public decimal Price { get; init; }
        public string? Summary { get; init; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int? CategoryId { get; init; } // FK == ForeignKey


    }
}
