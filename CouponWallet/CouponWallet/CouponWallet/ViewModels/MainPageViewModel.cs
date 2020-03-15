using CouponWallet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace CouponWallet.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            SearchCommand = new Command(async () => 
            {
                //var barCode = new BarcodeModel
                //{
                //    Barcode = InputText
                //};
                //LabelText = barCode.Barcode;
                //InputText = string.Empty;

                ZXingScannerPage scanPage;

                scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) =>
                {
                    scanPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PopAsync();
                        await Application.Current.MainPage.DisplayAlert("Scanned Barcode", result.Text, "OK");
                    });
                };

                await Application.Current.MainPage.Navigation.PushAsync(scanPage);

            });
        }

        string input;
        public string InputText
        {
            get => input;
            set 
            {
                input = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(InputText)));
            }
        }

        string infoLabel;
        public string LabelText
        {
            get => infoLabel;
            set 
            {
                infoLabel = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LabelText)));
            }
        }


        public Command SearchCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
