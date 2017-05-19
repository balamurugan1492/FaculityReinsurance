using FACULTATIVE_REINSURANCE.Commands;
using FACULTATIVE_REINSURANCE.Util;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace FACULTATIVE_REINSURANCE.View_model
{
    internal class AttachmentViewModel : INotifyPropertyChanged
    {
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private long fileSize = 0;
        private ObservableCollection<AttachmentDetails> _AttactmentList = new ObservableCollection<AttachmentDetails>();
        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private ICommand _ButtonCommand;
        private string _ErrorMessage;
        private ICommand _LabelLeftClick;

        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand _LostFocusCommand;

        public AttachmentViewModel()
        {
            this.ButtonCommand = new RelayCommand(o => OpenFileDialog());
            this.MouseLeftClickCommand = new RelayCommand(o => LableLeftClick(o));
            this.LostFocusCommand = new RelayCommand(o => IsValidEmail(o));
            this.ErrorMessage = "*(should be limit 3Mb)";
        }

        public ICommand MouseLeftClickCommand
        {
            get { return _LabelLeftClick; }
            set { _LabelLeftClick = value; }
        }

        public ObservableCollection<AttachmentDetails> AttactmentList
        {
            get { return _AttactmentList; }
            set
            {
                _AttactmentList = value;
                OnPropertyChanged("AttactmentList");
            }
        }

        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set
            {
                if (_ErrorMessage != value)
                {
                    _ErrorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }

        public ICommand LostFocusCommand
        {
            get
            {
                return _LostFocusCommand;
            }
            set
            {
                _LostFocusCommand = value;
            }
        }

        public ICommand ButtonCommand
        {
            get
            {
                return _ButtonCommand;
            }
            set
            {
                _ButtonCommand = value;
            }
        }

        private void IsValidEmail(object parameter)
        {
            try
            {
                if (parameter != null)
                {
                    string email = parameter as string;
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        var addr = new System.Net.Mail.MailAddress(email);
                    }
                    else
                    {
                    }
                }
            }
            catch (FormatException ex)
            {
            }
        }

        public void LableLeftClick(object parameter)
        {
            string filename = parameter.ToString();
            AttachmentDetails attachmentFile = this.AttactmentList.Where(o => o.FileName == filename).FirstOrDefault();
            this.AttactmentList.Remove(attachmentFile);
            fileSize -= attachmentFile.fileSizeInBytes;
        }

        public void OpenFileDialog()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Title = "Browse Attachemnt Files";
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
            openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(openFileDialog1_FileOk);
            openFileDialog.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string[] files = openFileDialog.FileNames;
            FileInfo fileInfo = null;
            long localFilesize = 0;
            foreach (string file in files)
            {
                fileInfo = new FileInfo(file);
                localFilesize += fileInfo.Length;
            }
            fileSize += localFilesize;
            if (fileSize <= 2500000)
            {
                localFilesize = 0;
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    this.AttactmentList.Add(new AttachmentDetails() { FileName = fi.Name, FileSize = SizeSuffix(fi.Length), FileDirectory = fi.Directory, fileSizeInBytes = fi.Length });
                }
                this.ErrorMessage = "*(should be limit 3Mb)";
            }
            else
            {
                fileSize -= localFilesize;
                this.ErrorMessage = "File Size is too Large.";
            }
        }

        public string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}", dValue, SizeSuffixes[i]);
        }

        public void OnPropertyChanged(string PropertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}