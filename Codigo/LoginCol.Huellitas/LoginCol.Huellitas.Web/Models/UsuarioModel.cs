﻿using LoginCol.Huellitas.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class UsuarioModel : UsuarioBaseModel
    {
        [NullableRequired]
        public int? OcupacionId { get; set; }
        
        public string OcupacionValor { get; set; }

        public int? EstadoCivilId { get; set; }

        public string EstadoCivilValor { get; set; }

        public string NumeroDocumento { get; set; }

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        public string Correo { get; set; }

        [MaxLength(100)]
        [Required]
        public string Direccion { get; set; }
        
        [MaxLength(18)]
        [Required]
        public string Telefono { get; set; }
        
        [MaxLength(18)]
        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }

        [Required]
        public string Clave { get; set; }

        [NullableRequired]
        public DateTime? FechaNacimiento { get; set; }

        public DateTime FechaRegistro { get; set; }
    }
}