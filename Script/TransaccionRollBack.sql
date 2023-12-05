DECLARE @Folio INT, @sumaPrecioVentaTotal DECIMAL(18, 2), @cantidad INT;

BEGIN TRY
    -- Inicia la transacción
    BEGIN TRANSACTION;

    -- Obtiene el folio y otros datos necesarios
    SELECT @Folio = COALESCE(MAX(Folio), 0) + 1, 
           @sumaPrecioVentaTotal = Total,
           @cantidad = Cantidad
    FROM Inventario;

    -- Inserta en la tabla Inventario
    INSERT INTO Inventario (Folio, Fecha, Total, TipoMovimiento)
    VALUES (@Folio, GETDATE(), @sumaPrecioVentaTotal, 'Entrada');

    -- Actualiza el saldo del producto
    UPDATE Productos
    SET Saldo = Saldo + @cantidad
    WHERE ProductID = DatosVenta[0].ProductID;

    -- Inserta en la tabla InventarioDetalle
    INSERT INTO InventarioDetalle (Folio, ProductID, Cantidad)
    VALUES (@Folio, DatosVenta[0].ProductID, @cantidad);

    -- Confirma la transacción
    COMMIT;
END TRY
BEGIN CATCH
    -- En caso de error, deshace la transacción
    IF @@TRANCOUNT > 0
        ROLLBACK;

    -- Maneja el error según tus necesidades
    THROW;
END CATCH;
