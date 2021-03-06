﻿var ImagenModel = Backbone.Model.extend({
    url: "/api/adminimagenes",
    idAttribute: "ContenidoId",
    campoArchivo: undefined,
    intialize : function()
    {
        //this.once("sync", this.creacionOK, this);
    },
    eliminar: function ()
    {
        //Cuando el contenidoId es indefinido es cuando tiene cargado un Modelo de ContenidoRelacionado
        if (this.get("ContenidoId") == undefined)
            this.set("ContenidoId", this.get("ContenidoHijo").ContenidoId);

        this.url = "/api/adminimagenes/" + this.get("ContenidoId");
        this.destroy();
    },
    crear: function (idContenidoPadre, campoArchivo)
    {
        this.url = "/api/adminimagenes/cid-"+idContenidoPadre;
        this.campoArchivo = campoArchivo;
        this.once("sync", this.creacionOK, this);
        this.save();
    },
    creacionOK : function()
    {
        this.guardarEnDisco(this.campoArchivo);

    },
    guardarEnDisco: function (campoArchivo)
    {
        if (campoArchivo == undefined)
            alert("No hay campo archivo");

        var picture = campoArchivo[0].files[0];
        var data = new FormData();
        data.append('file', picture);

        var context = this;

        $.ajax({
            url: "/api/adminimagenes/" + this.get("ContenidoId"),
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            type: 'POST',
            success: function (data) {
                context.trigger("imagen-guardada-ok", context);
            },
            error: function (data) {
                context.trigger("imagen-guardada-error");
            }
        });
    }
});

var ImagenCollection = Backbone.Collection.extend({

    model: ImagenModel,

    url: "/api/adminimagenes",
    
    initialize : function(args){
        if(args.idContenido == undefined)
            alert("Debe cargar un idContenido padre");

        this.url = "/api/adminimagenes/"+args.idContenido;
    },

    eliminar : function(modelo)
    {
        modelo.eliminar();
    },

    obtenerImagenes : function(contenidoId)
    {
        //this.url = "/api/adminimagenes/" + contenidoId;
        this.fetch();
    }
});