-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Servidor: localhost:3306
-- Tiempo de generación: 10-03-2017 a las 15:33:42
-- Versión del servidor: 5.6.33
-- Versión de PHP: 5.4.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `cualesmi_lavanderia`
--

DELIMITER $$
--
-- Procedimientos
--
$$

$$

$$

$$

$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Cliente`
--

CREATE TABLE IF NOT EXISTS `Cliente` (
  `idCliente` int(11) NOT NULL AUTO_INCREMENT,
  `nombreCliente` varchar(300) NOT NULL,
  `dniCliente` varchar(8) NOT NULL,
  `correoCliente` varchar(120) NOT NULL,
  `direccionCliente` varchar(150) NOT NULL,
  `telefonoCliente` varchar(20) NOT NULL,
  `fecha_registro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idCliente`),
  UNIQUE KEY `idCliente` (`idCliente`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=20 ;




--
-- Estructura de tabla para la tabla `Color`
--

CREATE TABLE IF NOT EXISTS `Color` (
  `idColor` int(11) NOT NULL AUTO_INCREMENT,
  `nombreColor` varchar(20) NOT NULL,
  `valorColor` varchar(30) NOT NULL,
  `fecha_registro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idColor`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=15 ;

--
-- Volcado de datos para la tabla `Color`
--

INSERT INTO `Color` (`idColor`, `nombreColor`, `valorColor`, `fecha_registro`) VALUES
(1, 'Negro', '#000000', '2017-02-06 11:09:58'),
(2, 'Rojo', 'Red', '2017-02-06 11:48:16'),
(5, 'Azul', 'Blue', '2017-02-09 08:37:22'),
(6, 'Amarillo', 'Yellow', '2017-02-12 23:12:48'),
(7, 'Verde Limon', 'Lime', '2017-02-18 18:55:52'),
(10, 'verde', '#ffff8040', '2017-02-18 19:34:53'),
(14, 'Prueba', 'Teal', '2017-02-19 17:33:58');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Orden`
--

CREATE TABLE IF NOT EXISTS `Orden` (
  `idOrden` int(11) NOT NULL AUTO_INCREMENT,
  `idCliente` int(11) NOT NULL,
  `fechaEntrega` datetime NOT NULL,
  `totalOrden` decimal(10,2) NOT NULL,
  `fechaCreado` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `idUsuario` int(11) NOT NULL,
  `Observacion` text,
  `estado` int(11) NOT NULL,
  `tipoPago` int(11) NOT NULL,
  PRIMARY KEY (`idOrden`),
  UNIQUE KEY `idOrden` (`idOrden`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=70 ;




--
-- Estructura de tabla para la tabla `OrdenLinea`
--

CREATE TABLE IF NOT EXISTS `OrdenLinea` (
  `idOrden` int(11) NOT NULL,
  `item` int(11) NOT NULL,
  `idPrenda` int(11) NOT NULL,
  `Descripcion` varchar(120) NOT NULL,
  `cantidad` int(11) NOT NULL,
  `precio` decimal(10,2) NOT NULL,
  `defecto` varchar(120) DEFAULT NULL,
  `colorPrenda` varchar(200) NOT NULL,
  `total` decimal(10,2) NOT NULL,
  `estado` int(11) DEFAULT NULL,
  UNIQUE KEY `idOrden` (`idOrden`,`item`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--


--
-- Estructura de tabla para la tabla `Pago`
--

CREATE TABLE IF NOT EXISTS `Pago` (
  `idPago` int(11) NOT NULL AUTO_INCREMENT,
  `idOrden` int(11) DEFAULT NULL,
  `pago1` decimal(10,2) DEFAULT NULL,
  `pago2` decimal(10,2) DEFAULT NULL,
  `pagoTotal` decimal(10,2) DEFAULT NULL,
  `tipoPago` int(11) DEFAULT NULL COMMENT '1= total 2=parcial',
  `tipoDocumento` int(11) DEFAULT NULL COMMENT '0= Boleta 1= Factura',
  `igv` decimal(10,2) DEFAULT NULL COMMENT 'igv',
  `Estado` int(11) DEFAULT NULL COMMENT '0=en tienda 1=entregado',
  `fechaPago` datetime DEFAULT NULL,
  `fechaActualizado` datetime DEFAULT NULL,
  `tipo_comprobante` int(11) DEFAULT NULL COMMENT '1=boleta 2=factura',
  PRIMARY KEY (`idPago`),
  KEY `idPago` (`idPago`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=33 ;


-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Prenda`
--

CREATE TABLE IF NOT EXISTS `Prenda` (
  `idPrenda` int(11) NOT NULL AUTO_INCREMENT,
  `nombrePrenda` varchar(100) NOT NULL,
  `descripcionPrenda` varchar(400) NOT NULL,
  `precioServicio` float NOT NULL,
  `FechaCreacion` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idPrenda`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=22 ;



-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Servicio`
--

CREATE TABLE IF NOT EXISTS `Servicio` (
  `idServicio` int(11) NOT NULL AUTO_INCREMENT,
  `nombreServicio` varchar(100) NOT NULL,
  `precioServicio` float NOT NULL,
  `fecha_registro` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`idServicio`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Volcado de datos para la tabla `Servicio`
--



-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE IF NOT EXISTS `usuario` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `apellido` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `sucursal` varchar(60) NOT NULL,
  `password` varchar(30) NOT NULL,
  `tipo` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Volcado de datos para la tabla `usuario`
--


-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `Variable`
--

CREATE TABLE IF NOT EXISTS `Variable` (
  `idVariable` int(11) NOT NULL AUTO_INCREMENT,
  `nombreVariable` varchar(30) DEFAULT NULL COMMENT 'nombre variable',
  `valorVariable` varchar(40) DEFAULT NULL COMMENT 'valor',
  PRIMARY KEY (`idVariable`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=3 ;

--
-- Volcado de datos para la tabla `Variable`
--

INSERT INTO `Variable` (`idVariable`, `nombreVariable`, `valorVariable`) VALUES
(1, 'IGV', '18'),
(2, 'TIPO_CAMBIO', '3.23');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
