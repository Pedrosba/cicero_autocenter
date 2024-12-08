using System;

namespace cicero_autocenterAPI.DTOs
{
    public class AgendamentoDTO
    {
        public int Idagendamento { get; set; }
        public int? VeiculoId { get; set; }
        public DateTime? DataHoraAgendada { get; set; }
        public string Status { get; set; }
    }

    public class AgendamentoDTO_Cadastro
    {
        public int? VeiculoId { get; set; }
        public DateTime? DataHoraAgendada { get; set; }
        public string Status { get; set; }
    }

    public class AgendamentoDTO_Alterar
    {
        public int Idagendamento { get; set; }
        public int? VeiculoId { get; set; }
        public DateTime? DataHoraAgendada { get; set; }
        public string Status { get; set; }
    }
}
