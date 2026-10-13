using AlisaPROJECT.Services;

namespace AlisaPROJECT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DataRepository.CreateFakeData();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}