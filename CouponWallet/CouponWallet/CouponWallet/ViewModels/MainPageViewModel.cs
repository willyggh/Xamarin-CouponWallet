using CouponWallet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace CouponWallet.ViewModels
{
    class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            SearchCommand = new Command(() => 
            {
                if (!string.IsNullOrEmpty(InputText) && !string.IsNullOrWhiteSpace(InputText))
                {
                    var barCode = new BarcodeModel
                    {
                        Barcode = InputText
                    };
                    LabelText = barCode.Barcode;
                    InputText = string.Empty; 
                }
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
