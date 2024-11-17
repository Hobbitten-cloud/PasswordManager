using PasswordManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ManagerRepo managerRepo = new ManagerRepo();

        public ObservableCollection<ManagerViewModel> managerVM { get; set; } = new ObservableCollection<ManagerViewModel>();


        public MainViewModel()
        {
            foreach (Manager manager in managerRepo.GetAll())
            {
                ManagerViewModel currentManagerVM = new ManagerViewModel(manager);
                managerVM.Add(currentManagerVM);
            }
        }

        private ManagerViewModel selectedManager;
        public ManagerViewModel SelectedManager
        {
            get
            {
                return selectedManager;
            }
            set
            {
                selectedManager = value; OnPropertyChanged("SelectedManager");

                // Another method to achieve the same result as above
                //selectedManager = value; OnPropertyChanged(nameof(SelectedManager));
            }
        }

        public void AddDefaultManager()
        {
            Manager manager = managerRepo.Add("Specify Name", "Specify Username", "Specify Password");
            ManagerViewModel managerViewModel = new ManagerViewModel(manager);
            managerVM.Add(managerViewModel);
            SelectedManager = managerViewModel;
        }

        public void DeleteSelectedManager()
        {
            if (SelectedManager != null)
            {
                SelectedManager.DeleteManager(managerRepo);
                managerVM.Remove(SelectedManager);
                SelectedManager = managerVM.LastOrDefault();
            }
        }

        public void SaveAllManagers()
        {
            if (SelectedManager != null)
            {
                // Save the updated manager to the file
                // Manager manager = managerRepo.SaveTxTFile();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
