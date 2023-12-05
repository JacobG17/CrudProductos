CREATE OR ALTER PROCEDURE DeshacerTransaccion
    @Folio INT,
	@folioNuevo INT,
    @ProductID INT,
    @cantidad INT,
	@sumaPrecioVentaTotal DECIMAL(18, 2)
AS
BEGIN
    BEGIN TRY
        -- Inicia la transacci�n
        BEGIN TRANSACTION;

        -- Obtiene la cantidad de productos actuales y le suma la cantidad a insertar
        DECLARE @cantidadActual INT, @nuevaCantidad INT;
        SELECT @cantidadActual = ISNULL(Saldo, 0) FROM Productos WHERE ProductID = @ProductID;

        -- Calcula la nueva cantidad
        SET @nuevaCantidad = @cantidadActual + @cantidad;

		-- Verifica si no existe un registro con el mismo Folio en la tabla Inventario
		IF NOT EXISTS (SELECT 1 FROM Inventario WHERE Folio = @folioNuevo)
		BEGIN
			-- Si no existe, realiza la inserci�n
			INSERT INTO Inventario (Folio, Fecha, Total, TipoMovimiento)
			VALUES (@folioNuevo, GETDATE(), @sumaPrecioVentaTotal, 'Entrada');
		END

        -- Actualiza el saldo del producto
        UPDATE Productos SET Saldo = @nuevaCantidad WHERE ProductID = @ProductID;

        -- Inserta en la tabla InventarioDetalle
        INSERT INTO InventarioDetalle (Folio, ProductID, Cantidad)
        VALUES (@folioNuevo, @ProductID, @cantidad);

        -- Confirma la transacci�n
        COMMIT;
    END TRY
    BEGIN CATCH
        -- En caso de error, deshace la transacci�n
        IF @@TRANCOUNT > 0
            ROLLBACK;

        -- Maneja el error seg�n tus necesidades
        THROW;
    END CATCH;
END;
