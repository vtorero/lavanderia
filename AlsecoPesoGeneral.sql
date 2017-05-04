/*PAGO TOTAL EFECTIVO Y VISA EN UNA SOLA CUOTA AL SECO*/
SELECT al.idOrden,UPPER(al.nombreCliente) nombreCliente,al.sucursal,al.fechaCreado,al.nombrePrenda,al.cantidad,IF(al.tipoServicio=1, 'Al seco','Al Agua') tipoServicio,al.total,al.modoPago,al.tipoPago coutas,al.aplicaDscto FROM 
 (SELECT l.tipoServicio,o.idOrden,c.`nombreCliente`,o.fechaCreado,pr.`nombrePrenda`,l.precio,l.cantidad,total,IF(tipoPago1=0,'Efectivo','Tarjeta') modoPago,o.`tipoPago`,o.`aplicaDscto`, u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  Prenda pr ON l.`idPrenda`=pr.`idPrenda`
INNER JOIN `Cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON u.`id`=o.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago=1 AND tipoPago1 IN(0,1)) al WHERE 
al.fechaCreado BETWEEN '2017-05-04 00:00:00' AND '2017-05-04 23:59:59' AND  al.tipoServicio=1 
 UNION ALL
 /*PAGO TOTAL EFECTIVO Y VISA EN UNA SOLA CUOTA AL P*/
 SELECT al.idOrden,UPPER(al.nombreCliente) nombreCliente,al.sucursal,al.fechaCreado,al.nombreServicio nombrePrenda,al.cantidad,IF(al.tipoServicio=1, 'Al seco','Al Agua') tipoServicio,al.total,al.modoPago,al.tipoPago coutas,al.aplicaDscto FROM 
 (SELECT l.tipoServicio,o.idOrden,c.`nombreCliente`,o.fechaCreado,pr.`nombreServicio`,l.precio,l.cantidad,total,IF(tipoPago1=0,'Efectivo','Tarjeta') modoPago,o.`tipoPago`,o.`aplicaDscto`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  Servicio pr ON l.`idPrenda`=pr.`idServicio`
INNER JOIN `Cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON u.`id`=o.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(1) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1)) al WHERE 
al.fechaCreado BETWEEN '2017-05-04 00:00:00' AND '2017-05-04 23:59:59' AND  al.tipoServicio=2 ORDER BY idOrden
 UNION ALL
SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaActualizado fechaCreado,al.nombreServicio nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Peso') tipo,(al.precio*al.cantidad) total,al.modoPago FROM 
 (SELECT l.`item`,l.tipoServicio,o.idOrden,c.`nombreCliente`,p.fechaActualizado,pr.nombreServicio,l.precio,l.cantidad,total,p.pago1,p.pago2,IF(tipoPago1=0,'Efectivo','Tarjeta') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  servicio pr ON l.`idPrenda`=pr.`idServicio`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(2) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1) AND p.`Estado`=1) al WHERE 
al.fechaActualizado BETWEEN '2017-04-28 00:00:00' AND '2017-04-28 23:59:59' AND  al.tipoServicio IN(2)
 UNION ALL
 SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaActualizado fechaCreado,al.nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Peso') tipo,(al.precio*al.cantidad) total,al.modoPago FROM 
 (SELECT l.`item`,l.tipoServicio,o.idOrden,c.`nombreCliente`,p.fechaActualizado,pr.`nombrePrenda`,l.precio,l.cantidad,total,p.pago1,p.pago2,IF(tipoPago1=0,'Efectivo','Visa') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  Prenda pr ON l.`idPrenda`=pr.`idPrenda`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(2) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1) AND p.`Estado`=1) al WHERE 
al.fechaActualizado BETWEEN '2017-04-28 00:00:00' AND '2017-04-28 23:59:59' AND  al.tipoServicio IN(1)
UNION ALL
 SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaActualizado fechaCreado,al.nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Peso') tipo,al.pago1 total,al.modoPago FROM 
 (SELECT l.`item`,l.tipoServicio,o.idOrden,c.`nombreCliente`,p.fechaActualizado,pr.`nombrePrenda`,l.precio,l.cantidad,total,p.pago1,p.pago2,IF(tipoPago1=0,'Efectivo','Visa') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  Prenda pr ON l.`idPrenda`=pr.`idPrenda`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(2) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1) AND p.`Estado`=0) al WHERE 
al.fechaActualizado BETWEEN '2017-04-28 00:00:00' AND '2017-04-28 23:59:59' AND  al.tipoServicio IN(1);


 
 
 DELETE FROM Orden WHERE `fechaCreado` BETWEEN '2017-04-28 00:00:00' AND '2017-04-28 23:59:59';
 SELECT * FROM  pAGO WHERE idOrden=629;
 SELECT * FROM  `Orden` WHERE idOrden=629;
 