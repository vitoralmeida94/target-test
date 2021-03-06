
/****** Object:  Table [dbo].[Cliente]    Script Date: 06/04/2022 21:41:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cliente](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NomeCompleto] [varchar](80) NOT NULL,
	[DataNascimento] [date] NOT NULL,
	[CPF] [char](11) NOT NULL,
	[Renda] [decimal](8, 2) NOT NULL,
	[PlanoId] [int] NOT NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Plano] FOREIGN KEY([PlanoId])
REFERENCES [dbo].[Plano] ([Id])
GO

ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Plano]
GO


