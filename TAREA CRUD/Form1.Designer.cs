namespace WinFormsApp2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            // Inicialización de controles
            CARNET = new TextBox { Location = new Point(331, 29), Size = new Size(182, 27), TextAlign = HorizontalAlignment.Center };
            CARNET.TextChanged += Carnet_TextChanged;

            Buscar = new Button
            {
                Text = "Buscar",
                Location = new Point(590, 3),
                Size = new Size(148, 74),
                BackColor = SystemColors.Info,
                Font = new Font("Showcard Gothic", 10.8F, FontStyle.Bold)
            };
            Buscar.Click += Buscar_Click;

            textBoxNombre = new TextBox { Location = new Point(242, 184), Size = new Size(461, 27), TextAlign = HorizontalAlignment.Center };
            textBoxSeccion = new TextBox { Location = new Point(381, 247), Size = new Size(102, 27), TextAlign = HorizontalAlignment.Center };

            textBoxNota1 = CrearTextBoxNota(new Point(413, 331));
            textBoxNota2 = CrearTextBoxNota(new Point(413, 366));
            textBoxNota3 = CrearTextBoxNota(new Point(413, 401));
            textBoxNota4 = CrearTextBoxNota(new Point(413, 446));

            BUTTONCARNET = CrearLabel("Carnet:", new Point(274, 33));
            label2 = CrearLabel("Nombre:", new Point(147, 187));
            label3 = CrearLabel("Sección:", new Point(281, 250));
            label4 = CrearLabel("Nota 1:", new Point(333, 334));
            label5 = CrearLabel("Nota 2:", new Point(333, 373));
            label6 = CrearLabel("Nota 3:", new Point(331, 404));
            label7 = CrearLabel("Nota 4:", new Point(333, 446));

            CrearNuevoRegistro = CrearBoton("Crear", new Point(274, 506), button1_Click);
            button3 = CrearBoton("Eliminar", new Point(426, 506), button3_Click);

            // Configuración del formulario
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.AddRange(new Control[]
            {
                CARNET, Buscar, textBoxNombre, textBoxSeccion, textBoxNota1, textBoxNota2, textBoxNota3, textBoxNota4,
                BUTTONCARNET, label2, label3, label4, label5, label6, label7, CrearNuevoRegistro, button3
            });
            Text = "UMG";
            Load += Form1_Load;
        }

        private TextBox CrearTextBoxNota(Point location)
        {
            return new TextBox { Location = location, Size = new Size(55, 27), TextAlign = HorizontalAlignment.Center };
        }

        private Label CrearLabel(string text, Point location)
        {
            return new Label { Text = text, Location = location, Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold), AutoSize = true };
        }

        private Button CrearBoton(string text, Point location, EventHandler onClick)
        {
            return new Button
            {
                Text = text,
                Location = location,
                Size = new Size(113, 57),
                BackColor = SystemColors.Info,
                Font = new Font("Segoe UI", 11.25F, FontStyle.Bold),
                UseVisualStyleBackColor = false
            };
        }

        #endregion

        private TextBox CARNET;
        private Button Buscar;
        private TextBox textBoxNombre;
        private TextBox textBoxSeccion;
        private TextBox textBoxNota1;
        private TextBox textBoxNota2;
        private TextBox textBoxNota3;
        private TextBox textBoxNota4;
        private Label BUTTONCARNET;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button CrearNuevoRegistro;
        private Button button3;
    }
}