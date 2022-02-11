namespace SimpleMvvmDemo.Contracts.Services
{
    public interface INavigationService
    {
        Task NavigateToSecondPage(string id);
        Task NavigateToThirdPage();
        Task NavigateBack();
        Task NavigateToMainPage();
    }
}
