INSERT INTO Productos (ProductID, Descripcion, PrecioVenta, Saldo)
VALUES (1, 'Camara Canon', 3400, 4)-- Puedes agregar más filas según sea necesario

SELECT * FROM Productos
SELECT * FROM Inventario
SELECT * FROM InventarioDetalle

SELECT
    Inv.Folio,
    Inv.Fecha,
	Det.ProductID,
	Det.Cantidad,
    Inv.Total,
    Inv.TipoMovimiento
FROM
    Inventario Inv
JOIN
    InventarioDetalle Det ON Inv.Folio = Det.Folio;

SELECT
	ID.Folio,
    ID.Fecha,
    PD.ProductID,
    PD.Descripcion,
    PD.PrecioVenta,
	IDD.Cantidad,
    ID.Total,
    ID.TipoMovimiento
FROM
    Productos PD
JOIN
    InventarioDetalle IDD ON PD.ProductID = IDD.ProductID
JOIN
    Inventario ID ON IDD.Folio = ID.Folio;



DELETE FROM Inventario;
DELETE FROM InventarioDetalle;

DROP TABLE InventarioDetalle

SELECT COUNT(*) FROM Productos


 
-- Puedes agregar más filas según sea necesario

SELECT * FROM Inventario


INSERT INTO InventarioDetalle (Folio, ProductID, Cantidad)
VALUES (1, 1, 50),
       (1, 2, 30),
       (2, 1, 20);
-- Puedes agregar más filas según sea necesario

EXEC ObtenerDatosInventario

CREATE PROCEDURE ObtenerDatosInventario
AS
BEGIN
    SELECT
        Inv.Folio,
        Inv.Fecha,
        Det.ProductID,
        Det.Cantidad,
        Inv.Total,
        Inv.TipoMovimiento
    FROM
        Inventario Inv
    JOIN
        InventarioDetalle Det ON Inv.Folio = Det.Folio;
END;

	SELECT TOP 1 Estado FROM InventarioDetalle WHERE Folio = 1

SELECT * FROM Productos WHERE ProductID = 1