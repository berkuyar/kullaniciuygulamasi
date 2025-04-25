namespace MauiApp3;

public partial class RenkSeciciPage : ContentPage
{
    public RenkSeciciPage()
    {
        InitializeComponent(); // XAML'deki bileþenleri baþlatýr
    }

    // Renk ayarlarý deðiþtikçe renk ve renk kodunu günceller
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // RGB deðerlerini slider'lardan al
        int red = (int)RedSlider.Value;
        int green = (int)GreenSlider.Value;
        int blue = (int)BlueSlider.Value;

        // RGB etiketlerini güncelle
        RedLabel.Text = $"Red: {red}"; // Kýrmýzý etiketini günceller
        GreenLabel.Text = $"Green: {green}"; // Yeþil etiketini günceller
        BlueLabel.Text = $"Blue: {blue}"; // Mavi etiketini günceller

        // Arka plan rengini RGB deðerlerine göre günceller
        BackgroundColor = Color.FromRgb(red, green, blue);

        // Renk kodunu #RRGGBB formatýnda oluþtur
        string renkKodu = $"#{red:X2}{green:X2}{blue:X2}"; // Hexadecimal formatta renk kodunu oluþturur
        ColorCodeLabel.Text = $"Renk Kodu: {renkKodu}"; // Renk kodu etiketini günceller
    }

    // Kopyala butonuna týklandýðýnda renk kodu panoya kopyalanýr
    private async void KopyalaButton_Clicked(object sender, EventArgs e)
    {
        // Renk kodu etiketinden sadece renk kodunu al
        string renkKodu = ColorCodeLabel.Text.Replace("Renk Kodu: ", "");
        await Clipboard.SetTextAsync(renkKodu); // Renk kodunu panoya kopyalar
        await DisplayAlert("Kopyalandý", $"{renkKodu}", "OK"); // Kopyalandý mesajýný gösterir
    }

    // Rastgele renk oluþturulup slider'lara atanýr
    private void RastgeleRenkButton_Clicked(object sender, EventArgs e)
    {
        Random rand = new Random(); // Rastgele sayý üreticisi oluþturur
        int randomRed = rand.Next(0, 256); // 0 ile 255 arasýnda rastgele kýrmýzý deðeri üretir
        int randomGreen = rand.Next(0, 256); // 0 ile 255 arasýnda rastgele yeþil deðeri üretir
        int randomBlue = rand.Next(0, 256); // 0 ile 255 arasýnda rastgele mavi deðeri üretir

        // Slider'lara rastgele deðerleri atar
        RedSlider.Value = randomRed;
        GreenSlider.Value = randomGreen;
        BlueSlider.Value = randomBlue;

        // Slider'lar deðiþtikçe renk ve renk kodu güncellenir
        Slider_ValueChanged(sender, null); // Slider'ýn deðerini deðiþtirdikten sonra renk ve renk kodunu günceller
    }
}
