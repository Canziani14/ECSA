
-- Crear la base de datos ECSA
CREATE DATABASE ECSA;
GO

-- Usar la base de datos ECSA
USE ECSA;
GO

-- Crear la tabla Linea
CREATE TABLE Linea (
    ID_Linea INT PRIMARY KEY IDENTITY(1,1),
    Nombre_Linea VARCHAR(50),
    DVV INT
);
GO

-- Crear la tabla Servicio
CREATE TABLE Servicio (
    ID_Servicio INT PRIMARY KEY IDENTITY(1,1),
    Hora_Cabecera_Principal DATETIME,
    Hora_Cabecera_Retorno VARCHAR(10),
    DVV INT,
    Legajo INT
);
GO

-- Crear la tabla Empleado
CREATE TABLE Empleado (
    Legajo INT PRIMARY KEY,
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    DNI INT,
    Direccion VARCHAR(50),
    Telefono VARCHAR(15),
    FechaIngreso DATE,
    ID_Linea INT,
    ID_Servicio INT,
    DVV INT,
    FOREIGN KEY (ID_Linea) REFERENCES Linea(ID_Linea),
    FOREIGN KEY (ID_Servicio) REFERENCES Servicio(ID_Servicio)
);
GO

-- Crear la tabla Coche
CREATE TABLE Coche (
    ID_Coche INT PRIMARY KEY IDENTITY(1,1),
    Patente VARCHAR(10),
    Interno INT,
    ID_Linea INT,
    ID_Servicio INT,
    DVV INT,
    FOREIGN KEY (ID_Linea) REFERENCES Linea(ID_Linea),
    FOREIGN KEY (ID_Servicio) REFERENCES Servicio(ID_Servicio)
);
GO

-- Crear la tabla Usuario
CREATE TABLE Usuario (
    ID_Usuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    DNI INT,
    Nick VARCHAR(50),
    Contraseña VARCHAR(50),
    Contador_Int_Fallidos INT,
    DVV INT
);
GO

-- Crear la tabla Patente
CREATE TABLE Patente (
    ID_Patente INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(50),
    DVV INT
);
GO

-- Crear la tabla Usuario-Patente
CREATE TABLE Usuario_Patente (
    ID_Usuario INT,
    ID_Patente INT,
    DVV INT,
    PRIMARY KEY (ID_Usuario, ID_Patente),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario),
    FOREIGN KEY (ID_Patente) REFERENCES Patente(ID_Patente)
);
GO

-- Crear la tabla Familia
CREATE TABLE Familia (
    ID_Familia INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(50),
    DVV INT
);
GO

-- Crear la tabla Familia-Patente
CREATE TABLE Familia_Patente (
    ID_Familia INT,
    ID_Patente INT,
    DVV INT,
    PRIMARY KEY (ID_Familia, ID_Patente),
    FOREIGN KEY (ID_Familia) REFERENCES Familia(ID_Familia),
    FOREIGN KEY (ID_Patente) REFERENCES Patente(ID_Patente)
);
GO

-- Crear la tabla Usuario-Familia
CREATE TABLE Usuario_Familia (
    ID_Usuario INT,
    ID_Familia INT,
    DVV INT,
    PRIMARY KEY (ID_Usuario, ID_Familia),
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario),
    FOREIGN KEY (ID_Familia) REFERENCES Familia(ID_Familia)
);
GO

-- Crear la tabla Idioma
CREATE TABLE Idioma (
    ID_Idioma INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(50)
);
GO

-- Crear la tabla Traduccion
CREATE TABLE Traduccion (
    ID_Traduccion INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(50),
    ID_Idioma INT,
    FOREIGN KEY (ID_Idioma) REFERENCES Idioma(ID_Idioma)
);
GO

-- Crear la tabla Bitacora
CREATE TABLE Bitacora (
    ID_Bitacora INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    Descripcion VARCHAR(50),
    ID_Usuario INT,
    FOREIGN KEY (ID_Usuario) REFERENCES Usuario(ID_Usuario)
);
GO

-- Crear la tabla Alerta
CREATE TABLE Alerta (
    ID_Alerta INT PRIMARY KEY IDENTITY(1,1),
    Descripcion VARCHAR(50),
    Nivel_Critico VARCHAR(10)
);
GO

