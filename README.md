# EvoltisPruebaTecnica_JonathanAybar (Ver como Code)
Prueba Tecnica Evoltis, utilizando ASP.NET Web Forms y .NET Framework para implementar un CRUD (Create, Read, Update, Delete) para gestionar una entidad llamada "Empleado". Cada empleado debe tener los siguientes atributos: ID, Nombre, Apellido, Correo electrónico y Salario.

Se utilizo Sql Server como base de datos.
Para poder hacer funcionar con la db, cambiar el "connectionStrings" del Web.config, que esta bajo el name="EvoltisPruebaTecnicaEntities".

Pero primeramente ejecute el siguiente script en el orden indicado para crear la dB:

1°ro:
-- Verifica si la base de datos ya existe

IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = 'EvoltisPruebaTecnicaTEST')
BEGIN
    -- Si la base de datos no existe, créala
    CREATE DATABASE EvoltisPruebaTecnicaTEST;
END;

++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
2°do:

-- Cambia al contexto de la base de datos recién creada
USE EvoltisPruebaTecnicaTEST;

-- Verifica si la tabla "Empleado" ya existe
IF NOT EXISTS (SELECT * FROM information_schema.tables WHERE table_name = 'Empleado')
BEGIN
    -- Si la tabla no existe, créala
    CREATE TABLE [dbo].[Empleado](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [nombre] [varchar](50) NULL,
        [apellido] [varchar](50) NULL,
        [correoelectronico] [varchar](50) NULL,
        [salario] [decimal](18, 0) NULL,
     CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
    (
        [id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY];
END;

+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

3°ro:

-- Inserta registros en la tabla "Empleado" si no existen
IF NOT EXISTS (SELECT * FROM [dbo].[Empleado] WHERE [nombre] = 'Maria' AND [apellido] = 'Zarate' AND [correoelectronico] = 'mzarate@empresa.com' AND [salario] = 500000)
BEGIN
    INSERT INTO [dbo].[Empleado] ([nombre], [apellido], [correoelectronico], [salario])
    VALUES ('Maria', 'Zarate', 'mzarate@empresa.com', 500000);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[Empleado] WHERE [nombre] = 'Alejandro' AND [apellido] = 'Perez' AND [correoelectronico] = 'aperez@empresa.com' AND [salario] = 550000)
BEGIN
    INSERT INTO [dbo].[Empleado] ([nombre], [apellido], [correoelectronico], [salario])
    VALUES ('Alejandro', 'Perez', 'aperez@empresa.com', 550000);
END;

IF NOT EXISTS (SELECT * FROM [dbo].[Empleado] WHERE [nombre] = 'Mateo' AND [apellido] = 'Gonzales' AND [correoelectronico] = 'mgonzales@empresa.com' AND [salario] = 550000)
BEGIN
    INSERT INTO [dbo].[Empleado] ([nombre], [apellido], [correoelectronico], [salario])
    VALUES ('Mateo', 'Gonzales', 'mgonzales@empresa.com', 550000);
END;
