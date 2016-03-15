
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace BarcodeScanner
{
   public class HomePage : ContentPage
   {
      ZXingScannerPage scanPage;

      public HomePage()
      {
         var label = new Label
         {
            HorizontalOptions = LayoutOptions.CenterAndExpand,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
         };
         var button = new Button
         {
            Text = "Scan",
            HorizontalOptions = LayoutOptions.FillAndExpand
         };

         Content = new StackLayout
         {
            Children = { label, button  }
         };

         button.Clicked += async delegate {
            scanPage = new ZXingScannerPage
            {
               DefaultOverlayShowFlashButton = true
            };
            scanPage.OnScanResult += (result) => {
               scanPage.IsScanning = false;

               Device.BeginInvokeOnMainThread(async () => {
                  await Navigation.PopAsync();
                  label.Text = result.Text;
               });
            };

            await Navigation.PushAsync(scanPage);
         };
      }
   }
}
