using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FACULTATIVE_REINSURANCE.View_model;

namespace FACULTATIVE_REINSURANCE.View
{
    /// <summary>
    /// Interaction logic for GeneralInformation.xaml
    /// </summary>
    public partial class GeneralInformation : UserControl
    {
        public GeneralInformation()
        {
            InitializeComponent();
            GeneralInfoViewModel model = new GeneralInfoViewModel();
            this.DataContext = model;
        }
    }
}
