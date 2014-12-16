﻿using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LoginCol.Huellitas.Web.Controllers
{
    
    
    
    public class HomeController : Controller
    {

        
        public ActionResult Index(string queryValues)
        {
            return View(new BaseModel("TituloHome"));
        }


       // [HttpGet]
        
        //public ActionResult Listar()
        //{
        //    return View();
        //}

        //[HttpGet]
        public ActionResult Listar(int? id)
        {
            return View();
        }


        [HttpGet]
        public FileResult Imagen(string nombre, string tamano)
        { 
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return File(Server.MapPath(contenidoNegocio.ObtenerImagenPrincipal(nombre, EnumConverter.ToEnum(tamano))), "gif");
        }

        [HttpGet]
        public FileResult ImagenId(int id, string tamano)
        {
            ContenidoNegocio contenidoNegocio = new ContenidoNegocio();
            return File(Server.MapPath(contenidoNegocio.ObtenerRutaImagenPrincipal(id, EnumConverter.ToEnum(tamano))), "gif");
        }

        #region Perdidos
        public ActionResult Perdidos()
        {
            var modelo = new PerdidosModel();
            return View(modelo);
        }

        [HttpPost]
        public ActionResult Perdidos(PerdidosModel modelo)
        {
            
            return View();
        }
        #endregion
        
        [ChildActionOnly]
        public ActionResult Fundaciones()
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            var modelo = nContenido.ObtenerPorTipoPadre(TipoContenidoEnum.Fundacion)
                .Select(Mapper.Map<Contenido, ContenidoBaseModel>)
                .ToList();
            
            return PartialView(modelo);
        }


        #region Adoptar

        public ActionResult Adoptar()
        {
            var modelo = new BaseModel("TituloPorqueAdoptar");
            return View(modelo);
        }
        #endregion



    }



}
