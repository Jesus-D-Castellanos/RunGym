CREATE DATABASE RunGym

USE RunGym

-- tabla Usuarios --
CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(255) NOT NULL,
    Apellido VARCHAR(255) NOT NULL,
	Contrasena VARCHAR(4) NOT NULL,
    Genero CHAR(1) NOT NULL, -- M or F --
    FechaNacimiento DATE NOT NULL,
    Email VARCHAR(255) NOT NULL UNIQUE,
	TipoUsuario VARCHAR(50),
    Peso DECIMAL(5,2) NOT NULL,
    Altura DECIMAL(4,2) NOT NULL,
    HorasSueno DECIMAL(3,1) NOT NULL,
    ConsumoAgua varchar(100) NOT NULL,
    PesoDeseado DECIMAL(5,2) NOT NULL,
    TipoCuerpo VARCHAR(255),
    CuerpoDeseado VARCHAR(255),
    ResumenBienestar TEXT
);

-- tabla rutinaEjercicios --
CREATE TABLE RutinasEjercicio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    NombreRutina VARCHAR(255) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE NOT NULL,
);

-- tabla metas --
CREATE TABLE Metas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    MetaPrincipal TEXT NOT NULL,
    CuerpoActual TEXT,
    CuerpoDeseado TEXT,
    Ultimavez_CuerpoIdeal DATE,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
    Progreso INT 
);

-- tabla Ejercicios --
CREATE TABLE Ejercicios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdRutina INT NOT NULL,
    Nombre_Ejercicio VARCHAR(255) NOT NULL,
    Descripcion TEXT
);

-- tabla Dieta --
CREATE TABLE Dieta (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdUsuario INT NOT NULL,
    TipoDieta VARCHAR(255) NOT NULL,
    FechaInicio DATE NOT NULL,
    FechaFin DATE,
    CaloriasDiarias INT NOT NULL,
    Micronutrientes TEXT,
    Descripcion TEXT
);

-- tabla Comidas --
CREATE TABLE Comidas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdDieta INT NOT NULL,
    TipoComida VARCHAR(50) NOT NULL,
    HoraComida TIME NOT NULL,
    Descripcion TEXT
);
