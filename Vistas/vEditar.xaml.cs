namespace dgalvezS5.Vistas;

public partial class vEditar : ContentPage
{
	public vEditar(string nombre, int id)
	{
		InitializeComponent();
		txtNombre.Text = nombre;
		lblIb.Text =id.ToString();
		
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {


    }
}