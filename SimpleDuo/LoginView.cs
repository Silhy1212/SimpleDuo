using SimpleDuo;

namespace DatabaseViewForm;

public partial class LoginView : UserControl
{
    private readonly StartForm _parentForm;
    private DBDriver? _dbDriver;
    public LoginView(StartForm parentForm)
    {
        _parentForm = parentForm;
        InitializeComponent();
    }
    private void Login()
    {
        
        if (_dbDriver is null || !_dbDriver.TryConnection())
        {
            _dbDriver = new DBDriver(LoginTextBox.Text);
        }


        if (_dbDriver.TryConnection())
        {
            _parentForm.SelectView(StartForm.ViewType.Navigation);
        }
        else{
            Console.WriteLine();
        }

        
         
        LoginTextBox.Text = "";
    }
    private void LoginTextBox_Enter(object sender, EventArgs e)
    {
        LoginTextBox.Text = "";

        LoginTextBox.ForeColor = Color.Black;

        LoginTextBox.UseSystemPasswordChar = true;
    }

    private void LoginTextBox_Leave(object sender, EventArgs e)
    {
        if (LoginTextBox.Text.Length == 0)
        {
            LoginTextBox.ForeColor = Color.Gray;

            LoginTextBox.Text = "Enter password";

            LoginTextBox.UseSystemPasswordChar = false;

            SelectNextControl(LoginTextBox, true, true, false, true);
        }
    }

    private void LoginButton_Click(object sender, EventArgs e)
    {
        Login();
        
    }
}