using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WiredBrainCoffee.CustomersApp.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        //Here`s an easier way how to raise an event
        protected virtual void RaisePropertyChanges([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task LoadAsync() => Task.CompletedTask;
    }
}
