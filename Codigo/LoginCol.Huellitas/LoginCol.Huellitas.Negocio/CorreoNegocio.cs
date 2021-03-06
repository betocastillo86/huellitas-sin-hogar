﻿using LoginCol.Huellitas.Entidades;
using LoginCol.Huellitas.Negocio.Directorios;
using LoginCol.Huellitas.Utilidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginCol.Huellitas.Negocio
{
    public class CorreoNegocio : NegocioBase
    {
        private ContenidoNegocio nContenido; 
        public CorreoNegocio()
        {
            this.nContenido = new ContenidoNegocio();
        }

        private static IRutasFisicas CargarRutasFisicas(IRutasFisicas rutaFisica)
        {
            if (rutaFisica == null)
                return new RutaFisicaWeb();

            return rutaFisica;
        }

        /// <summary>
        /// Envia un correo que no requiere de plantilla
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="destinatario"></param>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static bool EnviarCorreo(string asunto, string destinatario, string mensaje, IRutasFisicas rutasFisicas = null)
        {
            string[] parametros = null;
            return EnviarCorreo(asunto, destinatario, PlantillasCorreo.Ninguna, mensaje, null, rutasFisicas, parametros);
        }

        /// <summary>
        /// Envia un correo que requiere de plantilla
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="destinatario"></param>
        /// <param name="plantilla"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, IRutasFisicas rutasFisicas = null, params string[] parametros)
        {
            return EnviarCorreo(asunto, destinatario, plantilla, null, null, rutasFisicas, parametros);
        }


        public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, List<string> adjuntos, IRutasFisicas rutasFisicas = null, params string[] parametros)
        {
            return EnviarCorreo(asunto, destinatario, plantilla, null, adjuntos, rutasFisicas, parametros);
        }

        public static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, List<string> adjuntos, int timeout, IRutasFisicas rutasFisicas = null, params string[] parametros)
        {
            return EnviarCorreo(asunto, destinatario, plantilla, null, adjuntos, timeout, rutasFisicas, parametros);
        }

        /// <summary>
        /// Envia el correo y carga la plantilla si es necesario
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="destinatario"></param>
        /// <param name="plantilla"></param>
        /// <param name="mensaje"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        private static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, string mensaje, List<string> rutasAdjuntos, IRutasFisicas rutasFisicas = null, params string[] parametros)
        {
            return EnviarCorreo(asunto, destinatario, plantilla, mensaje, rutasAdjuntos, 0, rutasFisicas, parametros);
        }

        /// <summary>
        /// Evnia un correo con la ruta de la plantilla
        /// </summary>
        /// <param name="asunto"></param>
        /// <param name="destinatario"></param>
        /// <param name="plantilla"></param>
        /// <param name="rutasAdjuntos"></param>
        /// <param name="timeout"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public static bool EnviarCorreo(string asunto, string destinatario, string plantilla, List<string> rutasAdjuntos, int timeout = 0, IRutasFisicas rutasFisicas = null, params string[] parametros)
        {
            EnvioCorreos objCorreo = new EnvioCorreos();
            objCorreo.Para = destinatario;
            objCorreo.Asunto = asunto;
            objCorreo.TimeOut = timeout;

            rutasFisicas = CargarRutasFisicas(rutasFisicas);

            //if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]) && Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]))
            //{
            //    if (rutasAdjuntos != null)
            //        objCorreo.Adjuntos = rutasAdjuntos.ToArray();
            //}


            objCorreo.ConPlantilla = true;
            objCorreo.EsHtml = true;
            objCorreo.RutaPlantilla = plantilla;
            objCorreo.UrlSitio = ParametrizacionNegocio.UrlSitio;

            objCorreo.ParametrosPlantilla = parametros;

            return objCorreo.Enviar();
        }


        private static bool EnviarCorreo(string asunto, string destinatario, PlantillasCorreo plantilla, string mensaje, List<string> rutasAdjuntos, int timeout, IRutasFisicas rutasFisicas = null, params string[] parametros)
        {
            EnvioCorreos objCorreo = new EnvioCorreos();
            objCorreo.Para = destinatario;
            objCorreo.Asunto = asunto;
            objCorreo.TimeOut = timeout;
            rutasFisicas = CargarRutasFisicas(rutasFisicas);
            //if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]) && Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["habilitarAdjuntos"]))
            //{
            //    if (rutasAdjuntos != null)
            //        objCorreo.Adjuntos = rutasAdjuntos.ToArray();
            //}

            if (plantilla == PlantillasCorreo.Ninguna)
            {
                objCorreo.Mensaje = mensaje;
                objCorreo.ConPlantilla = false;
            }
            else
            {
                objCorreo.ConPlantilla = true;
                objCorreo.EsHtml = true;
                string nombrePlantilla = string.Concat(plantilla.ToString(), ".txt");
                objCorreo.RutaPlantilla = System.IO.Path.Combine(rutasFisicas.ObtenerRutaFisica(), "Content", "PlantillasCorreo", nombrePlantilla);
                objCorreo.UrlSitio = ParametrizacionNegocio.UrlSitio;
            }

            objCorreo.ParametrosPlantilla = parametros;

            return objCorreo.Enviar();
        }

        /// <summary>
        /// Envia los diferentes correos de adopción, desde que se solicita hasta la respuesta por parte nuestra
        /// </summary>
        /// <param name="idFormulario">id del formulario que se desea responder</param>
        /// <param name="plantilla">plantilla que se desea enviar</param>
        /// <param name="informacionAdicional">informacion Adicional de las plantillas</param>
        /// <returns></returns>
        public bool EnviarCorreoAdopcion(int idFormulario, PlantillasCorreo plantilla, string informacionAdicional = null)
        {
            var parametros = new List<string>();

            var nAdopciones = new FormularioAdopcionNegocio();
            var formulario = nAdopciones.Obtener(idFormulario);

            //el primer parametro siempre es el nombre
            parametros.Add(formulario.Contenido.Nombre);
            //el segundo siempre es el nombre de la persona
            parametros.Add(formulario.Usuario.Nombres);


            //Carga los datos de la fundacion de BD
            var fundacion = nContenido.ObtenerFundacion(formulario.Contenido.ContenidoId);

            string nombreFundacion = "Huellitas sin Hogar";

            string nombreResponsable = string.Empty;
            string telefonoResponsable = string.Empty;

            string linkFundacion = string.Empty;
            //Si no tiene fundación la fundación por defecto es huellitas sin hogar
            if (fundacion != null)
            {
                nombreFundacion = fundacion.Nombre;
                linkFundacion = string.Format("fundaciones/{0}/{1}", fundacion.ContenidoId, fundacion.NombreLink);

                var campos = nContenido.ObtenerCampos(fundacion.ContenidoId);

                var campo = campos.FirstOrDefault(c => c.Campo.Nombre.Equals("Encargado"));
                if (campo != null)
                    nombreResponsable = campo.Valor;
                campo = campos.FirstOrDefault(c => c.Campo.Nombre.Equals("Teléfono"));
                if (campo != null)
                    telefonoResponsable = campo.Valor;
            }

            string asunto = string.Empty;

            //Agrega los parametros requeridos para cada correo
            switch (plantilla)
            {
                case PlantillasCorreo.SolicitudAdopcion:
                    asunto = string.Format(ParametrizacionNegocio.AsuntoAdopcion, formulario.Contenido.Nombre);
                    //el tercero siempre es el link
                    parametros.Add(string.Format("{0}/{1}", formulario.Contenido.ContenidoId, formulario.Contenido.NombreLink));
                    break;
                case PlantillasCorreo.AdopcionAprobada:
                    asunto = string.Format(ParametrizacionNegocio.AsuntoAdopcionAceptada, formulario.Contenido.Nombre);
                    parametros.Add(string.Format("{0}/{1}", formulario.Contenido.ContenidoId, formulario.Contenido.NombreLink));
                    parametros.Add(nombreFundacion);
                    parametros.Add(linkFundacion);
                    parametros.Add(formulario.FechaCreacion.ToShortDateString());
                    parametros.Add(informacionAdicional ?? string.Empty);
                    if (fundacion != null)
                    {
                        parametros.Add(string.Format("<b style='color:#EFE124'>Información de contacto:</b> {0} <b style='color:#EFE124'>Teléfono:</b> {1}", nombreResponsable, telefonoResponsable));
                    }
                    else
                    {
                        parametros.Add(string.Empty);
                    }
                    break;
                case PlantillasCorreo.AdopcionRechazada:
                    asunto = ParametrizacionNegocio.AsuntoAdopcionRechazada;
                    parametros.Add(nombreFundacion);
                    parametros.Add(linkFundacion);
                    parametros.Add(informacionAdicional ?? string.Empty);
                    break;
                case PlantillasCorreo.AdopcionPrevia:
                    asunto = ParametrizacionNegocio.AsuntoAdopcionEspera;
                    parametros.Add(nombreFundacion);
                    parametros.Add(linkFundacion);
                    parametros.Add(informacionAdicional ?? string.Empty);
                    break;
                default:
                    break;
            }

            //return EnviarCorreo(asunto, string.Format("{0},{1}", formulario.Usuario.Correo, ParametrizacionNegocio.DestinatarioCorreosContacto), plantilla, parametros: parametros.ToArray());
            return EnviarCorreo(asunto, formulario.Usuario.Correo, plantilla, parametros: parametros.ToArray());
        }


        /// <summary>
        /// Envia correo a la fundación
        /// </summary>
        /// <param name="contenidoId"></param>
        public void EnviarCorreoAutorespuesta(int contenidoId, int formularioId, string token)
        {
            var puedeAutoresponder = Negocios.Contenido.ObtenerCampo<bool>(contenidoId,  ParametrizacionNegocio.CampoAutoRespuestaFormularioId);

            if (puedeAutoresponder)
            {
                var contenido = Negocios.Contenido.Obtener(contenidoId);
                
                
                var correoPara = string.Empty;
                
                var fundacion = Negocios.Contenido.ObtenerFundacion(contenidoId);
                if (fundacion != null)
                {
                    correoPara = fundacion.Email;
                }

                if (string.IsNullOrEmpty(correoPara))
                {
                    var padrino = Negocios.Contenido.ObtenerUsuariosRelacionados(contenidoId, (int)TipoRelacionUsuariosEnum.Padrino).FirstOrDefault();
                    if (padrino != null)
                        correoPara = padrino.Usuario.Correo;
                }

                if (string.IsNullOrEmpty(correoPara))
                {
                    correoPara = contenido.Email;
                }

                if (string.IsNullOrEmpty(correoPara))
                    return;


                var parametros = new List<string>();
                parametros.Add(contenido.Nombre);
                parametros.Add(contenido.ContenidoId.ToString());
                parametros.Add(formularioId.ToString());
                parametros.Add(token);
                var asunto = string.Format(ParametrizacionNegocio.AsuntoAdopcionAutorespuesta, contenido.Nombre);
                
                EnviarCorreo(asunto, correoPara, PlantillasCorreo.CorreoAutoRespuesta , parametros: parametros.ToArray());
            }

        }
    }

    /// <summary>
    /// Posibles plantillas para enviar los correos
    /// </summary>
    public enum PlantillasCorreo
    {
        [Description("No usa plantilla")]
        Ninguna,
        [Description("Respuesta automática por adopción")]
        SolicitudAdopcion,
        [Description("Solicitud de adopción aprobada")]
        AdopcionAprobada,
        [Description("No fue aprobada la solicitud de adopción")]
        AdopcionRechazada,
        [Description("Ya fue adoptado por otra persona")]
        AdopcionPrevia,
        [Description("Se le envia a la fundacion para responder")]
        CorreoAutoRespuesta
    }


}
