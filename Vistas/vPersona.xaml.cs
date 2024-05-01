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
        lblStatus.Text = "";
        List<Persona> people=App.PersonRepo.GetAllPeople();
        listapersona.ItemsSource = people;
    }
}