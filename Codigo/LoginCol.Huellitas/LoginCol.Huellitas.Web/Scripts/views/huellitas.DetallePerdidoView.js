﻿var DetallePerdidoView = Backbone.View.extend({
	template :  _.template($("#templateDetallePerdido").html()),

	idContenido: 0,

    model : undefined,

	modelContenido: undefined,

	vistaSummary: undefined,

    vistaImagenes : undefined,


	vistaFacebookShare: undefined,

	vistaTwitterShare: undefined,

	bindings: {
	    "#CorreoElectronico": "CorreoElectronico",
	    "#Nombres": "Nombres",
	    "#Telefono": "Telefono",
	    "#Comentario": "Comentario",
	    "click [name='rbTipo']": "cambioTipo",
	},

	events: {
		'click #btnEncontrado': 'encontrado',
		'click #btnConocido': 'conocido',
        'click #btnEnviar' : 'enviarConocido'
	},

	initialize: function (args) {
	    
	    this.modelContenido = new ContenidoModel();
	    this.vistaSummary = new SummaryView();

	    

	    this.modelContenido.on('destroy', this.eliminado, this);
	},

	cargar: function (idContenido)
	{
	    this.idContenido = idContenido;
	    
		this.modelContenido.once('sync', this.mostrarDetalle, this);
		this.modelContenido.obtenerPorId(this.idContenido);
		App_Router.navegar('/perros-gatos-perdidos/' + idContenido, { trigger: false });
	},
	mostrarDetalle: function (model) {
	    
	    this.model = new ContactoModel();
	    
		this.$el.html(this.template(model.toJSON()));
		this.$el.dialog({ modal: true, title: '¿Lo has visto en algún lado?', beforeClose: this.cerrar });
		
		this.vistaFacebookShare = new FacebookShareView({ el: "#divFacebook", url: document.URL });
		this.vistaTwitterShare = new TwitterShareView({ el: "#divTwitter", url: document.URL, texto: 'Esta huellita esta perdida, pueden reportarla si la han visto en @hsinhogar' });

		this.vistaImagenes = new ImagenesContenidoView({ id: this.idContenido, el: "#divImagenesContenido" });

		this.ocultarFormulario();

		this.stickit();
		Backbone.Validation.bind(this);
	},
	eliminado: function (respuesta) {

		//respuesta = respuesta.toJSON();
		//if (respuesta.OperacionExitosa) {
		//	alert('Muchas gracias por reportar esta huellita');
		//}
		//else {
		//	alert(respuesta.MensajeError);
		//}

		alert('Muchas gracias por reportar esta huellita');
		this.cerrar();
	},
	ocultarFormulario : function()
	{
	    this.$("#datosPersona").hide();
	},
	mostrarFormulario: function () {
	    this.$("#datosPersona").show();
	    this.$("#btnConocido").hide();
	    this.$("#btnEncontrado").hide();
	},
	encontrado : function()	{
		if (confirm('Después de registrar como encontrado esta huellita será borrado de nuestra base de datos. ¿Estás seguro que lo encontraste?'))
		{
		    this.modelContenido.eliminar();
		}
	},
	conocido: function(){
	    this.mostrarFormulario();
	},
	enviarConocido: function () {

	    var observaciones = this.model.get('Comentario');
	    if(observaciones && !this.model.validate())
	    {
	        observaciones = 'CONTENIDO ENCONTRADO ' + this.idContenido + ' -> ' + observaciones;
	        this.model.set('Comentario', observaciones);
	    }
	        
	    this.model.guardar({invalid : this.errorComentario, success : this.comentarioGuardado}, this);
	    
	},
	comentarioGuardado : function(model)
	{
	    if (model.toJSON().OperacionExitosa) {
	        this.ocultarFormulario();
	        alert("Muchas gracias por reportar esta huellita, nos contactaremos lo más pronto posible contigo.");
	    }
	    else {
	        alert("No fue posible guardar tu comentario. Si deseas, puedes enviarnos un correo electrónico a redes@huellitas.social");
	    }
	},
    errorComentario: function (errores, ctx) {
        ctx.vistaSummary.mostrar(errores);
    },
	cerrar: function () {
	    if(this.$el)
	        this.$el.dialog('close');
	    App_Router.navegar('/perros-gatos-perdidos' , { trigger: false });
	},
	render: function () {
	    
	}
})