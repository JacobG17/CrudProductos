CREATE PROCEDURE GuardarDatosVenta
    @Folio INT,
    @sumaPrecioVentaTotal DECIMAL(18, 2),
    @nuevoSaldo INT,
    @productoID INT,
    @cantidad INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- Inserta en la tabla Inventario
        INSERT INTO Inventario (Folio, Fecha, Total, TipoMovimiento)
        VALUES (@Folio, GETDATE(), @sumaPrecioVentaTotal, 'Salida');

        -- Actualiza el saldo del producto
        UPDATE Productos
        SET Saldo = @nuevoSaldo
        WHERE ProductID = @productoID;

        -- Inserta en la tabla InventarioDetalle
        INSERT INTO InventarioDetalle (Folio, ProductID, Cantidad)
        VALUES (@Folio, @productoID, @cantidad);

        -- Confirma la transacción
        COMMIT;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshace la transacción si está activa
        IF @@TRANCOUNT > 0
            ROLLBACK;

        -- Maneja el error según tus necesidades, aquí se imprime un mensaje
        PRINT ERROR_MESSAGE();
    END CATCH;
END;
