﻿using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Web.Models.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoginCol.Huellitas.Web.Models
{
    public class FormularioAdopcionModel  : FormularioAdopcionModelBase
    {

        public FormularioAdopcionModel()
        {
            Contenido = new ContenidoModel();
        }

        public ContenidoListadoModel HogarDePaso { get; set; }

        public ContenidoModel Contenido { get; set; }

        public UsuarioModel Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }

        [Required(ErrorMessage="Los miembros de la familia son obligatorios")]
        [Range(1,10)]
        [Display(Description="Miembros de la familia")]
        public int? MiembrosFamilia { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Description = "Edades de la familia")]
        public string EdadesMiembrosFamilia { get; set; }

        public List<RespuestaAdopcion> Respuestas { get; set; }

        public List<DatoTablaBasica> ListaOcupaciones { get; set; }

        public List<DatoTablaBasica> Preguntas { get; set; }

        public bool OcultarAdvertencia { get; set; }

        public bool FormularioEnviado { get; set; }

        public enum TipoRespuesta
        {
            RadioButton,
            CheckBox,
            CheckConTexto,
            Texto,
            UltimoOtro,
            TextoPorOpcion
        }


    }
}