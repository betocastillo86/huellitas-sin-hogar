USE [Huellitas]
GO

delete TipoRelacionContenido
delete campotipocontenido
delete opcioncampo
delete valorcampo
delete contenido
delete zonageografica
delete usuario
delete tipocontenido
delete campo

/****** Object:  Table [dbo].[ZonaGeografica]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[ZonaGeografica] ON
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (1, N'Colombia', NULL, NULL)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (2, N'Bogotá', NULL, 1)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (3, N'Suba', NULL, 2)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (4, N'20 de Julio', NULL, 2)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (5, N'Cali', NULL, 1)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (6, N'Juanchito', NULL, 5)
SET IDENTITY_INSERT [dbo].[ZonaGeografica] OFF
/****** Object:  Table [dbo].[Usuario]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[Usuario] ON
INSERT [dbo].[Usuario] ([UsuarioId], [Correo], [Nombres], [Apellidos], [Clave], [NumeroDocumento], [FechaRegistro], [FechaActualizacion], [Activo]) VALUES (1, N'gabriel.castillo86@hotmail.com', N'Gabriel', N'Castillo', N'123', N'1023865316', CAST(0x0000A39500D792C3 AS DateTime), NULL, 1)
INSERT [dbo].[Usuario] ([UsuarioId], [Correo], [Nombres], [Apellidos], [Clave], [NumeroDocumento], [FechaRegistro], [FechaActualizacion], [Activo]) VALUES (2, N'erica@hotmail.com', N'Erica', N'Prado', N'123', N'1023865315', CAST(0x0000A39500D792C3 AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
/****** Object:  Table [dbo].[TipoContenido]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[TipoContenido] ON
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (1, N'Imagen', NULL)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (2, N'Animal', NULL)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (3, N'Fundacion', NULL)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (4, N'Perro', 2)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (5, N'Gato', 2)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (6, N'Pajaro', 2)
SET IDENTITY_INSERT [dbo].[TipoContenido] OFF
/****** Object:  Table [dbo].[TipoRelacionContenido]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[TipoRelacionContenido] ON
INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion], TipoContenidoId, MaximoRegistros) VALUES (1, N'Imagen', N'Imagenes asociadas al usuario', 1, 0)
INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion], TipoContenidoId, MaximoRegistros) VALUES (2, N'Perros en fundacion', N'Perros en la fundación', 4, 0)
INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion], TipoContenidoId, MaximoRegistros) VALUES (3, N'Staff', N'Staff de la fundación', 4, 0)
INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion], TipoContenidoId, MaximoRegistros) VALUES (4, N'Animales similares', N'Animales similares', 4, 0)
SET IDENTITY_INSERT [dbo].[TipoRelacionContenido] OFF
/****** Object:  Table [dbo].[Campo]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[Campo] ON
INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (1, N'Color', 4, NULL)
INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (3, N'Tamaño', 4, NULL)
INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (4, N'Edad', 1, NULL)
INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (6, N'Alas', 1, NULL)
SET IDENTITY_INSERT [dbo].[Campo] OFF

SET IDENTITY_INSERT [dbo].[Contenido] ON
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (1, N'Skid Antonio 1', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792CF AS DateTime), NULL, NULL, 4, 0, 0, N'1', 3, N'ssss', N'', N'', 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (2, N'Lennon123', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 4, 0, 0, N'2', 3, N'zxxxdx', N'', N'', 1, 1, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (3, N'Perro1', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 4, 0, 0, N'3', 4, N't', N'2', N'1', 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (4, N'perro2', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 3, 0, 0, N'4', 6, NULL, NULL, NULL, 1, 1, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (5, N'perro3', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 3, 0, 0, N'5', 6, NULL, NULL, NULL, 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (6, N'perro4', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 4, 0, 0, N'5', 4, NULL, NULL, NULL, 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (10, N's', N's', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A3A400F61F73 AS DateTime), NULL, NULL, 4, 0, 0, NULL, 3, N's', N'', N'', 1, 0, 1)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (11, N'd', N'd', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A3A400F74672 AS DateTime), NULL, NULL, 4, 0, 0, NULL, 3, N'd', N'', N'', 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (12, N'd', N'd', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A3A400F7BBE1 AS DateTime), NULL, NULL, 4, 0, 0, NULL, 3, N'd', N'', N'', 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (13, N'45fsd', N'fsdfd', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A3A400F84B02 AS DateTime), NULL, NULL, 4, 0, 0, NULL, 3, N'fsd', N'', N'', 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (14, N'Ramón 1', N'Perro cariñoso', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A3A400F97A5F AS DateTime), NULL, NULL, 4, 0, 0, NULL, 3, N'fff', N'', N'', 1, 0, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo], [Eliminado]) VALUES (15, N'Kony', N'Kony', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A3A500966AF4 AS DateTime), NULL, NULL, 4, 0, 0, NULL, 3, N'ga', N'', N'', 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Contenido] OFF
/****** Object:  Table [dbo].[OpcionCampo]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[OpcionCampo] ON
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (1, 1, N'Rojo')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (2, 1, N'Negro')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (3, 1, N'Blanco')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (4, 3, N'Grande')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (5, 3, N'Pequeño')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (6, 3, N'Mediano')
SET IDENTITY_INSERT [dbo].[OpcionCampo] OFF
/****** Object:  Table [dbo].[TipoRelacionTipoContenido]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[TipoRelacionTipoContenido] ON
INSERT [dbo].[TipoRelacionTipoContenido] ([TipoRelacionTipoContenidoId], [TipoContenidoId], [TipoRelacionContenidoId]) VALUES (1, 2, 4)
SET IDENTITY_INSERT [dbo].[TipoRelacionTipoContenido] OFF
/****** Object:  Table [dbo].[CampoTipoContenido]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[CampoTipoContenido] ON
INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (1, 1, 4)
INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (2, 3, 4)
INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (3, 4, 4)
INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (4, 6, 6)
SET IDENTITY_INSERT [dbo].[CampoTipoContenido] OFF
/****** Object:  Table [dbo].[ValorCampo]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[ValorCampo] ON
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (2, 1, 3, N'3')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (3, 3, 3, N'6')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (4, 4, 3, N'3')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (5, 1, 1, N'3')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (6, 3, 1, N'4')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (7, 4, 1, N'4')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (8, 1, 14, N'3')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (9, 3, 14, N'4')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (10, 4, 14, N'1')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (11, 1, 15, N'1')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (12, 3, 15, N'4')
SET IDENTITY_INSERT [dbo].[ValorCampo] OFF
/****** Object:  Table [dbo].[ContenidoRelacionado]    Script Date: 09/23/2014 20:34:22 ******/
SET IDENTITY_INSERT [dbo].[ContenidoRelacionado] ON
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (1, 1, 10, 1, CAST(0x00009E0B00000000 AS DateTime))
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (2, 1, 11, 1, CAST(0x00009E0B00000000 AS DateTime))
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (3, 1, 12, 1, CAST(0x00009E0B00000000 AS DateTime))
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (4, 1, 3, 4, CAST(0x00009E0B00000000 AS DateTime))
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (8, 2, 6, 4, CAST(0x0000A3AE00EC9C07 AS DateTime))
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (9, 2, 1, 4, CAST(0x0000A3AE00ECBD8E AS DateTime))
INSERT [dbo].[ContenidoRelacionado] ([ContenidoRelacionadoId], [ContenidoId], [ContenidoHijoId], [TipoRelacionContenidoId], [FechaCreacion]) VALUES (10, 2, 15, 4, CAST(0x0000A3AE00EECB9C AS DateTime))
SET IDENTITY_INSERT [dbo].[ContenidoRelacionado] OFF
/****** Object:  Table [dbo].[Comentario]    Script Date: 09/23/2014 20:34:22 ******/
