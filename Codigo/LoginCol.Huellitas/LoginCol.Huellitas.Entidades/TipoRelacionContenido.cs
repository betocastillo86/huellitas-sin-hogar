﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Entidades
{
    public class TipoRelacionContenido
    {
        public int TipoRelacionContenidoId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public int TipoContenidoId { get; set; }

        /// <summary>
        /// Cantidad maxima de registros posibles en la relacion
        /// </summary>
        public int MaximoRegistros { get; set; }

        public virtual TipoContenido TipoContenido { get; set; }

        public virtual List<ContenidoRelacionado> ContenidosRelacionados { get; set; }
    }
}
