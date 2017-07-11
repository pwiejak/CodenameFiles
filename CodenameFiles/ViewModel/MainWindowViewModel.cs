using CodenameFiles.Commands;
using CodenameFiles.Notifiers;
using System.Windows.Input;

namespace CodenameFiles.ViewModel
{
    public class MainWindowViewModel
    {
        private ICommand _browsePathDialogCommand;
        private MainWindowNotifier _notifier;

        public MainWindowViewModel()
        {
            _notifier = new MainWindowNotifier();
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

        private void BrowsePathDialog()
        {
            string path;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if(result == System.Windows.Forms.DialogResult.OK)
                {
                    path = dialog.SelectedPath;
                    _notifier.RenameFileFolderPath = path;
                }
            }
        }

        public MainWindowNotifier MainWindowNotifier
        {
            get
            {
                return _notifier;
            }
            set
            {
                _notifier = value;
            }
        }
    }
}
