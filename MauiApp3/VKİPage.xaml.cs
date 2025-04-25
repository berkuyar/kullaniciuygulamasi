using Microsoft.Maui;

namespace MauiApp3;

public partial class VKİPage : ContentPage
{
    public VKİPage()
    {
        InitializeComponent(); // XAML'deki bileşenleri başlatır
    }

    // Slider'lar değiştikçe VKİ hesaplaması yapılacak
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Kilo ve boy değerlerini al
        double kilo = KiloSlider.Value; // Kilo slider'ından değeri al
        double boy = BoySlider.Value / 100; // Boyu cm'den metreye çevir

        // VKİ hesaplama formülü: Kilo / (Boy * Boy)
        double vki = kilo / (boy * boy); // VKİ hesaplama

        // Sonuçları etiketlere yaz
        KiloLabel.Text = $"Kilo: {kilo:F0} kg"; // Kilo etiketini güncelle
        BoyLabel.Text = $"Boy: {BoySlider.Value:F0} cm"; // Boy etiketini güncelle
        VKILabel.Text = $"VKİ: {vki:F2}"; // VKİ etiketini güncelle

        // VKİ sonucuna göre yorum ekleyebilirsiniz
        if (vki < 18.5)
            VKILabel.Text += " - Zayıf"; // VKİ 18.5'ten küçükse "Zayıf" ekle
        else if (vki < 24.9)
            VKILabel.Text += " - Normal"; // VKİ 24.9'dan küçükse "Normal" ekle
        else if (vki < 29.9)
            VKILabel.Text += " - Fazla Kilolu"; // VKİ 29.9'dan küçükse "Fazla Kilolu" ekle
        else
            VKILabel.Text += " - Obez"; // VKİ 29.9 veya daha büyükse "Obez" ekle
    }
}
