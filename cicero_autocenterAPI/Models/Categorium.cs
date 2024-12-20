﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace cicero_autocenterAPI.Models;

public partial class Categorium
{
    [Key]
    [Column("idCategoria")]
    public int IdCategoria { get; set; }

    [Column("ClienteID")]
    public int? ClienteId { get; set; }

    [Column("FuncionarioID")]
    public int? FuncionarioId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? CustoHora { get; set; }

    [ForeignKey("ClienteId")]
    [InverseProperty("Categoria")]
    public virtual Cliente Cliente { get; set; }

    [ForeignKey("FuncionarioId")]
    [InverseProperty("CategoriaNavigation")]
    public virtual Funcionario Funcionario { get; set; }
    public int CategoriaId { get; internal set; }
}