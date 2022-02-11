using SimpleMvvmDemo.ViewModels;

namespace SimpleMvvmDemo;

public partial class SecondPage : ContentPage
{
	public SecondPage(SecondPageViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}

