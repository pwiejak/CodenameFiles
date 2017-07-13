using CodenameFiles.Commands;
using CodenameFiles.Notifiers;
using System.ComponentModel;
using System.Windows.Input;
using System;

namespace CodenameFiles.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ICommand _browsePathDialogCommand;
        private ICommand _renameByDateCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
        }

        public ICommand BrowsePathDialogCommand
        {
            get
            {
                if (_browsePathDialogCommand == null)
                {
                    _browsePathDialogCommand = new RelayCommand(param => this.BrowsePathDialog(), param => true);
                }

                return _browsePathDialogCommand;
            }
        }

        public ICommand RenameByDateCommand
        {
            get
            {
                if(_renameByDateCommand == null)
                {
                    _renameByDateCommand = new RelayCommand(c => this.RenameByDate(), p => CanExecuteRenameByDateCommand());
                }

                return _renameByDateCommand;
            }
            set
            {

            }
        }

        private void RenameByDate()
        {
            var test = 1;
        }

        private bool CanExecuteRenameByDateCommand()
        {
            return !string.IsNullOrEmpty(_renameFileFolderPath);
        }

        private void BrowsePathDialog()
        {
            string path;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    //_notifier.RenameFileFolderPath = path;
                    RenameFileFolderPath = $"Path: {path}";
                }
            }
        }

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
