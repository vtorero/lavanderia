DROP PROCEDURE IF EXISTS addLineaOrden; 
DROP PROCEDURE IF EXISTS ultimoIdOrden; 
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

CREATE PROCEDURE ultimoIdOrden()
BEGIN
SELECT MAX(idOrden) FROM Orden;
END;