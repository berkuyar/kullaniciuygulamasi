namespace MauiApp3;

public partial class KrediHesaplamaPage : ContentPage
{
    public KrediHesaplamaPage()
    {
        InitializeComponent(); // XAML'deki bile�enleri ba�lat�r
    }

    // Vade Slider'� de�i�ti�inde vade etiketi g�ncelleniyor
    private void VadeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Slider de�eri de�i�ti�inde, yeni de�eri yuvarlayarak VadeLabel �zerinde g�sterir
        VadeLabel.Text = $"Vade: {Math.Round(e.NewValue)} Ay";
    }

    // Hesapla butonuna t�klan�nca kredi hesaplamas� yap�l�yor
    private void HesaplaButton_Clicked(object sender, EventArgs e)
    {
        // Kullan�c�dan al�nan veriler:
        // Kredi t�r�, kredi tutar�, faiz oran� ve vade bilgileri
        string krediTuru = KrediTurPicker.SelectedItem.ToString(); // Se�ilen kredi t�r�
        double krediTutari = Convert.ToDouble(KrediTutariEntry.Text); // Kredi tutar�n� giri� kutusundan al
        double faizOrani = Convert.ToDouble(FaizOraniEntry.Text); // Faiz oran�n� giri� kutusundan al
        int vadeAy = (int)VadeSlider.Value; // Vade s�resini slider'dan al

        // Ayl�k faiz hesaplamas�
        double aylikFaiz = faizOrani / 100 / 12; // Y�ll�k faiz oran�n� ayl�k faiz oran�na �evir

        // Kredi Hesaplamas�: Basit kredi hesaplama form�l�
        // Kredi taksiti, kredi tutar�, faiz oran� ve vade s�resine g�re hesaplan�yor
        double krediTaksiti = krediTutari * aylikFaiz / (1 - Math.Pow(1 + aylikFaiz, -vadeAy));

        // Toplam �deme hesaplamas�
        double toplamOdeme = krediTaksiti * vadeAy; // Ayl�k taksit ile vade s�resinin �arp�m�

        // Toplam faiz hesaplamas�
        double toplamFaiz = toplamOdeme - krediTutari; // Toplam �deme ile kredi tutar� aras�ndaki fark

        // Sonu�lar� etiketle g�ster
        // Ayl�k taksit, toplam �deme ve toplam faiz etiketlerinde g�r�nt�leniyor
        SonucLabel.Text = $"Ayl�k Taksit: {krediTaksiti:C2}"; // Ayl�k taksiti g�sterir
        ToplamOdemeLabel.Text = $"Toplam �deme: {toplamOdeme:C2}"; // Toplam �demeyi g�sterir
        ToplamFaizLabel.Text = $"Toplam Faiz: {toplamFaiz:C2}"; // Toplam faiz miktar�n� g�sterir
    }
}
