using Microsoft.VisualBasic.Logging;

namespace DatabaseViewForm;

public partial class StartForm : Form
{
    private LoginView loginView;
    private NavigationView navigationView;
    private UserView userView;
    private LanguageView languageView;
    public string Password;
    private UserControl _currentView;

    public enum ViewType
    {
        Login,
        Navigation,
        User,
        Language
    }

    public StartForm()
    {
        InitializeComponent();
        loginView = new LoginView(this);
        navigationView = new NavigationView(this);
        languageView = new LanguageView(this);

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
            ViewType.Language => languageView,

        };
        RenderCurrentView();
    }
}