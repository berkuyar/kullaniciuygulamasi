namespace MauiApp3;

public partial class RenkSeciciPage : ContentPage
{
    public RenkSeciciPage()
    {
        InitializeComponent(); // XAML'deki bile�enleri ba�lat�r
    }

    // Renk ayarlar� de�i�tik�e renk ve renk kodunu g�nceller
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // RGB de�erlerini slider'lardan al
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        // RGB etiketlerini g�ncelle
        RedLabel.Text = $"Red: {red}"; // K�rm�z� etiketini g�nceller
        GreenLabel.Text = $"Green: {green}"; // Ye�il etiketini g�nceller
        BlueLabel.Text = $"Blue: {blue}"; // Mavi etiketini g�nceller

        // Arka plan rengini RGB de�erlerine g�re g�nceller
        BackgroundColor = Color.FromRgb(red, green, blue);

        // Renk kodunu #RRGGBB format�nda olu�tur
        string renkKodu = $"#{red:X2}{green:X2}{blue:X2}"; // Hexadecimal formatta renk kodunu olu�turur
        ColorCodeLabel.Text = $"Renk Kodu: {renkKodu}"; // Renk kodu etiketini g�nceller
    }

    // Kopyala butonuna t�kland���nda renk kodu panoya kopyalan�r
    private async void KopyalaButton_Clicked(object sender, EventArgs e)
    {
        // Renk kodu etiketinden sadece renk kodunu al
        string renkKodu = ColorCodeLabel.Text.Replace("Renk Kodu: ", "");
        await Clipboard.SetTextAsync(renkKodu); // Renk kodunu panoya kopyalar
        await DisplayAlert("Kopyaland�", $"{renkKodu}", "OK"); // Kopyaland� mesaj�n� g�sterir
    }

    // Rastgele renk olu�turulup slider'lara atan�r
    private void RastgeleRenkButton_Clicked(object sender, EventArgs e)
    {
        Random rand = new Random(); // Rastgele say� �reticisi olu�turur
        int randomRed = rand.Next(0, 256); // 0 ile 255 aras�nda rastgele k�rm�z� de�eri �retir
        int randomGreen = rand.Next(0, 256); // 0 ile 255 aras�nda rastgele ye�il de�eri �retir
        int randomBlue = rand.Next(0, 256); // 0 ile 255 aras�nda rastgele mavi de�eri �retir

        // Slider'lara rastgele de�erleri atar
        RedSlider.Value = randomRed;
        GreenSlider.Value = randomGreen;
        BlueSlider.Value = randomBlue;

        // Slider'lar de�i�tik�e renk ve renk kodu g�ncellenir
        Slider_ValueChanged(sender, null); // Slider'�n de�erini de�i�tirdikten sonra renk ve renk kodunu g�nceller
    }
}
