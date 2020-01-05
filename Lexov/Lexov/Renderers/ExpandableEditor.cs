using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lexov.Renderers
{
    //modified editor that allows the scroll view to work correctly
    //when the editor view is full
    public class ExpandableEditor : Editor
    {
        public ExpandableEditor()
        {
            TextChanged += OnTextChanged;
        }

        ~ExpandableEditor()
        {
            TextChanged += OnTextChanged;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidateMeasure();
        }
    }
}
