
using Android.App;
using Android.Content.PM;
using Android.OS;

namespace BarcodeScanner.Droid
{
   [Activity(Label = "BarcodeScanner", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
   public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
   {
      protected override void OnCreate(Bundle bundle)
      {
         base.OnCreate(bundle);

         global::Xamarin.Forms.Forms.Init(this, bundle);
         LoadApplication(new App());
      }

      public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
      {
         global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
      }
   }
}

