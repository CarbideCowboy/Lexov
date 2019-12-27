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

namespace Lexov.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NDEFRead : ContentPage
    {
        private Editor uxNDEFEditor;
        private readonly INfcForms device;
        private double previousScrollPosition = 0;
        public NDEFRead()
        {
            InitializeComponent();

            device = DependencyService.Get<INfcForms>();
            device.NewTag += HandleNewTag;
            uxRefreshButton.Clicked += uxRefreshButton_Clicked;
            uxNDEFScroll.Scrolled += uxNDEFScroll_Scrolled;
        }

        private async void uxNDEFScroll_Scrolled(object sender, ScrolledEventArgs e)
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

        private void showButtons()
        {
            uxButtonStack.FadeTo(1, 100);
            uxButtonStack.IsVisible = true;
        }

        private string readNDEFMessage(NdefMessage message)
        {
            if(message == null)
            {
                return "Tag is empty";
            }

            NdefTextRecord record = new NdefTextRecord(message.ElementAtOrDefault(0));

            return record.Text;
        }

        void HandleNewTag(object sender, NfcFormsTag e)
        {
            lblNFCIcon.IsVisible = false;
            lblScanMessage.IsVisible = false;

            uxButtonStack.IsVisible = true;

            uxNDEFEditor = new Editor()
            {
                TextColor = Color.White
            };

            string readNDEF = readNDEFMessage(e.NdefMessage);
            uxNDEFEditor.Text = readNDEF;
            uxNDEFStack.Children.Add(uxNDEFEditor);
        }

        async void uxRefreshButton_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirm", "Are you sure you want to clear the current NDEF record?", "Yes", "No"))
            {
                uxNDEFStack.Children.Remove(uxNDEFEditor);
                uxButtonStack.IsVisible = false;
                lblNFCIcon.IsVisible = true;
                lblScanMessage.IsVisible = true;
            }
        }
    }
}