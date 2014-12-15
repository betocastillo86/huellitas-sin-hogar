﻿//var ListarHuellitasView = Backbone.View.extend({
var ListarHuellitasView = Backbone.View.extend({
    el: "#divListarHuellitas",
    vistaZonas : undefined,

    events : {
        "click #btnBuscar": "filtrarContenidos"
    },
    vistaResultados: undefined,

    initialize: function (args) {
        this.vistaResultados = new ResultadosHuellitasView();

        if (args) {
            if (args.cargar != undefined && args.cargar)
                this.vistaResultados.cargarContenidos(this.obtenerFiltroSeleccionado());
        }
        else {
            //por defecto carga los resultados cuando no viene el parametro
            this.vistaResultados.cargarContenidos(this.obtenerFiltroSeleccionado());
            args = {};
        }

        this.vistaZonas = new ZonasGeograficasView({ el: "#divListarHuellitas", idDepartamento: Huellitas.obtenerValorRutaBackboneInt(args.zonaPadre), idCiudad: Huellitas.obtenerValorRutaBackboneInt(args.zona) });

        this.render();
    },
    render: function () {
        return this;
    },
    obtenerCampo: function(campo)
    {
        switch (campo) {
            case "tipo":
                var tipo = this.$("input[name='rbTipo']:checked").attr("value")
                return { valor : (tipo == undefined ? 0 : parseInt(tipo)), texto : ""};
            case "genero":
                var campo = this.$("#ddlGenero :selected");
                return { valor: parseInt(campo.val()) , texto: campo.text() };
            case "color":
                var campo = this.$("#ddlColor :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "tamano":
                var campo = this.$("#ddlTamano :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "zonaPadre":
                var campo = this.$("#ddlZonaDepartamento :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "zona":
                var campo = this.$("#ddlZonaCiudad :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "edad":
                var campo = this.$("#ddlEdad :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "fundacion":
                var campo = this.$("#ddlFundacion :selected");
                return { valor: parseInt(campo.val()), texto: campo.text() };
            case "recomendadoPara":
                var recomendadoPara = "";
                _.each($("input[name='recomendadoPara']:checked"), function (element) { recomendadoPara += recomendadoPara.length == 0 ? element.value : "," + element.value; });
                return {valor : recomendadoPara, texto : ""};
            default:
                return 0;
        }
    },

    
    obtenerFiltroSeleccionado : function()
    {
        var filtros = {
            tipo: this.obtenerCampo("tipo").valor,
            genero: this.obtenerCampo("genero").valor,
            color: this.obtenerCampo("color").valor,
            tamano: this.obtenerCampo("tamano").valor,
            edad: this.obtenerCampo("edad").valor,
            recomendado: this.obtenerCampo("recomendadoPara").valor,
            fundacion: this.obtenerCampo("fundacion").valor,
            zonaPadre: this.obtenerCampo("zonaPadre").valor,
            zona: this.obtenerCampo("zona").valor,
            paginaActual: -1
        };
        return filtros;
    },
    filtrarContenidos: function ()
    {
        
        var filtros = this.obtenerFiltroSeleccionado();

        var url = "/sinhogar/buscar";
        if (this.obtenerCampo("tipo").valor > 0)
            url += "/t" + this.obtenerCampo("tipo").valor + "_" + this.obtenerCampo("tipo").texto;

        if (this.obtenerCampo("genero").valor > 0)
            url += "/g" + this.obtenerCampo("genero").valor + "_" + this.obtenerCampo("genero").texto;

        if (this.obtenerCampo("color").valor > 0)
            url += "/c" + this.obtenerCampo("color").valor + "_" + this.obtenerCampo("color").texto;

        if (this.obtenerCampo("tamano").valor > 0)
            url += "/ta" + this.obtenerCampo("tamano").valor + "_" + this.obtenerCampo("tamano").texto;

        if (this.obtenerCampo("edad").valor > 0)
            url += "/e" + this.obtenerCampo("edad").valor + "_" + this.obtenerCampo("edad").texto;

        if (this.obtenerCampo("zona").valor > 0)
            url += "/zh" + this.obtenerCampo("zona").valor + "_" + this.obtenerCampo("zona").texto;

        if (this.obtenerCampo("zonaPadre").valor > 0)
            url += "/zp" + this.obtenerCampo("zonaPadre").valor + "_" + this.obtenerCampo("zonaPadre").texto;

        if (this.obtenerCampo("fundacion").valor > 0)
            url += "/f" + this.obtenerCampo("fundacion").valor + "_" + this.obtenerCampo("fundacion").texto;

        if (this.obtenerCampo("recomendadoPara").valor != "")
            url += "/rp" + this.obtenerCampo("recomendadoPara").valor + "_" + this.obtenerCampo("recomendadoPara").texto;
        
        App_Router.navegar(url, { trigger: false });

        this.vistaResultados.limpiarResultados();
        this.vistaResultados.cargarContenidos(filtros);
    },
    
    filtrarContenidosDesdeUrl: function (tipo, genero, color, tamano, edad, recomendado, fundacion, zona, zonaPadre)
    {
        
        var filtros = {
            tipo: Huellitas.obtenerValorRutaBackboneInt(tipo),
            genero: genero == undefined ? 0 : parseInt(genero.split("_")[0]),
            color: color == undefined ? 0 : parseInt(color.split("_")[0]),
            tamano: tamano == undefined ? 0 : parseInt(tamano.split("_")[0]),
            edad: edad == undefined ? 0 : parseInt(edad.split("_")[0]),
            zona: zona == undefined ? 0 : parseInt(zona.split("_")[0]),
            zonaPadre: zonaPadre == undefined ? 0 : parseInt(zonaPadre.split("_")[0]),
            fundacion: fundacion == undefined ? 0 : parseInt(fundacion.split("_")[0]),
            recomendado: recomendado == undefined ? "" : recomendado.split("_")[0],
            paginaActual:-1
        };

        if (filtros.tipo > 0)
            this.$("input[name='rbTipo'][value='" + filtros.tipo + "']").prop("checked", true);
        if (filtros.genero > 0)
            this.$("#ddlGenero").val(filtros.genero);
        if (filtros.color > 0)
            this.$("#ddlColor").val(filtros.color);
        if (filtros.tamano > 0)
            this.$("#ddlTamano").val(filtros.tamano);
        if (filtros.edad > 0)
            this.$("#ddlEdad").val(filtros.edad);
        if (filtros.fundacion > 0)
            this.$("#ddlFundacion").val(filtros.fundacion);

        if (filtros.recomendado != "")
        {
            _.each(filtros.recomendado.split(","), function (element) {
                this.$("input[name='recomendadoPara'][value='" + element + "']").prop("checked", true);
            });
        }

        this.vistaResultados.cargarContenidos(filtros);
    }
    
});