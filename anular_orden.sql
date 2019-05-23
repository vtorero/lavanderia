UPDATE Orden SET estado=3 WHERE idOrden=41300;
UPDATE Pago SET estado=3 WHERE idOrden=41300;
UPDATE OrdenLinea SET estado=3  WHERE idOrden=41300;

select * from Orden where idOrden=41432;
select * from Pago where idOrden=41432;