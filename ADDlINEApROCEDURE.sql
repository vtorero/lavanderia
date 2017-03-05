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
SELECT MAX(idOrden) as ultimoid FROM Orden;
END $$
DELIMITER $$
CREATE PROCEDURE clientesAll()
BEGIN
SELECT * FROM Cliente order by idCliente asc;
END $$
DELIMITER $$
CREATE PROCEDURE buscarOrdenes(
IN nombreCliente varchar(200),
in dniCliente varchar(8),
fechaInicio varchar(20),
fechaFin varchar(20)
)
BEGIN
SELECT * FROM Orden o inner join Cliente c on o.idCliente=c.idCliente
WHERE (fechaCreado between fechaInicio and fechaFin) or (c.dniCliente=dniCliente);
END $$