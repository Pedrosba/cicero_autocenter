﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cicero_autocenterAPI.Models;

public partial class Pagamento
{
    [Key]
    [Column("IDPagamento")]
    public int Idpagamento { get; set; }

    [Column("IDVeiculo")]
    public int? Idveiculo { get; set; }

    public DateOnly? DataPagamento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Descricao { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string TipoDePagamento { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Valor { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string MetodoDePagamento { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string NumeroDaFatura { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Fornecedor { get; set; }

    public int? Funcionario { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Despesa { get; set; }

    [Unicode(false)]
    public string Observacoes { get; set; }

    [ForeignKey("Funcionario")]
    [InverseProperty("Pagamentos")]
    public virtual Funcionario FuncionarioNavigation { get; set; }

    [ForeignKey("Idveiculo")]
    [InverseProperty("Pagamentos")]
    public virtual Veiculo IdveiculoNavigation { get; set; }

    [InverseProperty("IdpagamentoNavigation")]
    public virtual ICollection<RelatorioEstatistica> RelatorioEstatisticas { get; set; } = new List<RelatorioEstatistica>();
}