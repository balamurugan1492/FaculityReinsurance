using FACULTATIVE_REINSURANCE.Commands;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Input;

namespace FACULTATIVE_REINSURANCE.View_model
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Constructor

        public MainWindowViewModel()
        {
            string[] Keys = ConfigurationManager.AppSettings.AllKeys;
            this.HeaderTitle = Keys.Contains("HeaderTitle") ? ConfigurationManager.AppSettings.Get("HeaderTitle") : "Faculative ReInsurance";
            this.MainTitle = Keys.Contains("MainTitle") ? ConfigurationManager.AppSettings.Get("MainTitle") : "Welcome To Faculative ReInsurance";
            this.CreateInsurance = Keys.Contains("CreateInsurance") ? ConfigurationManager.AppSettings.Get("CreateInsurance") : "Create Insurance";
            this.ViewInsurance = Keys.Contains("ViewInsurance") ? ConfigurationManager.AppSettings.Get("ViewInsurance") : "View Insurance";
            this.TabItem1Title = Keys.Contains("TabItem1Title") ? ConfigurationManager.AppSettings.Get("TabItem1Title") : "General Information";
            this.TabItem2Title = Keys.Contains("TabItem2Title") ? ConfigurationManager.AppSettings.Get("TabItem2Title") : "Coverage Section";
            this.TabItem3Title = Keys.Contains("TabItem3Title") ? ConfigurationManager.AppSettings.Get("TabItem3Title") : "Extensions";
            this.TabItem4Title = Keys.Contains("TabItem4Title") ? ConfigurationManager.AppSettings.Get("TabItem4Title") : "Policy Information";
            this.TabItem5Title = Keys.Contains("TabItem5Title") ? ConfigurationManager.AppSettings.Get("TabItem5Title") : "Attachments";
            this.CreateIsCheckedCommand = new RelayCommand(o => CreateViewChacked(o));
            this.ViewIsCheckedCommand = new RelayCommand(o => DataGridView(o));
            this.CreateCheckBoxCheck = true;
            this.TabItemVisiblity = true;
        }

        private void DataGridView(object parameter)
        {
            this.DataGridViewVisbility = true;
            this.TabItemVisiblity = false;
        }

        private void CreateViewChacked(object parameter)
        {
            this.TabItemVisiblity = true;
            this.DataGridViewVisbility = false;
        }

        #endregion Constructor

        #region LableProperties

        public string HeaderTitle { get; set; }
        public string MainTitle { get; set; }
        public string CreateInsurance { get; set; }
        public string ViewInsurance { get; set; }

        public string TabItem1Title { get; set; }

        public string TabItem2Title { get; set; }

        public string TabItem4Title { get; set; }

        public string TabItem3Title { get; set; }

        public string TabItem5Title { get; set; }

        #endregion LableProperties

        private bool _TabItemVisiblity;

        public bool TabItemVisiblity
        {
            get { return _TabItemVisiblity; }
            set
            {
                _TabItemVisiblity = value;
                OnPropertyChanged("TabItemVisiblity");
            }
        }

        private bool _CreateCheckBox;

        public bool CreateCheckBoxCheck
        {
            get { return _CreateCheckBox; }
            set { _CreateCheckBox = value; OnPropertyChanged("CreateCheckBoxCheck"); }
        }

        private bool _DataGridViewVisbility;

        public bool DataGridViewVisbility
        {
            get { return _DataGridViewVisbility; }
            set
            {
                _DataGridViewVisbility = value;
                OnPropertyChanged("DataGridViewVisbility");
            }
        }

        public ICommand CreateIsCheckedCommand
        {
            get { return _CreateIsCheckedCommand; }
            set { _CreateIsCheckedCommand = value; }
        }

        private ICommand _ViewIsCheckedCommand;

        public ICommand ViewIsCheckedCommand
        {
            get { return _ViewIsCheckedCommand; }
            set { _ViewIsCheckedCommand = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _CreateIsCheckedCommand;

        public void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}