using cicero_autocenterAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace cicero_autocenterAPI.DTOs
{
    public class ClienteDTO
    {
        [Key]
        public int ClienteId { get; set; }

        [StringLength(100)]
        [Unicode(false)]
        public string Nome { get; set; }

        public DateOnly? DataNascimento { get; set; }

        [StringLength(10)]
        [Unicode(false)]
        public string Genero { get; set; }


        [StringLength(14)]
        [Unicode(false)]

        public string EstadoCivil { get; set; }

    }
}
