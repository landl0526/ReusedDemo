using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReusedResourcesDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChildPage : MainPage
	{
		public ChildPage ()
		{
			InitializeComponent ();

            List<Model> list = new List<Model>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new Model { Name = "Name" + i });
            }
            MyListView.ItemsSource = list;

            BindingContext = new PageModel();
        }
    }

    public class Model
    {
        public string Name { set; get; }
        public ICommand MyCommand { set; get; }

        public Model()
        {
            MyCommand = new Command((model) =>
            {
                Console.WriteLine(model);
            });
        }
    }

    public class PageModel
    {
        public ICommand OnDeleteClick { set; get; }

        public PageModel()
        {
            OnDeleteClick = new Command<Model>((model) =>
            {
                Console.WriteLine(model.Name);
            });
        }
    }
}