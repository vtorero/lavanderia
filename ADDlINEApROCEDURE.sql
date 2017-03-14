DROP PROCEDURE IF EXISTS addLineaOrden; 
DROP PROCEDURE IF EXISTS ultimoIdOrden; 
DROP PROCEDURE IF EXISTS clientesAll;	
DROP PROCEDURE IF EXISTS buscarOrdenes;	
DROP PROCEDURE IF EXISTS entregaOrden;	
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
 IN Ptotal DECIMAL(10,2),
 IN Pestado INT)
BEGIN
INSERT INTO OrdenLinea(idOrden,item,idPrenda,Descripcion,cantidad,precio,defecto,colorPrenda,total,estado)
VALUES(PidOrden,PidPrenda,Pitem,Pdescripcion,Pcantidad,Pprecio,Pdefecto,Pcolor,Ptotal,Pestado);
END $$
DELIMITER $$
CREATE PROCEDURE ultimoIdOrden()
BEGIN
SELECT MAX(idOrden) AS ultimoid FROM Orden;
END $$
DELIMITER $$
CREATE PROCEDURE clientesAll(in  idUsuario int)
BEGIN
SELECT * FROM Cliente where usuarioCreador=idUsuario ORDER BY idCliente ASC;
END $$
DELIMITER $$
CREATE PROCEDURE buscarOrdenes(
IN nombreCliente VARCHAR(200),
IN dniCliente VARCHAR(8),
fechaInicio VARCHAR(20),
fechaFin VARCHAR(20)
)
BEGIN
SELECT * FROM Orden o INNER JOIN Cliente c ON o.idCliente=c.idCliente INNER JOIN Pago p ON o.idOrden=p.idOrden
WHERE (fechaCreado BETWEEN fechaInicio AND fechaFin AND o.Estado=0) AND (c.dniCliente=dniCliente OR c.nombreCliente LIKE nombreCliente);
END $$
DELIMITER $$
CREATE PROCEDURE entregaOrden(
IN id INT
)
BEGIN
UPDATE Pago SET Estado=1,fechaActualizado=NOW() WHERE idOrden=id;
UPDATE Orden SET estado=1 WHERE idOrden=id;
UPDATE OrdenLinea SET estado=1 WHERE idOrden=id;
END $$

---reportes---

SELECT YEAR(o.`fechaCreado`), MONTHNAME(o.`fechaCreado`) ,DAYOFMONTH(o.`fechaCreado`) ,SUM(o.`totalOrden`) FROM Orden o GROUP BY 1,2,3;