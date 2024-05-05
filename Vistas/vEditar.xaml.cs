using dgalvezS5.Modelos;

namespace dgalvezS5.Vistas;

public partial class vEditar : ContentPage
{
	public vEditar(string nombre, int id)
	{
		InitializeComponent();
		txtNombre.Text = nombre;
		lblIb.Text = id.ToString();
	}

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
		string nuevonombre = txtNombre.Text;
		int id = int.Parse(lblIb.Text);

		if (id > 0)
		{
	Persona persona = new Persona{Id = id, Name = nuevonombre};
		App.PersonRepo.UpdatePerson(persona);
		}
		else
		{
			App.PersonRepo.addNewPerson(nuevonombre);
		}

    }
}