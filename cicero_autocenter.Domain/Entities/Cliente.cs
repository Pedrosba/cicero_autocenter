using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cicero_autocenterAPI.Models;

namespace cicero_autocenter.Domain.Entities
{
    public class Cliente
    {
        public int ClienteID { get; private set; }
        public string Nome { get; private set; }
        public string DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public string CPF { get; private set; }
        public string EstadoCivil { get; private set; }
        public string Observacao { get; private set; }

        public Cliente(string nome, string dataNascimento, 
            string genero, string cPF, string estadoCivil, string observacao)
        {
            ValidateDomain()
        }
        {
        
            Nome = nome;
            DataNascimento = dataNascimento;
            Genero = genero;
            CPF = cPF;
            EstadoCivil = estadoCivil;
            Observacao = observacao;
        }

        public void ValidateDomain()
        {

        }
    }
}
