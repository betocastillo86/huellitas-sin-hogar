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

SET IDENTITY_INSERT [dbo].[Campo] ON 

INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (1, N'Color', 4, NULL)
INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (3, N'Tamaño', 4, NULL)
INSERT [dbo].[Campo] ([CampoId], [Nombre], [TipoDato], [ConsultaSql]) VALUES (4, N'Edad', 1, NULL)
SET IDENTITY_INSERT [dbo].[Campo] OFF
SET IDENTITY_INSERT [dbo].[TipoContenido] ON 

INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (1, N'Imagen', NULL)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (2, N'Animal', NULL)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (3, N'Fundacion', NULL)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (4, N'Perro', 2)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (5, N'Gato', 2)
INSERT [dbo].[TipoContenido] ([TipoContenidoId], [Nombre], [TipoContenidoPadreId]) VALUES (6, N'Pajaro', 2)
SET IDENTITY_INSERT [dbo].[TipoContenido] OFF
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([UsuarioId], [Correo], [Nombres], [Apellidos], [Clave], [NumeroDocumento], [FechaRegistro], [FechaActualizacion], [Activo]) VALUES (1, N'gabriel.castillo86@hotmail.com', N'Gabriel', N'Castillo', N'123', N'1023865316', CAST(0x0000A39500D792C3 AS DateTime), NULL, 1)
INSERT [dbo].[Usuario] ([UsuarioId], [Correo], [Nombres], [Apellidos], [Clave], [NumeroDocumento], [FechaRegistro], [FechaActualizacion], [Activo]) VALUES (2, N'erica@hotmail.com', N'Erica', N'Prado', N'123', N'1023865315', CAST(0x0000A39500D792C3 AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
SET IDENTITY_INSERT [dbo].[ZonaGeografica] ON 

INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (1, N'Colombia', NULL, NULL)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (2, N'Bogotá', NULL, 1)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (3, N'Suba', NULL, 2)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (4, N'20 de Julio', NULL, 2)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (5, N'Cali', NULL, 1)
INSERT [dbo].[ZonaGeografica] ([ZonaGeograficaId], [Nombre], [CodigoExterno], [ZonaGeograficaPadreId]) VALUES (6, N'Juanchito', NULL, 5)
SET IDENTITY_INSERT [dbo].[ZonaGeografica] OFF
SET IDENTITY_INSERT [dbo].[Contenido] ON 


INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo]) VALUES (1, N'Skid', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792CF AS DateTime), NULL, NULL, 4, 0, 0, N'1', 3, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo]) VALUES (2, N'Lennon', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 4, 0, 0, N'2', 3, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo]) VALUES (3, N'Perro1', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 4, 0, 0, N'3', 4, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo]) VALUES (4, N'perro2', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 3, 0, 0, N'4', 6, NULL, NULL, NULL, 1, 1)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo]) VALUES (5, N'perro3', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 3, 0, 0, N'5', 6, NULL, NULL, NULL, 1, 0)
INSERT [dbo].[Contenido] ([ContenidoId], [Nombre], [Descripcion], [Visitas], [Comentarios], [Votos], [PromedioVotos], [FechaCreacion], [FechaActualizacion], [FechaPublicacion], [TipoContenidoId], [MeGusta], [Compartidos], [Imagen], [ZonaGeograficaId], [Email], [Facebook], [Twitter], [UsuarioId], [Activo]) VALUES (6, N'perro4', N'Perrito', 0, 0, 0, CAST(0.00 AS Decimal(18, 2)), CAST(0x0000A39500D792D2 AS DateTime), NULL, NULL, 4, 0, 0, N'5', 4, NULL, NULL, NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[Contenido] OFF
SET IDENTITY_INSERT [dbo].[ValorCampo] ON 


INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (2, 1, 3, N'2')
INSERT [dbo].[ValorCampo] ([ValorCampoId], [CampoId], [ContenidoId], [Valor]) VALUES (3, 3, 3, N'5')
SET IDENTITY_INSERT [dbo].[ValorCampo] OFF
SET IDENTITY_INSERT [dbo].[OpcionCampo] ON 


INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (1, 1, N'Rojo')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (2, 1, N'Negro')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (3, 1, N'Blanco')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (4, 3, N'Grande')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (5, 3, N'Pequeño')
INSERT [dbo].[OpcionCampo] ([OpcionId], [CampoId], [Texto]) VALUES (6, 3, N'Mediano')
SET IDENTITY_INSERT [dbo].[OpcionCampo] OFF
SET IDENTITY_INSERT [dbo].[CampoTipoContenido] ON 


INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (1, 1, 4)
INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (2, 3, 4)
INSERT [dbo].[CampoTipoContenido] ([CampoTipoContenidoId], [CampoId], [TipoContenidoId]) VALUES (3, 4, 4)
SET IDENTITY_INSERT [dbo].[CampoTipoContenido] OFF
SET IDENTITY_INSERT [dbo].[TipoRelacionContenido] ON 


INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion]) VALUES (1, N'Imagen', N'Imagenes asociadas al usuario')
INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion]) VALUES (2, N'Perros en fundacion', N'Perros en la fundación')
INSERT [dbo].[TipoRelacionContenido] ([TipoRelacionContenidoId], [Nombre], [Descripcion]) VALUES (3, N'Staff', N'Staff de la fundación')
SET IDENTITY_INSERT [dbo].[TipoRelacionContenido] OFF
