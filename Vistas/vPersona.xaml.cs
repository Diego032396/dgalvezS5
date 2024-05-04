using dgalvezS5.Modelos;

namespace dgalvezS5.Vistas;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
       lblStatus.Text = "";
        App.PersonRepo.addNewPerson(txtPersona.Text);
        lblStatus.Text = App.PersonRepo.statusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
       // lblStatus.Text = "";
        List<Persona> people=App.PersonRepo.GetAllPeople();
        listapersona.ItemsSource = people;
    }

    private void btnUpdate_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        Navigation.PushAsync(new Vistas.vEditar(persona.Name, persona.Id));




    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        bool confirmacion = await DisplayAlert("Confirmacion", $"¿Estás seguro de borrar a {persona.Name}?", "si", "no");

        if (confirmacion)
        {
            App.PersonRepo.DeletePerson(persona.Id);
            await DisplayAlert("Confirmacion", App.PersonRepo.statusMessage, "Aceptar");
            btnObtener_Clicked(sender,e);

        }

    }
}