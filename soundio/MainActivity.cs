using Android.Content;
using System;
using Android.App;
using Android.Widget;
using Android.OS;
using soundio.Activities;

namespace soundio
{
    
        [Activity(Label = "@string/app_name", MainLauncher = true)]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.activity_main);              
            
                Intent intent = new Intent(this, typeof(LoginActivity));

                // Inicia Activity
                StartActivity(intent);

            }
         
        }
    }
