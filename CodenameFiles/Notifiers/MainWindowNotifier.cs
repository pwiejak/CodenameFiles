using System.ComponentModel;

namespace CodenameFiles.Notifiers
{
    public class MainWindowNotifier : INotifyPropertyChanged
    {
        //public  MainWindowNotifier(PropertyChangedEventHandler propertyChanged)
        //{
        //    PropertyChanged = propertyChanged;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        private string _renameFileFolderPath;

        public string RenameFileFolderPath
        { 
            get
            { return _renameFileFolderPath; }
            set
            {
                _renameFileFolderPath = value;
                OnPropertyChanged("RenameFileFolderPath");
            }
        }

        private void OnPropertyChanged(string p)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(p));
        }
    }
}
