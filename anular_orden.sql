UPDATE Orden SET estado=3 WHERE idOrden=41300;
UPDATE Pago SET estado=3 WHERE idOrden=41300;
UPDATE OrdenLinea SET estado=3  WHERE idOrden=41300;

select * from OrdenLinea where idOrden=41212;
select * from Pago where idOrden=41212;