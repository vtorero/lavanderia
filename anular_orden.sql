UPDATE Orden SET estado=3 WHERE idOrden=43181;
UPDATE Pago SET estado=3 WHERE idOrden=43181;
UPDATE OrdenLinea SET estado=3  WHERE idOrden=43181;

select * from Orden where idOrden in(43175);
select * from Pago where idOrden in(43175);