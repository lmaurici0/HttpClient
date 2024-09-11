using AppPostService.ViewModels;

namespace AppPostService.Views;

public partial class TodosView : ContentPage
{
	public TodosView()
	{
		InitializeComponent();
        BindingContext = new TodosViewModel();

    }
}