BEGIN TRY
    BEGIN TRANSACTION;

    -- Asegúrate de que las variables tengan valores correctos
    DECLARE @folio INT = 123; -- Reemplaza con el valor real
    DECLARE @sumaPrecioVentaTotal DECIMAL(18, 2) = 100.0; -- Reemplaza con el valor real
    DECLARE @nuevoSaldo INT = 50; -- Reemplaza con el valor real
    DECLARE @productoID INT = 1; -- Reemplaza con el valor real
    DECLARE @cantidad INT = 10; -- Reemplaza con el valor real

    -- Inserta en la tabla Inventario
    INSERT INTO Inventario (Folio, Fecha, Total, TipoMovimiento)
    VALUES (@folio, GETDATE(), @sumaPrecioVentaTotal, 'Salida');

    -- Actualiza el saldo del producto
    UPDATE Productos
    SET Saldo = @nuevoSaldo
    WHERE ProductID = @productoID;

    -- Inserta en la tabla InventarioDetalle
    INSERT INTO InventarioDetalle (Folio, ProductID, Cantidad)
    VALUES (@folio, @productoID, @cantidad);

    -- Confirma la transacción
    COMMIT;
END TRY
BEGIN CATCH
    -- En caso de error, deshace la transacción si está activa
    IF @@TRANCOUNT > 0
        ROLLBACK;

    -- Maneja el error según tus necesidades
    PRINT ERROR_MESSAGE();
END CATCH;
