Use [master]
GO

IF NOT EXISTS (SELECT * FROM sysdatabases WHERE (name = 'test')) 
BEGIN
	PRINT 'LA BASE DE DATOS NO EXISTE...'
	PRINT 'CREANDO OBJETOS DE BASE DE DATOS...'

	--CREAR BASE
	CREATE DATABASE [test]

	--CREAR TABLA MIGRACION
	CREATE TABLE [test].[dbo].[__EFMigrationsHistory](
		[MigrationId] [nvarchar](150) NOT NULL,
		[ProductVersion] [nvarchar](32) NOT NULL,
	 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
	(
		[MigrationId] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	--CREAR TABLA CLIENTES
	CREATE TABLE [test].[dbo].[Clientes](
		[IDCliente] [int] IDENTITY(1,1) NOT NULL,
		[Contrasena] [varchar](50) NOT NULL,
		[Estado] [bit] NOT NULL,
		[Identificacion] [varchar](25) NOT NULL,
		[Nombre] [varchar](100) NOT NULL,
		[Genero] [varchar](1) NOT NULL,
		[Edad] [int] NOT NULL,
		[Direccion] [varchar](200) NOT NULL,
		[Telefono] [varchar](25) NOT NULL,
	 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
	(
		[IDCliente] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	--CREAR TABLA CUENTAS
	CREATE TABLE [test].[dbo].[Cuentas](
		[IDCuenta] [int] IDENTITY(1,1) NOT NULL,
		[NumeroCuenta] [int] NOT NULL,
		[Tipo] [varchar](10) NOT NULL,
		[SaldoInicial] [decimal](18, 2) NOT NULL,
		[Estado] [bit] NOT NULL,
		[IDCliente] [int] NOT NULL,
	 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
	(
		[IDCuenta] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	--CREAR TABLA MOVIMIENTOS
	CREATE TABLE [test].[dbo].[Movimientos](
		[IDMovimiento] [int] IDENTITY(1,1) NOT NULL,
		[NumeroCuenta] [int] NOT NULL,
		[Fecha] DateTime NOT NULL,
		[TipoMovimiento] [varchar](10) NOT NULL,
		[Valor] [decimal](18, 2) NOT NULL,
		[Saldo] [decimal](18, 2) NOT NULL,
	 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
	(
		[IDMovimiento] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	--INSERTS CLIENTES

	INSERT INTO [test].[dbo].[Clientes]([Contrasena]
           ,[Estado]
           ,[Identificacion]
           ,[Nombre]
           ,[Genero]
           ,[Edad]
           ,[Direccion]
           ,[Telefono])
	VALUES ('1234', 1, '0964883245', 'Jose Lema', 'M', 28, 'Otavalo sn y principal', '098254785')

	INSERT INTO [test].[dbo].[Clientes]([Contrasena]
           ,[Estado]
           ,[Identificacion]
           ,[Nombre]
           ,[Genero]
           ,[Edad]
           ,[Direccion]
           ,[Telefono])
	VALUES ('5678', 1, '0985736496', 'Marianela Montalvo', 'M', 28, 'Amazonas y NNUU', '097548965')

	INSERT INTO [test].[dbo].[Clientes]([Contrasena]
           ,[Estado]
           ,[Identificacion]
           ,[Nombre]
           ,[Genero]
           ,[Edad]
           ,[Direccion]
           ,[Telefono])
	VALUES ('1245', 1, '0986733452', 'Juan Osorio', 'M', 28, '13 junio y Equinoccial', '098874587')

	--INSERTS CUENTAS

	INSERT INTO [test].[dbo].[Cuentas]
           ([NumeroCuenta]
           ,[Tipo]
           ,[SaldoInicial]
           ,[Estado]
           ,[IDCliente])
     VALUES (478758,	'Ahorro',	2000,	1,	1)

	 INSERT INTO [test].[dbo].[Cuentas]
           ([NumeroCuenta]
           ,[Tipo]
           ,[SaldoInicial]
           ,[Estado]
           ,[IDCliente])
     VALUES (225487,	'Corriente',	100,	1,	2)

	 INSERT INTO [test].[dbo].[Cuentas]
           ([NumeroCuenta]
           ,[Tipo]
           ,[SaldoInicial]
           ,[Estado]
           ,[IDCliente])
     VALUES (495878,	'Ahorros',	0,	1,	3)

	 INSERT INTO [test].[dbo].[Cuentas]
           ([NumeroCuenta]
           ,[Tipo]
           ,[SaldoInicial]
           ,[Estado]
           ,[IDCliente])
     VALUES (496825,	'Ahorros',	540, 1, 2)

END