-- Crear la tabla Backup (Usando corchetes para evitar conflicto con palabra reservada)
CREATE TABLE [Backup] (
    ID_Backup INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATE,
    Resultado VARCHAR(50)
);
GO

-- Crear la tabla Digito Verificador Vertical
CREATE TABLE Digito_Verificador_Vertical (
    ID_DigitoVerificadorVertical INT PRIMARY KEY IDENTITY(1,1),
    DVV INT
);
GO

--Linea
INSERT INTO Linea (Nombre_Linea, DVV) VALUES ('Línea A', NULL);
INSERT INTO Linea (Nombre_Linea, DVV) VALUES ('Línea B', NULL);
INSERT INTO Linea (Nombre_Linea, DVV) VALUES ('Línea C', NULL);
INSERT INTO Linea (Nombre_Linea, DVV) VALUES ('Línea D', NULL);
INSERT INTO Linea (Nombre_Linea, DVV) VALUES ('Línea E', NULL);


--servicio
INSERT INTO Servicio (Hora_Cabecera_Principal, Hora_Cabecera_Retorno, DVV, Legajo) VALUES ('2023-06-19 08:00:00', '10:00', NULL, 1);
INSERT INTO Servicio (Hora_Cabecera_Principal, Hora_Cabecera_Retorno, DVV, Legajo) VALUES ('2023-06-19 12:00:00', '14:00', NULL, 2);
INSERT INTO Servicio (Hora_Cabecera_Principal, Hora_Cabecera_Retorno, DVV, Legajo) VALUES ('2023-06-19 16:00:00', '18:00', NULL, 3);
INSERT INTO Servicio (Hora_Cabecera_Principal, Hora_Cabecera_Retorno, DVV, Legajo) VALUES ('2023-06-19 20:00:00', '22:00', NULL, 4);
INSERT INTO Servicio (Hora_Cabecera_Principal, Hora_Cabecera_Retorno, DVV, Legajo) VALUES ('2023-06-19 23:00:00', '01:00', NULL, 5);

--empleado
INSERT INTO Empleado (Legajo, Nombre, Apellido, DNI, Direccion, Telefono, FechaIngreso, ID_Linea, ID_Servicio, DVV) VALUES (1, 'Juan', 'Pérez', 12345678, 'Calle Falsa 123', '555-1234', '2023-01-01', 1, 1, NULL);
INSERT INTO Empleado (Legajo, Nombre, Apellido, DNI, Direccion, Telefono, FechaIngreso, ID_Linea, ID_Servicio, DVV) VALUES (2, 'Ana', 'García', 23456789, 'Calle Verdadera 456', '555-5678', '2023-02-01', 2, 2, NULL);
INSERT INTO Empleado (Legajo, Nombre, Apellido, DNI, Direccion, Telefono, FechaIngreso, ID_Linea, ID_Servicio, DVV) VALUES (3, 'Luis', 'Martínez', 34567890, 'Avenida Siempreviva 789', '555-9012', '2023-03-01', 3, 3, NULL);
INSERT INTO Empleado (Legajo, Nombre, Apellido, DNI, Direccion, Telefono, FechaIngreso, ID_Linea, ID_Servicio, DVV) VALUES (4, 'María', 'Rodríguez', 45678901, 'Boulevard Central 012', '555-3456', '2023-04-01', 4, 4, NULL);
INSERT INTO Empleado (Legajo, Nombre, Apellido, DNI, Direccion, Telefono, FechaIngreso, ID_Linea, ID_Servicio, DVV) VALUES (5, 'Carlos', 'López', 56789012, 'Pasaje Escondido 345', '555-7890', '2023-05-01', 5, 5, NULL);


--coche
INSERT INTO Coche (Patente, Interno, ID_Linea, ID_Servicio, DVV) VALUES ('AAA123', 1, 1, 1, NULL);
INSERT INTO Coche (Patente, Interno, ID_Linea, ID_Servicio, DVV) VALUES ('BBB234', 2, 2, 2, NULL);
INSERT INTO Coche (Patente, Interno, ID_Linea, ID_Servicio, DVV) VALUES ('CCC345', 3, 3, 3, NULL);
INSERT INTO Coche (Patente, Interno, ID_Linea, ID_Servicio, DVV) VALUES ('DDD456', 4, 4, 4, NULL);
INSERT INTO Coche (Patente, Interno, ID_Linea, ID_Servicio, DVV) VALUES ('EEE567', 5, 5, 5, NULL);


