using System;

namespace cicero_autocenterAPI.DTOs
{
    public class CategoriumDTO
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
    }

    public class CategoriumDTO_Cadastro
    {
        public string Nome { get; set; }
    }

    public class CategoriumDTO_Alterar
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
    }
}
