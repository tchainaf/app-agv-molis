using app_agv_molis.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace app_agv_molis.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgvPage : ContentPage
    {
        AgvViewModel _viewModel;
        public AgvPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new AgvViewModel();
            MessagingCenter.Subscribe<AgvPage, string>(this, "ErroAoBuscar", async (sender, args) =>
            {
                await DisplayAlert("Deu ruim", "Erro ao buscar os agvs\n" + args, "OK");
            });
            MessagingCenter.Subscribe<AgvPage>(this, "ErroAoBuscarHelixIds", async (sender) =>
            {
                await DisplayAlert("Deu ruim", "Erro ao buscar os ids do Helix", "OK");
            });
            MessagingCenter.Subscribe<AgvPage>(this, "SucessoAoCriar", async (sender) =>
            {
                await DisplayAlert("Uhuuul", "Agv criado com sucesso!", "OK");
            });
            MessagingCenter.Subscribe<AgvPage, string>(this, "ErroAoCriar", async (sender, args) =>
            {
                await DisplayAlert("Deu ruim", "Erro ao criar o agv\n" + args, "OK");
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
            await _viewModel.ShouldSeeAdminTasks();
            await _viewModel.ExecuteLoadAgvsCommand();
            AgvView.ItemsSource = _viewModel.AgvsList;
        }
    }
}