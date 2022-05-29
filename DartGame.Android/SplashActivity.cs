using Android.App;
using Android.Support.V7.App;
using DartGame.Droid;

namespace MyDartCounter
{
    [Activity(Theme = "@style/splashscreen", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();

            StartActivity(typeof(MainActivity));
        }
    }
}