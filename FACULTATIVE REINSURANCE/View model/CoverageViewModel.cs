using FACULTATIVE_REINSURANCE.Commands;
using FACULTATIVE_REINSURANCE.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Windows.Input;

namespace FACULTATIVE_REINSURANCE.View_model
{
    internal class CoverageViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ICommand _LostFocusCommand;
        private ICommand _IsCompletedCheckedCommand;
        private ICommand _IsCompletedUncheckedCommand;
        private int _totalofSection1;
        private int _totalofSection2;
        private List<CoverageDeatils> selectedSection1 = new List<CoverageDeatils>();
        private List<CoverageDeatils> selectedSection2 = new List<CoverageDeatils>();

        public event PropertyChangedEventHandler PropertyChanged;

        private int _totalofSection;
        private ICommand _LostFocusCommand2;
        private ICommand _IsCompletedCheckedCommand2;
        private ICommand _IsCompletedUncheckedCommand2;

        #endregion Fields

        #region Constructor

        public CoverageViewModel()
        {
            this.TotalInsuredFieldName = (ConfigurationManager.AppSettings.AllKeys.Contains("TotalInsuredFieldName") ? ConfigurationManager.AppSettings.Get("TotalInsuredFieldName") : "Sum of Total Insured Coverage ") + " : ";
            this.LostFocusCommmand = new RelayCommand(o => LostFouscTextBox(o));
            this.IsCompletedCheckedCommand = new RelayCommand(o => IsCheckedCommand(o));
            this.IsCompletedUncheckedCommand = new RelayCommand(o => IsUnCheckedCommand(o));
            this.LostFocusCommmand2 = new RelayCommand(o => LostFouscTextBox2(o));
            this.IsCompletedCheckedCommand2 = new RelayCommand(o => IsCheckedCommand2(o));
            this.IsCompletedUncheckedCommand2 = new RelayCommand(o => IsUnCheckedCommand2(o));
            this.LisOfSectionItems = new ObservableCollection<CoverageDeatils>();
            this.LisOfSectionItems.Add(new CoverageDeatils() { DisplayName = "value1", DefaultValue = 1000, MinValue = 1000, MaxValue = 5000 });
            this.LisOfSectionItems.Add(new CoverageDeatils() { DisplayName = "value2", DefaultValue = 1000, MinValue = 400, MaxValue = 2000 });
            this.TotalofSection1 = this.TotalofSection2 = this.TotalInsuredValue = 0;
            //this.LisOfSectionItems = CollectionDetails.CoverageDeatails;
        }

        #endregion Constructor

        #region Properties

        public int TotalofSection1
        {
            get { return _totalofSection1; }
            set
            {
                _totalofSection1 = value;
                TotalInsuredValue = TotalofSection1 + TotalofSection2;
                OnPropertyChanged("TotalofSection1");
            }
        }

        public int TotalofSection2
        {
            get { return _totalofSection2; }
            set
            {
                _totalofSection2 = value;
                TotalInsuredValue = TotalofSection1 + TotalofSection2;
                OnPropertyChanged("TotalofSection2");
            }
        }

        public int TotalInsuredValue
        {
            get { return _totalofSection; }
            set
            {
                _totalofSection = value;
                OnPropertyChanged("TotalInsuredValue");
            }
        }

        public string TotalInsuredFieldName { get; set; }

        public ObservableCollection<CoverageDeatils> LisOfSectionItems { get; set; }

        #endregion Properties

        #region Command Properties

        public ICommand LostFocusCommmand
        {
            get { return _LostFocusCommand; }
            set { _LostFocusCommand = value; }
        }

        public ICommand IsCompletedCheckedCommand
        {
            get { return _IsCompletedCheckedCommand; }
            set { _IsCompletedCheckedCommand = value; }
        }

        public ICommand IsCompletedUncheckedCommand
        {
            get { return _IsCompletedUncheckedCommand; }
            set { _IsCompletedUncheckedCommand = value; }
        }

        public ICommand LostFocusCommmand2
        {
            get { return _LostFocusCommand2; }
            set { _LostFocusCommand2 = value; }
        }

        public ICommand IsCompletedCheckedCommand2
        {
            get { return _IsCompletedCheckedCommand2; }
            set { _IsCompletedCheckedCommand2 = value; }
        }

        public ICommand IsCompletedUncheckedCommand2
        {
            get { return _IsCompletedUncheckedCommand2; }
            set { _IsCompletedUncheckedCommand2 = value; }
        }

        #endregion Command Properties

        #region Command Methods

        private void LostFouscTextBox(object parameter)
        {
            CoverageDeatils value = parameter as CoverageDeatils;
            if ((value != null))
            {
                CoverageDeatils section = this.selectedSection1.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                CoverageDeatils originalSection = this.LisOfSectionItems.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                if (originalSection.MinValue <= value.InputValue && originalSection.MaxValue >= value.InputValue)
                {
                    TotalofSection1 -= section.InputValue;
                    section.InputValue = value.InputValue;
                    TotalofSection1 += section.InputValue;
                }
                else
                {
                }
            }
        }

        private void IsCheckedCommand(object parameter)
        {
            CoverageDeatils value = parameter as CoverageDeatils;
            if ((value != null))
            {
                this.selectedSection1.Add(value);
                TotalofSection1 += value.InputValue;
            }
        }

        private void IsUnCheckedCommand(object parameter)
        {
            CoverageDeatils value = parameter as CoverageDeatils;
            if ((value != null))
            {
                this.selectedSection1.Remove(value);
                TotalofSection1 -= value.InputValue;
            }
        }

        private void LostFouscTextBox2(object parameter)
        {
            CoverageDeatils value = parameter as CoverageDeatils;
            if ((value != null))
            {
                CoverageDeatils section = this.selectedSection2.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                TotalofSection2 -= section.InputValue;
                section.InputValue = value.InputValue;
                TotalofSection2 += section.InputValue;
            }
        }

        private void IsCheckedCommand2(object parameter)
        {
            CoverageDeatils value = parameter as CoverageDeatils;
            if ((value != null))
            {
                this.selectedSection2.Add(value);
                TotalofSection2 += value.InputValue;
            }
        }

        private void IsUnCheckedCommand2(object parameter)
        {
            CoverageDeatils value = parameter as CoverageDeatils;
            if ((value != null))
            {
                this.selectedSection2.Remove(value);
                TotalofSection2 -= value.InputValue;
            }
        }

        #endregion Command Methods

        public void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}