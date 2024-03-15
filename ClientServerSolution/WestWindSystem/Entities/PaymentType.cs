﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WestWindSystem.Entities;

public partial class PaymentType
{
    [Key]
    [Column("PaymentTypeID")]
    public byte PaymentTypeId { get; set; }

    [Required]
    [StringLength(40)]
    [Unicode(false)]
    public string PaymentTypeDescription { get; set; }

    [InverseProperty("PaymentType")]
    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}