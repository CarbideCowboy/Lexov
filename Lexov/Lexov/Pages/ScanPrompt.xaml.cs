using Lexov.Utilities;
using NdefLibrary.Ndef;
using Poz1.NFCForms.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lexov.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPrompt : ContentPage
    {
        private readonly INfcForms device;
        public ScanPrompt()
        {
            InitializeComponent();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();

            device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
            uxBlankButton.Clicked += uxBlankButton_Clicked;

            MessagingCenter.Subscribe<NdefMessage>(this, "RecordIncompatible", async (sender) =>
            {
                await DisplayAlert("Error", "Incompatible NDEF record, make sure your tag's NDEF record is formatted as plain text", "OK");
            });
        }

        private void uxBlankButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Pages.NDEFRead(""));
        }

        private void HandleNewTag(object sender, NfcFormsTag e)
        {
            if(Navigation.NavigationStack.Count == 1)
            {
                Navigation.PushAsync(new Pages.NDEFRead(Utilities.NDEFHandler.readNDEFPlainText(e.NdefMessage)));
            }
        }
    }
}