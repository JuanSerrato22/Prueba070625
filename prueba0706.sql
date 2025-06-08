-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-06-2025 a las 02:00:33
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `prueba0706`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cursos`
--

CREATE TABLE `cursos` (
  `Id` int(11) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `DeleteAt` datetime(6) DEFAULT NULL,
  `Name` longtext NOT NULL,
  `Description` longtext NOT NULL,
  `Active` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `cursos`
--

INSERT INTO `cursos` (`Id`, `CreatedAt`, `DeleteAt`, `Name`, `Description`, `Active`) VALUES
(1, '0001-01-01 00:00:00.000000', NULL, '10-B', 'string', 1),
(2, '2025-06-07 18:54:29.508710', NULL, 'strissssng', 'string', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `estudiantes`
--

CREATE TABLE `estudiantes` (
  `Id` int(11) NOT NULL,
  `Nombre` longtext NOT NULL,
  `Apellido` longtext NOT NULL,
  `Activo` tinyint(1) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `DeleteAt` datetime(6) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `estudiantes`
--

INSERT INTO `estudiantes` (`Id`, `Nombre`, `Apellido`, `Activo`, `CreatedAt`, `DeleteAt`) VALUES
(1, 'Juan', 'Serrato', 0, '0001-01-01 00:00:00.000000', NULL),
(3, 'a', 'string', 0, '2025-06-07 18:15:03.854096', '2025-06-07 18:15:03.854103'),
(4, 'strssssing', 'string', 0, '2025-06-07 18:54:38.010250', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `matriculas`
--

CREATE TABLE `matriculas` (
  `Id` int(11) NOT NULL,
  `EstudianteId` int(11) NOT NULL,
  `CursoId` int(11) NOT NULL,
  `Fecha` datetime(6) NOT NULL,
  `CreatedAt` datetime(6) NOT NULL,
  `DeleteAt` datetime(6) DEFAULT NULL,
  `Description` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `matriculas`
--

INSERT INTO `matriculas` (`Id`, `EstudianteId`, `CursoId`, `Fecha`, `CreatedAt`, `DeleteAt`, `Description`) VALUES
(1, 1, 1, '2025-06-07 23:03:59.427000', '0001-01-01 00:00:00.000000', NULL, ''),
(5, 4, 2, '2025-06-07 23:54:43.235000', '2025-06-07 18:54:52.410243', NULL, 'asssasasasas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20250607222951_InitialCreate', '9.0.5'),
('20250607235003_AgregarGradoEstudiante', '9.0.5');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cursos`
--
ALTER TABLE `cursos`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `estudiantes`
--
ALTER TABLE `estudiantes`
  ADD PRIMARY KEY (`Id`);

--
-- Indices de la tabla `matriculas`
--
ALTER TABLE `matriculas`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Matriculas_CursoId` (`CursoId`),
  ADD KEY `IX_Matriculas_EstudianteId` (`EstudianteId`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cursos`
--
ALTER TABLE `cursos`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `estudiantes`
--
ALTER TABLE `estudiantes`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `matriculas`
--
ALTER TABLE `matriculas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `matriculas`
--
ALTER TABLE `matriculas`
  ADD CONSTRAINT `FK_Matriculas_Cursos_CursoId` FOREIGN KEY (`CursoId`) REFERENCES `cursos` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Matriculas_Estudiantes_EstudianteId` FOREIGN KEY (`EstudianteId`) REFERENCES `estudiantes` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
