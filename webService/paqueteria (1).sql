-- phpMyAdmin SQL Dump
-- version 4.4.14
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 04-08-2017 a las 05:35:10
-- Versión del servidor: 5.6.26
-- Versión de PHP: 5.6.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `paqueteria`
--
CREATE DATABASE IF NOT EXISTS `paqueteria` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `paqueteria`;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `datosdeenvio`
--

CREATE TABLE IF NOT EXISTS `datosdeenvio` (
  `idGuia` int(100) NOT NULL,
  `id.Destinatario` int(100) NOT NULL,
  `Fecha_Salida` varchar(100) NOT NULL,
  `Fecha_Llegada` varchar(100) NOT NULL,
  `id.Paquete` int(100) NOT NULL,
  `id.Usuario` int(100) NOT NULL,
  `Estado` varchar(100) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3245 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `datosdeenvio`
--

INSERT INTO `datosdeenvio` (`idGuia`, `id.Destinatario`, `Fecha_Salida`, `Fecha_Llegada`, `id.Paquete`, `id.Usuario`, `Estado`) VALUES
(3244, 2, '3/08/17', '13/08/17', 1, 1, 'En camino');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `empleado`
--

CREATE TABLE IF NOT EXISTS `empleado` (
  `idEmpleado` int(11) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `Apellidos` varchar(50) NOT NULL,
  `Correo` varchar(50) NOT NULL,
  `Contraseña` varchar(50) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `empleado`
--

INSERT INTO `empleado` (`idEmpleado`, `Nombre`, `Apellidos`, `Correo`, `Contraseña`) VALUES
(1, 'Juan Arturo', 'Camarillo Espinosa', 'arturo@gmail.com', '1234'),
(2, 'Maria de los Angeles', 'Morales Gallardo', 'moga@gmail.com', '2343');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paquete`
--

CREATE TABLE IF NOT EXISTS `paquete` (
  `idPaquete` int(100) NOT NULL,
  `Tipo` varchar(100) NOT NULL,
  `Peso` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `paquete`
--

INSERT INTO `paquete` (`idPaquete`, `Tipo`, `Peso`) VALUES
(1, 'Documentos', 200),
(2, 'Caja', 400);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `rastreo`
--

CREATE TABLE IF NOT EXISTS `rastreo` (
  `idGuia` int(100) NOT NULL,
  `Fecha` varchar(100) NOT NULL,
  `Latitud` varchar(100) NOT NULL,
  `Longitud` varchar(50) NOT NULL,
  `idEmpleado` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `rastreo`
--

INSERT INTO `rastreo` (`idGuia`, `Fecha`, `Latitud`, `Longitud`, `idEmpleado`) VALUES
(3244, '8/3/2017 12:00:00 a. m.', '20.4526655', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.452594', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4526596', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '-101.5323982', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '-101.5323982', 1),
(3244, '8/3/2017 12:00:00 a. m.', '20.4525738', '-101.5323982', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id.Usuario` int(11) NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `ApellidoPaterno` varchar(100) NOT NULL,
  `ApellidoMaterno` varchar(100) NOT NULL,
  `Calle` varchar(100) NOT NULL,
  `Numero` int(100) NOT NULL,
  `Colonia` varchar(100) NOT NULL,
  `Estado` varchar(100) NOT NULL,
  `CodigoPostal` int(100) NOT NULL,
  `Telefono` varchar(100) NOT NULL,
  `Municipio` varchar(100) NOT NULL,
  `EntreCalle1` varchar(100) NOT NULL,
  `EntreCalle2` varchar(100) NOT NULL,
  `Tipo` varchar(100) NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`id.Usuario`, `Nombre`, `ApellidoPaterno`, `ApellidoMaterno`, `Calle`, `Numero`, `Colonia`, `Estado`, `CodigoPostal`, `Telefono`, `Municipio`, `EntreCalle1`, `EntreCalle2`, `Tipo`) VALUES
(1, 'Juan', 'Camarillo', 'Espinosa', 'Lerdo', 404, 'Centro', 'Guanajuato', 36970, '4291096032', 'Abasolo', '', '', '0'),
(2, 'Maria', 'Morales', 'Gallardo', 'Miguel', 44, 'Sausillo', 'Guaanjuato', 36970, '4339939393', 'Abasolo', '', '', '1');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `datosdeenvio`
--
ALTER TABLE `datosdeenvio`
  ADD PRIMARY KEY (`idGuia`);

--
-- Indices de la tabla `empleado`
--
ALTER TABLE `empleado`
  ADD PRIMARY KEY (`idEmpleado`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id.Usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `datosdeenvio`
--
ALTER TABLE `datosdeenvio`
  MODIFY `idGuia` int(100) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3245;
--
-- AUTO_INCREMENT de la tabla `empleado`
--
ALTER TABLE `empleado`
  MODIFY `idEmpleado` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT de la tabla `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id.Usuario` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=3;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
