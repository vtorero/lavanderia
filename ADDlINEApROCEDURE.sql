DROP PROCEDURE IF EXISTS addLineaOrden; 
DROP PROCEDURE IF EXISTS ultimoIdOrden; 
DROP PROCEDURE IF EXISTS clientesAll;	
DROP PROCEDURE IF EXISTS buscarOrdenes;	
DELIMITER $$
CREATE PROCEDURE addLineaOrden(
IN PidOrden INT ,
IN PidPrenda INT, 
IN Pitem INT, 
IN Pdescripcion VARCHAR(200),
IN Pcantidad INT,
IN Pprecio DECIMAL,
 IN Pdefecto VARCHAR(200),
 IN Pcolor VARCHAR(200),
 IN Ptotal DECIMAL,
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
CREATE PROCEDURE clientesAll()
BEGIN
SELECT * FROM Cliente ORDER BY idCliente ASC;
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
WHERE (fechaCreado BETWEEN fechaInicio AND fechaFin) AND (c.dniCliente=dniCliente OR c.nombreCliente LIKE nombreCliente);
END $$