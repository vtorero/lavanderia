UPDATE Orden SET estado=3 WHERE idOrden=48564;
UPDATE Pago SET estado=3 WHERE idOrden=48564;
UPDATE OrdenLinea SET estado=3  WHERE idOrden=48564;

select * from Orden where idOrden in(43175);
select * from Pago where idOrden in(43175);