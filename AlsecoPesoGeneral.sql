(SELECT pg.idOrden,c.nombreCliente,o.fechaCreado,o.idUsuario, u.sucursal,pg.pago1 AS pago,IF(tipoPago1=0,'Efectivo','Visa') modoPago,IF(o.Estado=0,'Entrega','Recojo') Movimiento, IF(ol.tipoServicio=1,'Al Seco','Al Agua') tipoServicio FROM (SELECT * FROM Pago WHERE fechaPago BETWEEN '2017-04-25 00:00:00' AND '2017-04-25 23:59:59'
          AND pago1>0) pg INNER JOIN Orden o ON o.idOrden=pg.idOrden AND o.tipoPago IN(1) AND o.`estado`=0 INNER JOIN usuario u ON o.idUsuario=u.id 
          INNER JOIN Cliente c ON o.idCliente=c.idCliente AND u.id IN (1,2,3,4) 
INNER JOIN `ordenlinea` ol ON o.idOrden=ol.idOrden         
          ORDER BY modoPago) UNION 
(SELECT pg.idOrden,c.nombreCliente,pg.fechaActualizado AS fechaCreado,o.idUsuario, u.sucursal,pg.pago2 AS pago,IF(pg.tipoPago1=0,'Efectivo','Visa') modoPago,IF(o.Estado=0,'Entrega','Recojo') Movimiento , IF(ol.tipoServicio=1,'Al Seco','Al Agua') tipoServicio FROM (SELECT * FROM Pago WHERE fechaActualizado BETWEEN '2017-04-25 00:00:00' AND '2017-04-25 23:59:59' 
) pg INNER JOIN Orden o ON o.idOrden=pg.idOrden AND o.tipoPago IN(2) AND o.`estado`=0 INNER JOIN usuario u ON o.idUsuario=u.id 
INNER JOIN `ordenlinea` ol ON o.idOrden=ol.idOrden  
 INNER JOIN Cliente c ON o.idCliente=c.idCliente ORDER BY modoPago) ORDER BY modopago,idOrden;
 
 
 
SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaCreado,al.nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Agua') tipoServicio,al.total,al.modoPago FROM 
 (SELECT l.tipoServicio,o.idOrden,c.`nombreCliente`,o.fechaCreado,pr.`nombrePrenda`,l.precio,l.cantidad,total,IF(tipoPago1=0,'Efectivo','Tarjeta') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  prenda pr ON l.`idPrenda`=pr.`idPrenda`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(1) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1)) al WHERE 
al.fechaCreado BETWEEN '2017-04-27 00:00:00' AND '2017-04-27 23:59:59' AND 
 al.tipoServicio IN(1)
 UNION ALL
 SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaCreado,al.nombreServicio nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Agua') tipoServicio,al.total,al.modoPago FROM 
 (SELECT l.tipoServicio,o.idOrden,c.`nombreCliente`,o.fechaCreado,pr.`nombreServicio`,l.precio,l.cantidad,total,IF(tipoPago1=0,'Efectivo','Tarjeta') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  servicio pr ON l.`idPrenda`=pr.`idServicio`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(1) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1)) al WHERE 
al.fechaCreado BETWEEN '2017-04-27 00:00:00' AND '2017-04-27 23:59:59' AND 
 al.tipoServicio IN(2)
 UNION ALL
SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaActualizado fechaCreado,al.nombreServicio nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Peso') tipo,(al.precio*al.cantidad) total,al.modoPago FROM 
 (SELECT l.`item`,l.tipoServicio,o.idOrden,c.`nombreCliente`,p.fechaActualizado,pr.nombreServicio,l.precio,l.cantidad,total,p.pago1,p.pago2,IF(tipoPago1=0,'Efectivo','Visa') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  servicio pr ON l.`idPrenda`=pr.`idServicio`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(2) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1) AND p.`Estado`=1) al WHERE 
al.fechaActualizado BETWEEN '2017-04-27 00:00:00' AND '2017-04-27 23:59:59' AND  al.tipoServicio IN(2)
 UNION ALL
 SELECT al.idOrden,al.nombreCliente,al.sucursal,al.fechaActualizado fechaCreado,al.nombrePrenda,IF(al.tipoServicio=1, 'Al seco','Al Peso') tipo,(al.precio*al.cantidad) total,al.modoPago FROM 
 (SELECT l.`item`,l.tipoServicio,o.idOrden,c.`nombreCliente`,p.fechaActualizado,pr.`nombrePrenda`,l.precio,l.cantidad,total,p.pago1,p.pago2,IF(tipoPago1=0,'Efectivo','Visa') modoPago,o.`tipoPago`,u.`sucursal` FROM Orden o 
 INNER JOIN OrdenLinea l ON o.idOrden=l.idOrden 
INNER JOIN  Prenda pr ON l.`idPrenda`=pr.`idPrenda`
INNER JOIN `cliente` c ON o.`idCliente`=c.`idCliente` 
INNER JOIN `usuario` u ON U.`id`=O.`idUsuario` 
 INNER JOIN Pago p ON o.idOrden=p.idOrden WHERE p.tipoPago IN(2) AND tipoPago1 IN(0,1) AND tipoPago2 IN (0,1) AND p.`Estado`=1) al WHERE 
al.fechaActualizado BETWEEN '2017-04-27 00:00:00' AND '2017-04-27 23:59:59' AND  al.tipoServicio IN(1);
 
 
 
 SELECT * FROM Pago p WHERE p.`fechaActualizado` BETWEEN '2017-04-27 00:00:00' AND '2017-04-27 23:59:59'
 SELECT * FROM  pAGO WHERE idOrden=622;
 SELECT * FROM  OrdenLinea WHERE idOrden=622;
 