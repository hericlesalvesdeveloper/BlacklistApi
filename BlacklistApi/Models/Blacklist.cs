using System.ComponentModel.DataAnnotations;

namespace BlacklistApi.Models;

public class Blacklist
{
    [Required(ErrorMessage = "O nome não pode ser vazio")]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;
    [Required(ErrorMessage = "Um corredor deve possuir um carro")]
    [MaxLength(100)]
    public string Carro { get; set; } = string.Empty;
    [Required]
    [Range(1, 15, ErrorMessage = "A posição vai de 15 até 1. Verifique e tente novamente")]
    public int Posicao { get; set; }
}
