UPDATE Orden SET estado=3 WHERE idOrden=41761;
UPDATE Pago SET estado=3 WHERE idOrden=41761;
UPDATE OrdenLinea SET estado=3  WHERE idOrden=41761;

select * from Orden where idOrden in(41888);
select * from Pago where idOrden in(41888);