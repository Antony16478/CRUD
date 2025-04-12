namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        CrudDB umg;

        public Form1()
        {
            InitializeComponent();
            umg = new CrudDB();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            string carnet = Carnet.Text;
            textBoxNombre.Text = umg.ObtenerNombrePorCarnet(carnet);
            textBoxSeccion.Text = umg.ObtenerSeccion(carnet);

            string[] notas = { "nota1", "nota2", "nota3", "nota4" };
            TextBox[] textBoxes = { textBoxNota1, textBoxNota2, textBoxNota3, textBoxNota4 };

            for (int i = 0; i < notas.Length; i++)
                textBoxes[i].Text = umg.ObtenerNota(carnet, notas[i]);
        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            string carnet = Carnet.Text;
            string nombre = textBoxNombre.Text;
            string seccion = textBoxSeccion.Text;

            string[] notas = { textBoxNota1.Text, textBoxNota2.Text, textBoxNota3.Text, textBoxNota4.Text };

            umg.AgregarAlumno(carnet, nombre, "", seccion);
            umg.AgregarTareas(carnet, notas[0], notas[1], notas[2], notas[3]);

            LimpiarCampos();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
            string carnet = Carnet.Text;
            umg.EliminarTareas(carnet);
            umg.EliminarALumno(carnet);

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            Carnet.Text = textBoxNombre.Text = textBoxSeccion.Text = "";
            textBoxNota1.Text = textBoxNota2.Text = textBoxNota3.Text = textBoxNota4.Text = "";
        }
    }
}