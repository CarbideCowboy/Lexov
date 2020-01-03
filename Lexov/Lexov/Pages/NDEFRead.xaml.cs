using Lexov.Utilities;
using NdefLibrary.Ndef;
using Poz1.NFCForms.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Lexov.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDEFRead : ContentPage
    {
        private Renderers.ExpandableEditor uxNDEFEditor;
        private double previousScrollPosition = 0;
        private string ndefPayloadRead;
        public NDEFRead(string NDEFPayload)
        {
            InitializeComponent();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();

            checkEncrypted(NDEFPayload);

            ndefPayloadRead = NDEFPayload;
            uxClearButton.Clicked += uxClearButton_Clicked;
            uxWriteButton.Clicked += uxWriteButton_Clicked;
            uxNDEFScroll.Scrolled += uxNDEFScroll_Scrolled;

            uxNDEFEditor = new Renderers.ExpandableEditor()
            {
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.FillAndExpand,
                FontFamily = (OnPlatform<string>)Application.Current.Resources["NormalFont"]
            };

            uxNDEFEditor.Text = ndefPayloadRead;
            uxNDEFStack.Children.Add(uxNDEFEditor);
        }

        async void checkEncrypted(string NDEFPayload)
        {
            if (NDEFPayload.Length < 27)
            {
                return;
            }

            else if (!NDEFPayload.Substring(0, 27).Equals("-----BEGIN PGP MESSAGE-----"))
            {
                return;
            }

            else
            {
                if(await DisplayAlert("PGP ecrypted payload detected","Attempt decryption in OpenKeychain?", "Yes", "No"))
                {
                    await Clipboard.SetTextAsync(NDEFPayload);
                    DependencyService.Get<Utilities.IOpenApp>().OpenExternalApp();
                }
            }
        }

        void uxWriteButton_Clicked(object sender, EventArgs e)
        {
            var ndefMessage = Utilities.NDEFHandler.makeTextNDEFRecord(uxNDEFEditor.Text);
            Navigation.PushAsync(new Pages.NDEFWrite(ndefMessage));
        }

        private void uxNDEFScroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            if(previousScrollPosition < e.ScrollY)
            {
                hideButtons();
                previousScrollPosition = e.ScrollY;
            }

            else if(previousScrollPosition > e.ScrollY)
            {
                showButtons();
                previousScrollPosition = e.ScrollY;
            }
        }

        private async void hideButtons()
        {
            await uxButtonStack.FadeTo(0, 100);
            await Task.Delay(100);
            uxButtonStack.IsVisible = false;
        }

        private async void showButtons()
        {
            await uxButtonStack.FadeTo(1, 100);
            uxButtonStack.IsVisible = true;
        }

        async void uxClearButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirm", "Are you sure you want to clear the current NDEF record?", "Yes", "No"))
            {
                await Navigation.PopAsync();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}