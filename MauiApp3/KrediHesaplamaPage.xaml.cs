namespace MauiApp3;

public partial class KrediHesaplamaPage : ContentPage
{
    public KrediHesaplamaPage()
    {
        InitializeComponent(); // XAML'deki bileþenleri baþlatýr
    }

    // Vade Slider'ý deðiþtiðinde vade etiketi güncelleniyor
    private void VadeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Slider deðeri deðiþtiðinde, yeni deðeri yuvarlayarak VadeLabel üzerinde gösterir
        VadeLabel.Text = $"Vade: {Math.Round(e.NewValue)} Ay";
    }

    // Hesapla butonuna týklanýnca kredi hesaplamasý yapýlýyor
    private void HesaplaButton_Clicked(object sender, EventArgs e)
    {
        // Kullanýcýdan alýnan veriler:
        // Kredi türü, kredi tutarý, faiz oraný ve vade bilgileri
        string krediTuru = KrediTurPicker.SelectedItem.ToString(); // Seçilen kredi türü
        double krediTutari = Convert.ToDouble(KrediTutariEntry.Text); // Kredi tutarýný giriþ kutusundan al
        double faizOrani = Convert.ToDouble(FaizOraniEntry.Text); // Faiz oranýný giriþ kutusundan al
        int vadeAy = (int)VadeSlider.Value; // Vade süresini slider'dan al

        // Aylýk faiz hesaplamasý
        double aylikFaiz = faizOrani / 100 / 12; // Yýllýk faiz oranýný aylýk faiz oranýna çevir

        // Kredi Hesaplamasý: Basit kredi hesaplama formülü
        // Kredi taksiti, kredi tutarý, faiz oraný ve vade süresine göre hesaplanýyor
        double krediTaksiti = krediTutari * aylikFaiz / (1 - Math.Pow(1 + aylikFaiz, -vadeAy));

        // Toplam ödeme hesaplamasý
        double toplamOdeme = krediTaksiti * vadeAy; // Aylýk taksit ile vade süresinin çarpýmý

        // Toplam faiz hesaplamasý
        double toplamFaiz = toplamOdeme - krediTutari; // Toplam ödeme ile kredi tutarý arasýndaki fark

        // Sonuçlarý etiketle göster
        // Aylýk taksit, toplam ödeme ve toplam faiz etiketlerinde görüntüleniyor
        SonucLabel.Text = $"Aylýk Taksit: {krediTaksiti:C2}"; // Aylýk taksiti gösterir
        ToplamOdemeLabel.Text = $"Toplam Ödeme: {toplamOdeme:C2}"; // Toplam ödemeyi gösterir
        ToplamFaizLabel.Text = $"Toplam Faiz: {toplamFaiz:C2}"; // Toplam faiz miktarýný gösterir
    }
}
