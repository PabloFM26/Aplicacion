namespace Aplicacion;
    public partial class MainPage : ContentPage
    {
    string translatedNumber;
    public MainPage()
        {
            InitializeComponent();
        }
    private void OnTranslate(object sender, EventArgs e)
    {
        string enteredNumber = PhoneNumberText.Text;
        translatedNumber = Aplicacion.PhonewordTranslator.ToNumber(enteredNumber);

        if (!string.IsNullOrEmpty(translatedNumber))
        {
            CallButton.IsEnabled = true;
            CallButton.Text = "Llamar " + translatedNumber;
            CallButton.BackgroundColor = Colors.Red;
            CallButton.TextColor = Colors.White;
        }
        else
        {
            CallButton.IsEnabled = false;
            CallButton.Text = "Llamar";
            CallButton.BackgroundColor = Colors.DarkRed;
        }
    }


    async void OnCall(object sender, System.EventArgs e)
    {
        if (await this.DisplayAlert(
            "Llamar al número ",
            "¿Quieres llamar al numero " + translatedNumber + "?",
            "Si",
            "No"))
        {
            try
            {
                if (PhoneDialer.Default.IsSupported)
                    PhoneDialer.Default.Open(translatedNumber);
            }
            catch (ArgumentNullException)
            {
                await DisplayAlert("No se puede llamar ", "El número de teléfono no es válido", "OK");
            }
            catch (Exception)
            {
    
                await DisplayAlert("No se puede llamar ", "Error al marcar el teléfono", "OK");
            }
        }
    }

}
