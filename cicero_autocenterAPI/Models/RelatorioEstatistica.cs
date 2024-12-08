﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cicero_autocenterAPI.Models;

[Table("RelatorioEstatistica")]
public partial class RelatorioEstatistica
{
    [Key]
    [Column("IDRegistro")]
    public int Idregistro { get; set; }

    [Column("IDRelatorio")]
    public int? Idrelatorio { get; set; }

    [Column("IDPagamento")]
    public int? Idpagamento { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string TipoRegistro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? DataRegistro { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Responsavel { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Departamento { get; set; }

    [Unicode(false)]
    public string DadosRegistro { get; set; }

    [Unicode(false)]
    public string ResultadosAnalises { get; set; }

    [Unicode(false)]
    public string Observacoes { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string ArquivoAnexado { get; set; }

    [StringLength(20)]
    [Unicode(false)]
    public string StatusRegistro { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Destinatario { get; set; }

    [ForeignKey("Idpagamento")]
    [InverseProperty("RelatorioEstatisticas")]
    public virtual Pagamento IdpagamentoNavigation { get; set; }
}