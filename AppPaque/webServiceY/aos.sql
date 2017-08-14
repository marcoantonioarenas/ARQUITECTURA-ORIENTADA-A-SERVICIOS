-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 02-06-2017 a las 17:16:56
-- Versión del servidor: 10.1.21-MariaDB
-- Versión de PHP: 7.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `aos`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `canciones`
--

CREATE TABLE `canciones` (
  `idCancion` int(11) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `artista` varchar(50) NOT NULL,
  `idGenero` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `canciones`
--

INSERT INTO `canciones` (`idCancion`, `nombre`, `artista`, `idGenero`) VALUES
(1, 'Infinity', 'Tiesto', 1),
(2, 'Du hast', 'Rammstein', 2),
(3, 'Amerika', 'Rammsten', 2),
(4, 'Bad', 'David Guetta', 1),
(5, 'Faded', 'Alan Walker', 1),
(6, 'Odyssey Of The Mind', 'Die Krupps', 2),
(7, 'Paula', 'Zoe', 3),
(8, 'Maldito duende', 'Heores del silencio', 3),
(9, 'Amargo adios', 'Inspector', 4),
(10, 'Frente a frente', 'Bunbury', 3),
(11, 'La dosis perfecta', 'Panteon rococo', 4),
(12, 'Labios rotos', 'Zoe', 3),
(13, 'Luna', 'Zoe', 3),
(14, 'Augen auf', 'Oomph', 2),
(15, 'Labyrinth', 'Oomph', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `generos`
--

CREATE TABLE `generos` (
  `idGenero` int(11) NOT NULL,
  `genero` varchar(50) NOT NULL,
  `referencias` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `generos`
--

INSERT INTO `generos` (`idGenero`, `genero`, `referencias`) VALUES
(1, 'Electronica', 'Avici , Tiesto , Dimitri Vegas etc...'),
(2, 'Neue Deutsche Härte', 'Rammstein , Oomph , Smokahontas etc...'),
(3, 'Rock en español', 'Zoe, Heroes del silencio, el tri etc...'),
(4, 'Ska', 'Panteon rococo, La gusana ciega, Inspector etc..');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
