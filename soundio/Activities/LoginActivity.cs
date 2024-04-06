using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
﻿using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using soundio.BaseClasses;

namespace soundio.Activities
{
  
        [Activity(Name = "com.companyname.soundio.LoginActivity", Theme = "@android:style/Theme.DeviceDefault")]
        public class LoginActivity : Activity
        {
            FirebaseClient firebase = new FirebaseClient("https://ifpr-alerts-default-rtdb.firebaseio.com/");
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                SetContentView(Resource.Layout.activity_login);

            Button LoginButton = FindViewById<Button>(Resource.Id.loginButton);
            LoginButton.Click += LoginButton_Click;

            }
            private async void LoginButton_Click(object sender, EventArgs e)
        {
            var email = FindViewById<EditText>(Resource.Id.emailEditText)?.Text;
            var password = FindViewById<EditText>(Resource.Id.passwordEditText)?.Text;

            var usuario = (await firebase.
                 Child("usuarios")
                .OnceAsync<Usuario>()).Select(user => new Usuario
                {
                    Email = user.Object.Email,
                    Senha = user.Object.Senha
                }).Where(item => item.Email == email && item.Senha == password).FirstOrDefault();

            if (usuario != null)
            {
                try
                {
                    Toast.MakeText(this, "Usuário logado com sucesso!", ToastLength.Short)?.Show();
                    Console.WriteLine("Usuário logado com sucesso!");

                    Finish();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro de autenticação: {ex.Message}");
                }
            }
            else
            {
                Toast.MakeText(this, "Usuário não encontrado!", ToastLength.Short)?.Show();
                Console.WriteLine("Usuário não encontrado!");
            }
        }
        }

}
