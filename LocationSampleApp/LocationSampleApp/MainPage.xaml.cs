using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using Xamarin.Essentials;

namespace LocationSampleApp
{
    public partial class MainPage : ContentPage
    {
        bool isGettingLocation;
        public MainPage()
        {
            InitializeComponent();
            
        }

        async void BtnGetLocation_Clicked(object sender, EventArgs e)
        {
            resultLocation.Text = "";
            isGettingLocation = true;
            
            while(isGettingLocation)
            {
                var result = await Geolocation.GetLocationAsync(new
                GeolocationRequest(GeolocationAccuracy.Default, TimeSpan.FromSeconds(30)));

                resultLocation.Text += $"lat: {result.Latitude}, lng: {result.Longitude} {Environment.NewLine}";
                await Task.Delay(1000);
            }
            
        }
        void BtnStopLocation_Clicked(object sender, EventArgs e)
        {
            isGettingLocation=false;
        }

    }
}
