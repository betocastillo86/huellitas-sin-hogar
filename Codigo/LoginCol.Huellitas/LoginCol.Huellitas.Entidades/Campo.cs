﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class Campo
    {
        public int CampoId { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public TipoDatoCampo TipoDato { get; set; }

        public string ConsultaSql { get; set; }

        public virtual List<CampoTipoContenido> TiposContenidos { get; set; }

        public virtual List<OpcionCampo> Opciones { get; set; }

        public virtual List<ValorCampo> Valores { get; set; }
    }

    public enum TipoDatoCampo
    { 
        Int = 1,
        Bit,
        Varchar,
        Relacional,
        ConsultaSql
    }
}
