﻿using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class GeneralesController : Controller
    {
        [HttpGet]
        public JsonResult ZonasGeograficas(int id)
        {
            ZonaGeograficaNegocio zonasNegocio = new ZonaGeograficaNegocio();
            return Json(zonasNegocio.ObtenerZonasGeograficasPorPadre(id).Select(AutoMapper.Mapper.Map<ZonaGeografica, ZonaGeograficalModel>).ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TipoContenido(int id)
        {
            TipoContenidoNegocio tipoNegocio = new TipoContenidoNegocio();
            return Json(AutoMapper.Mapper.Map<TipoContenido, TipoContenidoModel>(tipoNegocio.Obtener(id)), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult TiposContenidos()
        {
            TipoContenidoNegocio tipoNegocio = new TipoContenidoNegocio();
            List<TipoContenidoBaseModel> listado = tipoNegocio.Obtener().Select(AutoMapper.Mapper.Map<TipoContenido, TipoContenidoBaseModel>).ToList();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Retorna el listado de tipos de relacion que se pueden encontrar con un tipo de contenido
        /// </summary>
        /// <param name="id">Id del tipo de Contenido que se desea filtrar</param>
        /// <returns></returns>
        public JsonResult TiposRelacionesPorTipoContenido(int id)
        {
            TipoContenidoNegocio tipoNegocio = new TipoContenidoNegocio();
            List<TipoRelacionContenidoModel> listado = tipoNegocio.ObtenerTiposDeRelacionContenido(id).Select(AutoMapper.Mapper.Map<TipoRelacionContenido, TipoRelacionContenidoModel>).ToList();
            return Json(listado, JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult ConstantesJs()
        {
            StringBuilder js = new StringBuilder();
            js.Append("var Constantes = { ");
            js.AppendFormat("ExtensionesImagenes : {0}", ParametrizacionNegocio.ExtensionesImagenes);
            js.AppendFormat(", TamanoMaximoCargaArchivos : {0}", ParametrizacionNegocio.TamanoMaximoCargaArchivos);
            js.AppendFormat(", TipoContenidoAnimales : {0}", Convert.ToInt32(TipoContenidoEnum.Animal));
            js.AppendFormat(", CampoGeneroId : {0}", ParametrizacionNegocio.CampoGeneroId);
            js.AppendFormat(", CampoColorId : {0}", ParametrizacionNegocio.CampoColorId);
            js.AppendFormat(", CampoTamanoId : {0}", ParametrizacionNegocio.CampoTamanoId);
            js.AppendFormat(", ZonaGeograficaPorDefecto : {0}", ParametrizacionNegocio.ZonaGeograficaPorDefecto);
            js.AppendFormat(", CampoEdadId : {0}", ParametrizacionNegocio.CampoEdadId);
            js.AppendFormat(", TipoContenidoFundaciones : {0}", Convert.ToInt32(TipoRelacionEnum.Fundacion));
            js.AppendFormat(", TipoRelacionAnimalesSimilares : {0}", Convert.ToInt32(TipoRelacionEnum.AnimalesSimilares));
            js.AppendFormat(", TipoRelacionFundacion : {0}", Convert.ToInt32(TipoRelacionEnum.Fundacion));
            js.AppendFormat(", LlaveRouterVerTodos : '{0}'", ParametrizacionNegocio.LlaveRouterVerTodos);
            js.AppendFormat(", TipoAnimalesPerdidos : {0}", Convert.ToInt32(TipoContenidoEnum.AnimalesPerdidos));
            js.AppendFormat(", TipoAnimalesEncontrados : {0}", Convert.ToInt32(TipoContenidoEnum.AnimalesEncontrados));
            js.AppendFormat(", TipoAnimalesPerdidosPadre : {0}", Convert.ToInt32(TipoContenidoEnum.AnimalesPerdidosPadre));
            js.AppendFormat(", RazasPerros : {0}", Convert.ToInt32(TablasBasicasEnum.RazasPerros));
            js.AppendFormat(", RazasGatos : {0}", Convert.ToInt32(TablasBasicasEnum.RazasGatos));
            js.AppendFormat(", TipoPerro : {0}", Convert.ToInt32(TipoContenidoEnum.Perro));
            js.AppendFormat(", CampoRazaId : {0}", ParametrizacionNegocio.CampoRaza);

            
            js.Append(" }");
            return JavaScript(js.ToString());
        }

    }
}
