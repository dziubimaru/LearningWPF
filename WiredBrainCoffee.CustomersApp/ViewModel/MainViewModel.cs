using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiredBrainCoffee.CustomersApp.Command;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;
        
        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)	
        {
            CustomersViewModel = customersViewModel;
            ProductsViewModel = productsViewModel;
            SelectedViewModel = customersViewModel;
            SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public DelegateCommand SelectViewModelCommand { get; }
        public ViewModelBase? SelectedViewModel
		{
			get => _selectedViewModel;
			set 
			{ 
				_selectedViewModel = value;
				RaisePropertyChanges();
			}
		}
        public CustomersViewModel CustomersViewModel { get; }
        public ProductsViewModel ProductsViewModel { get; }
        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null) 
            {
                await SelectedViewModel.LoadAsync();
            }
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
