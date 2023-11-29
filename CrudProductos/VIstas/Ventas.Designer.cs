namespace CrudProductos
{
    partial class Ventas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbFolio = new System.Windows.Forms.TextBox();
            this.txbProductoID = new System.Windows.Forms.TextBox();
            this.txbCantidad = new System.Windows.Forms.TextBox();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.txbPrecioVenta = new System.Windows.Forms.TextBox();
            this.dgvDetallesVenta = new System.Windows.Forms.DataGridView();
            this.dgvProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txbTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnAgregarProducto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesVenta)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 10F);
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 10F);
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 10F);
            this.label4.Location = new System.Drawing.Point(419, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 10F);
            this.label5.Location = new System.Drawing.Point(8, 111);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Descripcion:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 10F);
            this.label6.Location = new System.Drawing.Point(375, 167);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio Venta:";
            // 
            // txbFolio
            // 
            this.txbFolio.BackColor = System.Drawing.Color.White;
            this.txbFolio.Location = new System.Drawing.Point(58, 24);
            this.txbFolio.Margin = new System.Windows.Forms.Padding(2);
            this.txbFolio.Name = "txbFolio";
            this.txbFolio.ReadOnly = true;
            this.txbFolio.Size = new System.Drawing.Size(50, 20);
            this.txbFolio.TabIndex = 6;
            this.txbFolio.TabStop = false;
            // 
            // txbProductoID
            // 
            this.txbProductoID.BackColor = System.Drawing.Color.White;
            this.txbProductoID.Location = new System.Drawing.Point(85, 71);
            this.txbProductoID.Margin = new System.Windows.Forms.Padding(2);
            this.txbProductoID.Name = "txbProductoID";
            this.txbProductoID.Size = new System.Drawing.Size(123, 20);
            this.txbProductoID.TabIndex = 7;
            this.txbProductoID.TabStop = false;
            this.txbProductoID.TextChanged += new System.EventHandler(this.txbProductoID_TextChanged);
            this.txbProductoID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbProductoID_KeyPress);
            // 
            // txbCantidad
            // 
            this.txbCantidad.BackColor = System.Drawing.Color.White;
            this.txbCantidad.Location = new System.Drawing.Point(497, 114);
            this.txbCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.txbCantidad.Name = "txbCantidad";
            this.txbCantidad.ReadOnly = true;
            this.txbCantidad.Size = new System.Drawing.Size(48, 20);
            this.txbCantidad.TabIndex = 8;
            this.txbCantidad.TabStop = false;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.BackColor = System.Drawing.Color.White;
            this.txbDescripcion.Location = new System.Drawing.Point(11, 139);
            this.txbDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescripcion.Multiline = true;
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.ReadOnly = true;
            this.txbDescripcion.Size = new System.Drawing.Size(341, 104);
            this.txbDescripcion.TabIndex = 9;
            this.txbDescripcion.TabStop = false;
            // 
            // txbPrecioVenta
            // 
            this.txbPrecioVenta.BackColor = System.Drawing.Color.White;
            this.txbPrecioVenta.Location = new System.Drawing.Point(477, 168);
            this.txbPrecioVenta.Margin = new System.Windows.Forms.Padding(2);
            this.txbPrecioVenta.Name = "txbPrecioVenta";
            this.txbPrecioVenta.ReadOnly = true;
            this.txbPrecioVenta.Size = new System.Drawing.Size(68, 20);
            this.txbPrecioVenta.TabIndex = 10;
            this.txbPrecioVenta.TabStop = false;
            // 
            // dgvDetallesVenta
            // 
            this.dgvDetallesVenta.AllowUserToAddRows = false;
            this.dgvDetallesVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetallesVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvProductID,
            this.dgvDescripcion,
            this.dgvCantidad,
            this.dgvPrecioVenta});
            this.dgvDetallesVenta.Location = new System.Drawing.Point(11, 252);
            this.dgvDetallesVenta.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetallesVenta.Name = "dgvDetallesVenta";
            this.dgvDetallesVenta.ReadOnly = true;
            this.dgvDetallesVenta.RowTemplate.Height = 28;
            this.dgvDetallesVenta.Size = new System.Drawing.Size(536, 128);
            this.dgvDetallesVenta.TabIndex = 12;
            // 
            // dgvProductID
            // 
            this.dgvProductID.HeaderText = "ID Producto";
            this.dgvProductID.Name = "dgvProductID";
            this.dgvProductID.ReadOnly = true;
            // 
            // dgvDescripcion
            // 
            this.dgvDescripcion.HeaderText = "Descripcion";
            this.dgvDescripcion.Name = "dgvDescripcion";
            this.dgvDescripcion.ReadOnly = true;
            this.dgvDescripcion.Width = 200;
            // 
            // dgvCantidad
            // 
            this.dgvCantidad.HeaderText = "Cantidad";
            this.dgvCantidad.Name = "dgvCantidad";
            this.dgvCantidad.ReadOnly = true;
            // 
            // dgvPrecioVenta
            // 
            this.dgvPrecioVenta.HeaderText = "Precio";
            this.dgvPrecioVenta.Name = "dgvPrecioVenta";
            this.dgvPrecioVenta.ReadOnly = true;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 12F);
            this.lblFecha.Location = new System.Drawing.Point(455, 25);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(61, 18);
            this.lblFecha.TabIndex = 13;
            this.lblFecha.Text = "FECHA";
            // 
            // txbTotal
            // 
            this.txbTotal.BackColor = System.Drawing.Color.White;
            this.txbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTotal.Location = new System.Drawing.Point(469, 394);
            this.txbTotal.Margin = new System.Windows.Forms.Padding(2);
            this.txbTotal.Name = "txbTotal";
            this.txbTotal.ReadOnly = true;
            this.txbTotal.Size = new System.Drawing.Size(80, 23);
            this.txbTotal.TabIndex = 15;
            this.txbTotal.TabStop = false;
            this.txbTotal.Text = "$0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10F);
            this.label7.Location = new System.Drawing.Point(408, 395);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "TOTAL:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 408);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 32);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(123, 408);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(83, 32);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Ver Ventas";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(237, 408);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(83, 32);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnAgregarProducto
            // 
            this.btnAgregarProducto.Location = new System.Drawing.Point(355, 218);
            this.btnAgregarProducto.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregarProducto.Name = "btnAgregarProducto";
            this.btnAgregarProducto.Size = new System.Drawing.Size(58, 23);
            this.btnAgregarProducto.TabIndex = 19;
            this.btnAgregarProducto.Text = "Agregar";
            this.btnAgregarProducto.UseVisualStyleBackColor = true;
            this.btnAgregarProducto.Click += new System.EventHandler(this.btnAgregarProducto_Click);
            // 
            // Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 468);
            this.Controls.Add(this.btnAgregarProducto);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txbTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dgvDetallesVenta);
            this.Controls.Add(this.txbPrecioVenta);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.txbCantidad);
            this.Controls.Add(this.txbProductoID);
            this.Controls.Add(this.txbFolio);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Ventas";
            this.Text = "Ventas";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Ventas_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetallesVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbFolio;
        private System.Windows.Forms.TextBox txbProductoID;
        private System.Windows.Forms.TextBox txbCantidad;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.TextBox txbPrecioVenta;
        private System.Windows.Forms.DataGridView dgvDetallesVenta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txbTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnAgregarProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrecioVenta;
    }
}

