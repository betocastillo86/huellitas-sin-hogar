﻿

using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using System.Collections.Generic;

using System.Linq;
using AutoMapper;
using LoginCol.Huellitas.Web.Models;
using System.Web.Http;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class AdminAnimalesController : ApiController
    {

        [HttpGet]
        public List<ContenidoModel> Get()
        {
            return new ContenidoNegocio().ObtenerPorTipoPadre(TipoContenidoEnum.Animal).Select(Mapper.Map<Contenido, ContenidoModel>).ToList();
        }

        [HttpGet]
        public ContenidoModel Get(int id)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return Mapper.Map<Contenido, ContenidoModel>(contenidoNegocio.Obtener(id));
        }



    }
}
