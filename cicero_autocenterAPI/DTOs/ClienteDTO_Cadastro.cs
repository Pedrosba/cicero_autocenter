using cicero_autocenterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cicero_autocenterAPI.DTOs
{
    public class ClienteDTO_Cadastro
    {
        [Key]
        [Column("ClienteID")]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "O Nome deve ter, no máximo, 200 caracteres.")]
        public string Nome { get; set; }


        public DateOnly? DataNascimento { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        public string Genero { get; set; }

        [Required]
        [StringLength(14)]
        [MinLength(14, ErrorMessage = "O CPF deve ter, no mínimo, 14 caracteres.")]
        [Unicode(false)]
        public string Cpf { get; set; }

        [StringLength(20)]
        [Unicode(false)]
        public string EstadoCivil { get; set; }

        [Unicode(false)]
        public string Observacao { get; set; }

    }
}
