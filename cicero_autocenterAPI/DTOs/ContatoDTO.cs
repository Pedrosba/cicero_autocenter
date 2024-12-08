using System;

namespace cicero_autocenterAPI.DTOs
{
    public class ContatoDTO
    {
        public int Idcliente { get; set; }
        public int? Idfuncionario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
    }

    public class ContatoDTO_Cadastro
    {
        public int? Idfuncionario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
    }

    public class ContatoDTO_Alterar
    {
        public int Idcliente { get; set; }
        public int? Idfuncionario { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
    }
}
