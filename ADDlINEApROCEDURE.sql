DROP PROCEDURE IF EXISTS addLineaOrden; 
DROP PROCEDURE IF EXISTS addOrden; 
DROP PROCEDURE IF EXISTS ultimoIdOrden; 
DROP PROCEDURE IF EXISTS clientesAll;	
DROP PROCEDURE IF EXISTS buscarOrdenes;	
DROP PROCEDURE IF EXISTS entregaOrden;	
DROP PROCEDURE IF EXISTS coloresAll;
DROP PROCEDURE IF EXISTS serviciosAll;
DROP PROCEDURE IF EXISTS prendasSearch;
DROP PROCEDURE IF EXISTS prendasAll;
DROP PROCEDURE IF EXISTS marcasAll;
DROP PROCEDURE IF EXISTS insertaMarca;
DELIMITER $$
CREATE PROCEDURE addOrden(
IN PidCliente INT,
IN PfechaEntrega VARCHAR(60),
IN PtotalOrden DECIMAL(10,2),
IN PidUsuario INT,
IN Pobservacion VARCHAR(200),
IN Pestado INT,
IN PtipoPago INT,
IN Pdscto INT,
OUT ultimoId INT)
BEGIN
START TRANSACTION;
INSERT INTO Orden (idCliente,fechaEntrega,totalOrden,idUsuario, Observacion, estado, tipoPago,aplicaDscto) VALUES 
(PidCliente,PfechaEntrega,PtotalOrden,PidUsuario,Pobservacion,Pestado,PtipoPago,Pdscto);
SELECT LAST_INSERT_ID() INTO ultimoId;
COMMIT;
END $$
DELIMITER $$
CREATE PROCEDURE addLineaOrden(
IN PidOrden INT ,
IN Pitem INT, 
IN PidPrenda INT, 
IN Pdescripcion VARCHAR(200),
IN Pcantidad INT,
IN Pprecio DECIMAL(10,2),
 IN Pdefecto VARCHAR(200),
 IN Pcolor VARCHAR(200),
IN Pmarca VARCHAR(100),
 IN Ptotal DECIMAL(10,2),
 IN Ptipo INT,
 IN Pestado INT)
BEGIN
START TRANSACTION;
INSERT INTO OrdenLinea(idOrden,item,idPrenda,Descripcion,cantidad,precio,defecto,colorPrenda,marca,total,tipoServicio,estado)
VALUES(PidOrden,Pitem,PidPrenda,Pdescripcion,Pcantidad,Pprecio,Pdefecto,Pcolor,Pmarca,Ptotal,Ptipo,Pestado);
COMMIT;
END $$
DELIMITER $$
CREATE PROCEDURE ultimoIdOrden(IN usuario INT)
BEGIN
SELECT MAX(idOrden) AS ultimoid FROM Orden WHERE idUsuario=usuario;
END $$
DELIMITER $$
CREATE PROCEDURE clientesAll(IN  idUsuario INT)
BEGIN
SELECT * FROM Cliente WHERE usuarioCreador=idUsuario ORDER BY idCliente ASC;
END $$
DELIMITER $$
CREATE PROCEDURE coloresAll()
BEGIN
SELECT * FROM Color ORDER BY nombreColor ASC;
END $$
DELIMITER $$
CREATE PROCEDURE serviciosAll()
BEGIN
SELECT * FROM Servicio ORDER BY nombreServicio ASC;
END $$
DELIMITER $$
CREATE PROCEDURE prendasAll()
BEGIN
SELECT * FROM Prenda ORDER BY nombrePrenda ASC;
END $$

DELIMITER $$
CREATE PROCEDURE marcasAll()
BEGIN
SELECT idMarca,`nombreMarca` FROM Marca ORDER BY nombreMarca ASC;
END $$
DELIMITER $$
CREATE PROCEDURE buscarOrdenes(
IN usuario INT,
IN nombreCliente VARCHAR(200),
IN dniCliente VARCHAR(8),
fechaInicio VARCHAR(20),
fechaFin VARCHAR(20),
IN estado INT
)
BEGIN
SELECT * FROM Orden o INNER JOIN Cliente c ON o.idCliente=c.idCliente INNER JOIN Pago p ON o.idOrden=p.idOrden
WHERE (fechaCreado BETWEEN fechaInicio AND fechaFin AND o.estado=estado AND o.idUsuario=usuario) AND (c.nombreCliente LIKE nombreCliente AND o.idUsuario=usuario);
END $$
DELIMITER $$
CREATE PROCEDURE prendasSearch(
IN criterio VARCHAR(200)
)
BEGIN
SELECT `idPrenda`,`nombrePrenda`,`precioServicio` FROM Prenda WHERE nombrePrenda=criterio;
END $$
DELIMITER $$
CREATE PROCEDURE entregaOrden(
IN id INT,
IN tipopago2 INT,
IN obs VARCHAR(200)
)
BEGIN
START TRANSACTION;
UPDATE Pago SET Estado=1,tipoPago2=tipopago2,Observacion=obs,fechaActualizado=NOW() WHERE idOrden=id;
UPDATE Orden SET estado=1 WHERE idOrden=id;
UPDATE OrdenLinea SET estado=1 WHERE idOrden=id;
COMMIT;
END $$

DELIMITER $$
CREATE PROCEDURE insertaMarca(
IN nombre VARCHAR(100)
)
BEGIN
DECLARE cantidad INT;
SELECT COUNT(*) INTO cantidad FROM Marca WHERE nombreMarca=nombre;
IF (cantidad<1) THEN
INSERT INTO Marca (nombreMarca) VALUES(nombre);
END IF;
END $$


/*---reportes---

SELECT YEAR(o.`fechaCreado`), MONTHNAME(o.`fechaCreado`) ,DAYOFMONTH(o.`fechaCreado`) ,SUM(o.`totalOrden`) FROM Orden o GROUP BY 1,2,3;*/