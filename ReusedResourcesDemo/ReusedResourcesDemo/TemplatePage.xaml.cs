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
	public partial class TemplatePage : ContentPage
	{
		public TemplatePage ()
		{
			InitializeComponent ();

            List<TemplatePageModel> list = new List<TemplatePageModel>();
            for (int i = 0; i < 100; i++)
            {
                list.Add(new TemplatePageModel { Name = "Name" + i });
            }
            MyListView.ItemsSource = list;
        }
	}

    public class TemplatePageModel
    {
        public string Name { set; get; }
        public ICommand OnDeleteClick { set; get; }

        public TemplatePageModel()
        {
            OnDeleteClick = new Command<TemplatePageModel>((model) =>
            {
                Console.WriteLine(model.Name);
            });
        }
    }
}