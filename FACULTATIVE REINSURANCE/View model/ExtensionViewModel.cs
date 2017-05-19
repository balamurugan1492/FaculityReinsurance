using FACULTATIVE_REINSURANCE.Commands;
using FACULTATIVE_REINSURANCE.Util;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace FACULTATIVE_REINSURANCE.View_model
{
    internal class ExtensionViewModel : INotifyPropertyChanged
    {
        private ICommand _LostFocusCommand;
        private ICommand _IsCompletedCheckedCommand;
        private ICommand _IsCompletedUncheckedCommand;
        private List<ExtenstionDetails> selectedExtensionSection1 = new List<ExtenstionDetails>();
        private List<ExtenstionDetails> selectedExtensionSection2 = new List<ExtenstionDetails>();
        private ICommand _LostFocusCommand2;
        private ICommand _IsCompletedCheckedCommand2;
        private ICommand _IsCompletedUncheckedCommand2;

        public event PropertyChangedEventHandler PropertyChanged;

        public ExtensionViewModel()
        {
            this.LisOfSectionItems = new ObservableCollection<ExtenstionDetails>();
            this.LostFocusCommmand = new RelayCommand(o => LostFouscTextBox(o));
            this.IsCompletedCheckedCommand = new RelayCommand(o => IsCheckedCommand(o));
            this.IsCompletedUncheckedCommand = new RelayCommand(o => IsUnCheckedCommand(o));
            this.LostFocusCommmand2 = new RelayCommand(o => LostFouscTextBox2(o));
            this.IsCompletedCheckedCommand2 = new RelayCommand(o => IsCheckedCommand2(o));
            this.IsCompletedUncheckedCommand2 = new RelayCommand(o => IsUnCheckedCommand2(o));
            this.LisOfSectionItems.Add(new ExtenstionDetails() { DisplayName = "value1", DefaultValue = "sample1" });
            this.LisOfSectionItems.Add(new ExtenstionDetails() { DisplayName = "value2", DefaultValue = "sample2" });
            this.LisOfSectionItems.Add(new ExtenstionDetails() { DisplayName = "value3", DefaultValue = "sample3" });
            this.LisOfSectionItems.Add(new ExtenstionDetails() { DisplayName = "value4", DefaultValue = "sample4" });
            this.LisOfSectionItems.Add(new ExtenstionDetails() { DisplayName = "value5", DefaultValue = "sample5" });
            this.LisOfSectionItems.Add(new ExtenstionDetails() { DisplayName = "value6", DefaultValue = "sample6" });
        }

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
            if ((parameter != null))
            {
                ExtenstionDetails value = parameter as ExtenstionDetails;
                if (!string.IsNullOrWhiteSpace(value.InputValue))
                {
                    ExtenstionDetails section = this.selectedExtensionSection1.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                    if (section.InputValue != value.InputValue)
                    {
                        section.InputValue = value.InputValue;
                    }
                }
                else
                {
                }
            }
        }

        private void IsCheckedCommand(object parameter)
        {
            ExtenstionDetails value = parameter as ExtenstionDetails;
            if ((value != null))
            {
                this.selectedExtensionSection1.Add(value);
            }
        }

        private void IsUnCheckedCommand(object parameter)
        {
            ExtenstionDetails value = parameter as ExtenstionDetails;
            if ((value != null))
            {
                ExtenstionDetails section = this.selectedExtensionSection1.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                if (section != null)
                    this.selectedExtensionSection1.Remove(section);
                else
                { }
            }
        }

        private void LostFouscTextBox2(object parameter)
        {
            if ((parameter != null))
            {
                ExtenstionDetails value = parameter as ExtenstionDetails;
                if (!string.IsNullOrWhiteSpace(value.InputValue))
                {
                    ExtenstionDetails section = this.selectedExtensionSection2.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                    if (section.InputValue != value.InputValue)
                    {
                        section.InputValue = value.InputValue;
                    }
                }
                else
                {
                }
            }
        }

        private void IsCheckedCommand2(object parameter)
        {
            ExtenstionDetails value = parameter as ExtenstionDetails;
            if ((value != null))
            {
                this.selectedExtensionSection2.Add(value);
            }
        }

        private void IsUnCheckedCommand2(object parameter)
        {
            ExtenstionDetails value = parameter as ExtenstionDetails;
            if ((value != null))
            {
                ExtenstionDetails section = this.selectedExtensionSection2.Where(x => x.DisplayName == value.DisplayName).FirstOrDefault();
                if (section != null)
                    this.selectedExtensionSection2.Remove(section);
                else
                { }
            }
        }

        #endregion Command Methods

        public ObservableCollection<ExtenstionDetails> LisOfSectionItems { get; set; }

        public void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}