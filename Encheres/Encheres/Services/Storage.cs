﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Encheres.Services
{
    class Storage
    {
        public static async void StockerMotDePasse(string id)
        {
            try
            {
                await SecureStorage.SetAsync("ID", id);
            }
            catch (Exception ex)
            {
                // Possible that device doesn't support secure storage on device.
            }
        }
    }
}
