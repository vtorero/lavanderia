SELECT o.idOrden,sum(total) FROM Orden o inner join OrdenLinea l on o.idOrden=l.idOrden
inner join Pago p on o.idOrden=p.idOrden where p.tipoPago in(1,2) and tipoPago1=0 and tipoPago2=0 and l.tipoServicio=2;

-- EFECTIVO AL SECO----
SELECT al.tipoServicio,al.idOrden,(al.precio*al.cantidad) total from (SELECT l.tipoServicio,o.idOrden,l.precio,l.cantidad,total FROM Orden o inner join OrdenLinea l on o.idOrden=l.idOrden
inner join Pago p on o.idOrden=p.idOrden where p.tipoPago in(1,2) and tipoPago1=0 and tipoPago2=0 
group by 1) al where al.tipoServicio=2;

-- VISA  AL SECO--
SELECT SUM(al.pago1) from (SELECT o.idOrden,p.pago1,p.pago2,sum(total) FROM Orden o inner join OrdenLinea l on o.idOrden=l.idOrden
inner join Pago p on o.idOrden=p.idOrden where p.tipoPago in(1,2) and tipoPago1=1 and tipoPago2=0
group by 1) al;
