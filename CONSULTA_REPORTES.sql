SELECT o.idOrden,sum(total) FROM Orden o inner join OrdenLinea l on o.idOrden=l.idOrden
inner join Pago p on o.idOrden=p.idOrden where p.tipoPago in(1,2) and tipoPago1=0 and tipoPago2=0 and l.tipoServicio=1;

-- EFECTIVO-- 
SELECT al.pago1+al.pago2,pago1 from (SELECT o.idOrden,p.pago1,p.pago2,sum(total) FROM Orden o inner join OrdenLinea l on o.idOrden=l.idOrden
inner join Pago p on o.idOrden=p.idOrden where p.tipoPago in(1,2) and tipoPago1=0 and tipoPago2=0
group by 1) al;

-- VISA --
SELECT SUM(al.pago1) from (SELECT o.idOrden,p.pago1,p.pago2,sum(total) FROM Orden o inner join OrdenLinea l on o.idOrden=l.idOrden
inner join Pago p on o.idOrden=p.idOrden where p.tipoPago in(1,2) and tipoPago1=1 and tipoPago2=0
group by 1) al;
