
/****** Object:  Table [dbo].[Endereco]    Script Date: 06/04/2022 21:59:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Endereco](
	[ClientId] [int] NOT NULL,
	[Logradouro] [varchar](100) NOT NULL,
	[Bairro] [varchar](40) NOT NULL,
	[CEP] [char](8) NOT NULL,
	[Cidade] [varchar](50) NOT NULL,
	[UF] [char](2) NOT NULL,
	[Complemento] [varchar](20) NOT NULL,
 CONSTRAINT [PK_Endereco] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Endereco]  WITH CHECK ADD  CONSTRAINT [FK_Endereco_Cliente] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Cliente] ([Id])
GO

ALTER TABLE [dbo].[Endereco] CHECK CONSTRAINT [FK_Endereco_Cliente]
GO


