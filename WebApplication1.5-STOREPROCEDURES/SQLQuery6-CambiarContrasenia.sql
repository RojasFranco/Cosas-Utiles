USE [CursoGyLStoreProcedure]
GO
/****** Object:  StoredProcedure [dbo].[CambiarContrasenia]    Script Date: 23/3/2020 17:28:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER procedure [dbo].[CambiarContrasenia] @usuarioCambiarProcedure nvarchar(10), 
									@contraNuevaProcedure nvarChar(10)
									AS
update Usuarios set PasswordDB = @contraNuevaProcedure
			where UsuarioDB = @usuarioCambiarProcedure