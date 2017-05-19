using FACULTATIVE_REINSURANCE.View_model;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;

namespace FACULTATIVE_REINSURANCE.View
{
    /// <summary>
    /// Interaction logic for CoverageView.xaml
    /// </summary>
    public partial class CoverageView : UserControl
    {
        public CoverageView()
        {
            InitializeComponent();
            CoverageViewModel model = new CoverageViewModel();
            this.DataContext = model;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }
    }
}