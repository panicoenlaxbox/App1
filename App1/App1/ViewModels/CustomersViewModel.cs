using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using App1.Models;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class CustomersViewModel : BindableObject
    {
        public ObservableCollection<Customer> Data { get; set; }

        public ICommand SearchCommand => new Command(o =>
        {
            var text = o as string;
            if (!string.IsNullOrWhiteSpace(text) && text.Length >= 3)
            {
                FilterData(text);
            }
        });

        public CustomersViewModel()
        {
            //Data = new ObservableCollection<Customer>()
            //{
            //    new Customer("Sergio", 40),
            //    new Customer("Miguel", 39),
            //    new Customer("Alicia", 33)
            //};
            Data = GetData();
        }


        private void FilterData(string name)
        {
            name = name.Trim().ToUpper();
            var items = Data.Where(c => !c.Name.ToUpper().Contains(name)).ToList();
            foreach (var item in items)
            {
                Data.Remove(item);
            }
        }

        public void RestoreData()
        {
            var items = Data.ToList();
            foreach (var item in items)
            {
                Data.Remove(item);
            }
            items = GetItems();
            foreach (var item in items)
            {
                Data.Add(item);
            }
        }

        private List<Customer> GetItems()
        {
            return new List<Customer>()
            {
                new Customer("Sergio", 40),
                new Customer("Miguel", 39),
                new Customer("Alicia", 33)
            };
        }

        private ObservableCollection<Customer> GetData()
        {
            return new ObservableCollection<Customer>(GetItems());
        }
    }
}