UPDATE Orden SET estado=3 WHERE idOrden=57887;
UPDATE Pago SET estado=3 WHERE idOrden=57887;
UPDATE OrdenLinea SET estado=3  WHERE idOrden=57887;

select * from Orden where idOrden in(59020,54418);
select * from Pago where idOrden in(59020,54418);