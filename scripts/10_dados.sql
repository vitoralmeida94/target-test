USE [TargetInvestimentoDb]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([Id], [NomeCompleto], [DataNascimento], [CPF], [Renda], [PlanoId], [DataCriacao]) VALUES (1, N'Vitor de Almeida', CAST(N'1994-07-04' AS Date), N'14866452757', CAST(6500.00 AS Decimal(8, 2)), 1, CAST(N'2022-04-10' AS Date))
INSERT [dbo].[Cliente] ([Id], [NomeCompleto], [DataNascimento], [CPF], [Renda], [PlanoId], [DataCriacao]) VALUES (2, N'Anna Carolina', CAST(N'2022-04-10' AS Date), N'12345678912', CAST(9000.00 AS Decimal(8, 2)), 1, CAST(N'2022-04-10' AS Date))
INSERT [dbo].[Cliente] ([Id], [NomeCompleto], [DataNascimento], [CPF], [Renda], [PlanoId], [DataCriacao]) VALUES (3, N'Anna Clone', CAST(N'2022-04-10' AS Date), N'12345678912', CAST(1500.00 AS Decimal(8, 2)), NULL, CAST(N'2022-04-10' AS Date))
INSERT [dbo].[Cliente] ([Id], [NomeCompleto], [DataNascimento], [CPF], [Renda], [PlanoId], [DataCriacao]) VALUES (4, N'Teste', CAST(N'2022-04-11' AS Date), N'14866452757', CAST(2300.00 AS Decimal(8, 2)), NULL, CAST(N'2022-04-11' AS Date))
INSERT [dbo].[Cliente] ([Id], [NomeCompleto], [DataNascimento], [CPF], [Renda], [PlanoId], [DataCriacao]) VALUES (5, N'Teste 123', CAST(N'2022-04-11' AS Date), N'14866452757', CAST(2300.00 AS Decimal(8, 2)), NULL, CAST(N'2022-04-11' AS Date))
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[Endereco] ([ClientId], [Logradouro], [Bairro], [CEP], [Cidade], [UF], [Complemento]) VALUES (1, N'RUA TESTE', N'MeierTeste', N'87654321', N'TesteTESTERJ', N'RJ', N'TESTEE')
INSERT [dbo].[Endereco] ([ClientId], [Logradouro], [Bairro], [CEP], [Cidade], [UF], [Complemento]) VALUES (2, N'Rua Joao Brasil', N'Fonseca', N'12345678', N'Niteroi', N'RJ', N'apt 201')
INSERT [dbo].[Endereco] ([ClientId], [Logradouro], [Bairro], [CEP], [Cidade], [UF], [Complemento]) VALUES (3, N'Rua Joao Brasil', N'Fonseca', N'12345678', N'Niteroi', N'RJ', N'apt 201')
INSERT [dbo].[Endereco] ([ClientId], [Logradouro], [Bairro], [CEP], [Cidade], [UF], [Complemento]) VALUES (4, N'Rua Teste', N'Teste', N'89693457', N'RIo de Janeiro', N'RJ', N'')
INSERT [dbo].[Endereco] ([ClientId], [Logradouro], [Bairro], [CEP], [Cidade], [UF], [Complemento]) VALUES (5, N'Rua Teste', N'Teste', N'89693457', N'RIo de Janeiro', N'RJ', N'')
GO