--usuario
INSERT INTO Usuario (Nombre, Apellido, DNI, Nick, Contraseña, Contador_Int_Fallidos, DVV) VALUES ('Juan', 'Pérez', 12345678, 'jperez', 'pass123', 0, NULL);
INSERT INTO Usuario (Nombre, Apellido, DNI, Nick, Contraseña, Contador_Int_Fallidos, DVV) VALUES ('Ana', 'García', 23456789, 'agarcia', 'pass234', 0, NULL);
INSERT INTO Usuario (Nombre, Apellido, DNI, Nick, Contraseña, Contador_Int_Fallidos, DVV) VALUES ('Luis', 'Martínez', 34567890, 'lmartinez', 'pass345', 0, NULL);
INSERT INTO Usuario (Nombre, Apellido, DNI, Nick, Contraseña, Contador_Int_Fallidos, DVV) VALUES ('María', 'Rodríguez', 45678901, 'mrodriguez', 'pass456', 0, NULL);
INSERT INTO Usuario (Nombre, Apellido, DNI, Nick, Contraseña, Contador_Int_Fallidos, DVV) VALUES ('Carlos', 'López', 56789012, 'clopez', 'pass567', 0, NULL);


--patente
INSERT INTO Patente (Descripcion, DVV) VALUES ('Admin', NULL);
INSERT INTO Patente (Descripcion, DVV) VALUES ('User', NULL);
INSERT INTO Patente (Descripcion, DVV) VALUES ('Manager', NULL);
INSERT INTO Patente (Descripcion, DVV) VALUES ('Operator', NULL);
INSERT INTO Patente (Descripcion, DVV) VALUES ('Viewer', NULL);

--usuario-patente
INSERT INTO Usuario_Patente (ID_Usuario, ID_Patente, DVV) VALUES (1, 1, NULL);
INSERT INTO Usuario_Patente (ID_Usuario, ID_Patente, DVV) VALUES (2, 2, NULL);
INSERT INTO Usuario_Patente (ID_Usuario, ID_Patente, DVV) VALUES (3, 3, NULL);
INSERT INTO Usuario_Patente (ID_Usuario, ID_Patente, DVV) VALUES (4, 4, NULL);
INSERT INTO Usuario_Patente (ID_Usuario, ID_Patente, DVV) VALUES (5, 5, NULL);


--familia
INSERT INTO Familia (Descripcion, DVV) VALUES ('Familia A', NULL);
INSERT INTO Familia (Descripcion, DVV) VALUES ('Familia B', NULL);
INSERT INTO Familia (Descripcion, DVV) VALUES ('Familia C', NULL);
INSERT INTO Familia (Descripcion, DVV) VALUES ('Familia D', NULL);
INSERT INTO Familia (Descripcion, DVV) VALUES ('Familia E', NULL);


--familia-patente
INSERT INTO Familia_Patente (ID_Familia, ID_Patente, DVV) VALUES (1, 1, NULL);
INSERT INTO Familia_Patente (ID_Familia, ID_Patente, DVV) VALUES (2, 2, NULL);
INSERT INTO Familia_Patente (ID_Familia, ID_Patente, DVV) VALUES (3, 3, NULL);
INSERT INTO Familia_Patente (ID_Familia, ID_Patente, DVV) VALUES (4, 4, NULL);
INSERT INTO Familia_Patente (ID_Familia, ID_Patente, DVV) VALUES (5, 5, NULL);

--usuario-familia
INSERT INTO Usuario_Familia (ID_Usuario, ID_Familia, DVV) VALUES (1, 1, NULL);
INSERT INTO Usuario_Familia (ID_Usuario, ID_Familia, DVV) VALUES (2, 2, NULL);
INSERT INTO Usuario_Familia (ID_Usuario, ID_Familia, DVV) VALUES (3, 3, NULL);
INSERT INTO Usuario_Familia (ID_Usuario, ID_Familia, DVV) VALUES (4, 4, NULL);
INSERT INTO Usuario_Familia (ID_Usuario, ID_Familia, DVV) VALUES (5, 5, NULL);

--idioma
INSERT INTO Idioma (Descripcion) VALUES ('Español');
INSERT INTO Idioma (Descripcion) VALUES ('Inglés');

--traduccion


