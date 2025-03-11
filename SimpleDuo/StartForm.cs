using Microsoft.VisualBasic.Logging;

namespace DatabaseViewForm;

public partial class StartForm : Form
{
    private LoginView loginView;
    private NavigationView navigationView;
    private UserView userView;

    private UserControl _currentView;
    
    public enum ViewType
    {
        Login,
        Navigation,
        User
    }
    
    public StartForm()
    {
        InitializeComponent();
        loginView = new LoginView(this);
        navigationView = new NavigationView(this);
        userView = new UserView(this);
        SelectView(ViewType.Login);
    }

    public void RenderCurrentView()
    {
        this.Controls.Clear();
        this.Controls.Add(_currentView);
    }

    public void SelectView(ViewType viewType)
    {
        _currentView = viewType switch
        {
            ViewType.Login => loginView,
            ViewType.Navigation => navigationView,
            ViewType.User => userView,
        };
        RenderCurrentView();
    }
}