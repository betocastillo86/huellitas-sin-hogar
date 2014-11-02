﻿using AutoMapper;
using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace LoginCol.Huellitas.Web.Models.Mapeo
{
    public static class MapeoEntidades
    {
        public static void CrearMapeo()
        {
            AutoMapper.Mapper.CreateMap<TipoContenido, string>().ConvertUsing<TipoContenidoTypeConverter>();

            AutoMapper.Mapper.CreateMap<Contenido, ContenidoModel>()
                .BeforeMap(AntesConvertirContenido)
                .ForMember(o => o.Campos, opt => opt.Ignore());

            AutoMapper.Mapper.CreateMap<Contenido, DetalleHuellitaModel>()
                .BeforeMap(AntesConvertirContenido)
                .ForMember(o => o.Campos, opt => opt.Ignore());
                //OJO:Si se quita revisar el listado de contenidos
                //.ForMember(o => o.Campos, opt => opt.Ignore());


            AutoMapper.Mapper.CreateMap<Contenido, ContenidoBaseModel>();

            AutoMapper.Mapper.CreateMap<Contenido, ContenidoListadoModel>()
                .BeforeMap(ImagenesContenido);

            AutoMapper.Mapper.CreateMap<ContenidoModel, Contenido>()
               // .ForMember(db => db.Campos, model => model.Ignore())
                .ForMember(o => o.ContenidosRelacionados, d => d.Ignore())
                .ForMember(o => o.ContenidosRelacionadosPadre, d => d.Ignore())
                .ForMember(o => o.TipoContenido, d => d.Ignore())
                .ForMember(o => o.Usuario, d => d.Ignore())
                .ForMember(o => o.ZonaGeografica, d => d.Ignore());

            Mapper.CreateMap<ZonaGeografica, ZonaGeograficalModel>();

            Mapper.CreateMap<ValorCampo, ValorCampoModel>()
                .BeforeMap(ValorCampoToValorCampoModel);

            Mapper.CreateMap<ValorCampoModel, ValorCampo>();

            Mapper.CreateMap<TipoContenido, TipoContenidoModel>();
            Mapper.CreateMap<TipoContenido, TipoContenidoBaseModel>();
                //.ForSourceMember( o => o.Contenidos , d => d.Ignore());

            Mapper.CreateMap<CampoTipoContenido, CampoModel>();

            Mapper.CreateMap<OpcionCampo, OpcionCampoModel>();

            Mapper.CreateMap<TipoRelacionContenido, TipoRelacionContenidoModel>();

            Mapper.CreateMap<Campo, CampoModel>()
                .BeforeMap(ConvertCampoToCampoModel);

            Mapper.CreateMap<Comentario, ComentarioModel>();

            AutoMapper.Mapper.CreateMap<ContenidoRelacionado, ContenidoRelacionadoModel>();

            Mapper.CreateMap<ComentarioModel, Comentario>()
                .AfterMap(ComentarioModelToComentario);

        }

        private static void ComentarioModelToComentario(ComentarioModel model, Comentario obj)
        {
            if (obj.Usuario == null)
            {
                obj.Usuario = new Usuario();
            }

            obj.Usuario.Correo = model.CorreoElectronico;
            obj.Usuario.Nombres = model.UsuarioNombres;
        }

        private static void ValorCampoToValorCampoModel(ValorCampo obj, ValorCampoModel model)
        {
            try
            {
                if (obj.Campo != null)
                {
                    switch (obj.Campo.TipoDato)
                    {
                        case TipoDatoCampo.Int:
                        case TipoDatoCampo.Varchar:
                            model.ValorTexto = obj.Valor;
                            break;
                        case TipoDatoCampo.Bit:
                            model.ValorTexto = obj.Valor.ToLower().Equals("true") ? "Si" : "No";
                            break;
                        case TipoDatoCampo.Relacional:
                            if(obj.Campo.Opciones != null)
                                model.ValorTexto = obj.Campo.Opciones
                                    .Where(o => o.OpcionId.Equals(Convert.ToInt32(obj.Valor)))
                                    .FirstOrDefault().Texto;
                            break;
                        case TipoDatoCampo.ConsultaSql:
                            break;
                        case TipoDatoCampo.Multiple:
                            if (obj.Campo.Opciones != null)
                            {
                               model.ValorTexto = obj.Campo.Opciones
                                     .Where(o => o.OpcionId.Equals(Convert.ToInt32(obj.Valor)))
                                     .FirstOrDefault().Texto;
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (ObjectDisposedException){}
           
        }

        private static void ImagenesContenido(Contenido obj, ContenidoListadoModel model)
        {
            model.Imagenes = new List<int>();
            
            try
            {
                if (obj.ContenidosRelacionados != null)
                {
                    //Agrega los contenidos relacionados como imagenes
                    obj.ContenidosRelacionados
                        .Where(r => r.TipoRelacionContenidoId == (int)TipoRelacionEnum.Imagen)
                        .ToList()
                        .ForEach(r => model.Imagenes.Add(r.ContenidoHijoId));
                }
            }
            catch (ObjectDisposedException)
            {
            }
            
        }



        private static void ConvertCampoToCampoModel(Campo obj, CampoModel model)
        {
            model.CampoNombre = obj.Nombre;
            model.CampoOpciones = obj.Opciones.Select(Mapper.Map<OpcionCampo, OpcionCampoModel>).ToList();
            model.CampoTipoDato = obj.TipoDato;
        }


        

        private static void AntesConvertirContenido(Contenido obj, ContenidoModel model)
        {
            try
            {
                if (obj.Campos == null || obj.Campos.Count == 0)
                {
                    model.Campos = new List<ValorCampoModel>();
                }
                else
                {
                    model.Campos = obj.Campos.Select(Mapper.Map<ValorCampo, ValorCampoModel>).ToList();
                }

            }
            catch (ObjectDisposedException)
            {
                model.Campos = new List<ValorCampoModel>();
            }
        }

        public class TipoContenidoTypeConverter : ITypeConverter<TipoContenido, string>
        {
            public string Convert(ResolutionContext context)
            {
                return ((TipoContenido)context.SourceValue).Nombre;
            }
        }
    }
}