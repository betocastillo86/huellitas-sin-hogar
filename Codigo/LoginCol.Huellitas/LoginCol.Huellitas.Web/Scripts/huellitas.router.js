﻿var HuellitasRouter = Backbone.Router.extend({
    vistaActual : undefined,

    routes: {
        "": "home",
        "/": "home",
        "sinhogar": "listarHuellitas",
        "sinhogar/": "listarHuellitas",
        "sinhogar/buscar(/t:tipo)(/g:genero)(/c:color)(/ta:tamano)(/e:edad)(/rp:recomendado)(/f:fundacion)(/zh:zona)(/zp:zonaPadre)": "buscarHuellitas",
        "sinhogar/:id/:nombre": "detalleHuellita",
        "sinhogar/:id/:nombre/quiero-adoptar": "adoptarHuellita",
        "fundaciones" : "listarFundaciones",
        "fundaciones/": "listarFundaciones",
        "fundaciones/buscar(/z:zona)": "buscarFundaciones",
        "fundaciones/:id/:nombre": "detalleFundacion",
        "fundaciones/:id/:nombre/ver-todos" : "huellasDeFundacion",
        "home/perdidos": "inicioPerdidos",
        "por-que-adoptar": "porqueAdoptar"
    },

    home : function()
    {
        var vistaHome = new HomeView();
        this.vistaActual = vistaHome;
    },

    listarHuellitas: function ()
    {
        var vistaListarAnimales = new ListarHuellitasView();
        // $("#divMainContentBackbone").html(vistaListarAnimales.$el.html());
        this.vistaActual = vistaListarAnimales;
    },

    buscarHuellitas: function (tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre)
    {
        var vistaListarAnimales = undefined;
        if (this.vistaActual == undefined)
        {
            //inicializa la vista pero pasa parametro para no cargar los contenidos
            vistaListarAnimales = new ListarHuellitasView({ cargar: false, zona : zona, zonaPadre : zonaPadre });
            this.vistaActual = vistaListarAnimales;
        }

        this.vistaActual.filtrarContenidosDesdeUrl(tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre);
    },
    listarFundaciones: function ()
    {
        var vistaListarFundaciones = new ListarFundacionesView();
        this.vistaActual = vistaListarFundaciones;
    },
    buscarFundaciones: function (zona)
    {
        var vistaListarFundaciones = new ListarFundacionesView({ cargar: false });
        this.vistaActual = vistaListarFundaciones;
        vistaListarFundaciones.filtrarContenidosDesdeUrl(zona);
    },
    detalleHuellita: function (id, nombre)
    {   
        var vistaDetalleContenido = new DetalleHuellitaView({ id: id });
        this.vistaActual = vistaDetalleContenido;
    },
    adoptarHuellita : function(id, nombre)
    {
        var vistaAdoptar = new AdoptarView({ id: id });
        this.vistaActual = vistaAdoptar;
    },
    detalleFundacion: function (id, nombre)
    {
        var vistaDetalleFundacion = new DetalleFundacionView({ id: id, nombre : nombre });
        this.vistaActual = vistaDetalleFundacion;
    },
    huellasDeFundacion : function(id)
    {
        var vistaHuellasFundacion = new HuellasFundacionView({ id : id });
        this.vistaActual = vistaHuellasFundacion;
    },
    inicioPerdidos: function ()
    {
        var vistaPerdidos = new PerdidosView();
        this.vistaActual = vistaPerdidos;
    },

    porqueAdoptar : function()
    {
        var vistaAdoptar = new InfoAdoptarView({ el: "#divInfoAdoptar" });
        this.vistaActual = vistaAdoptar;
    },
    navegar: function (url, opt)
    {
        this.navigate(url.replace(/ /g, "-"), opt);
    }
});


var App_Router;

$(document).on("ready", function () {
    App_Router = new HuellitasRouter();
    Backbone.history.start({ pushState: true });
});