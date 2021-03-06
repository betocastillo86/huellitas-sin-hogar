﻿using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio;
using LoginCol.Huellitas.Web.Infraestructure;
using LoginCol.Huellitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginCol.Huellitas.Web.Controllers
{
    public class FundacionesController : Controller
    {
        //
        // GET: /Fundaciones/

        public ActionResult Index()
        {
            ListarFundacionesModel modelo = new ListarFundacionesModel();
            
            //ZonaGeograficaNegocio nZonas = new ZonaGeograficaNegocio();
            //modelo.ZonasPadre = nZonas.ObtenerZonasGeograficasPorPadre(ParametrizacionNegocio.ZonaGeograficaPorDefecto)
            //    .Select(Mapper.Map<ZonaGeografica, ZonaGeograficalModel>)
            //    .ToList();
            
            return View(modelo);
        }


        [HttpGet]
        [SumarVisita]
        public ActionResult Detalle(int id)
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            DetalleFundacionModel modelo = Mapper.Map<Contenido, DetalleFundacionModel>(nContenido.Obtener(id));

            modelo.CargarTitulo("TituloDetalleFundacion", modelo.Nombre);

            if (modelo == null || !modelo.Activo)
                return RedirectToAction("Index", "Fundaciones");

            modelo.ImagenCompartir = string.Format("/img/{0}/big", modelo.ContenidoId);
            modelo.Id = id;

            return View(modelo);
        }

        [HttpGet]
        public ActionResult ContenidosRelacionados(int id)
        {
            ContenidoNegocio nContenido = new ContenidoNegocio();
            var modelo = Mapper.Map<Contenido, ContenidoBaseModel>(nContenido.Obtener(id));
            modelo.CargarTitulo("TituloHuellitasDeFundacion", modelo.Nombre);
            return View(modelo);
        }

    }
}
