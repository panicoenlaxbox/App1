using App1.ViewModels;
using Xamarin.Forms;

namespace App1.Views
{
    public partial class CustomersView : ContentPage
    {
        public CustomersView()
        {
            InitializeComponent();
            BindingContext = new CustomersViewModel();
        }

        //private void SearchView_OnSearchButtonPressed(object sender, EventArgs e)
        //{
        //    Debug.WriteLine("SearchView_OnSearchButtonPressed");
        //    ((CustomersViewModel)BindingContext).SearchCommand.Execute(((SearchBar)sender).Text);
        //}

        private void SearchView_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var customersViewModel = ((CustomersViewModel)BindingContext);
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                customersViewModel.RestoreData();
            } else 
            {
                customersViewModel.SearchCommand.Execute(((SearchBar)sender).Text);
            }
        }
    }
}
