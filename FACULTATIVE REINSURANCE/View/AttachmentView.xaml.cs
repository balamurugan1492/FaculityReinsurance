using FACULTATIVE_REINSURANCE.View_model;

namespace FACULTATIVE_REINSURANCE.View
{
    /// <summary>
    /// Interaction logic for AttachmentView.xaml
    /// </summary>
    public partial class AttachmentView : System.Windows.Controls.UserControl
    {
        public AttachmentView()
        {
            InitializeComponent();
            AttachmentViewModel model = new AttachmentViewModel();
            this.DataContext = model;
        }
    }
}