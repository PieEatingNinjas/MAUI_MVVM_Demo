using SimpleMvvmDemo.ViewModels;

namespace SimpleMvvmDemo;

public partial class ThirdPage : ContentPage
{
	public ThirdPage(ThirdPageViewModel viewModel)
	{
		BindingContext = viewModel;
		InitializeComponent();
	}
}

