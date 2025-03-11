using SimpleDuo;

 namespace DatabaseViewForm;

public partial class UserView : UserControl
{
    private readonly StartForm _parentForm;
    private DBDriver? _dbDriver;

    public UserView(StartForm parentForm)
    {
        _parentForm = parentForm;
        InitializeComponent();
    }
    

    

    private void PopulateListView(List<User> users)
    {
        UserListView.Items.Clear();
        foreach (var user in users)
        {
            ListViewItem item = new ListViewItem();
            item.Text = user.Id.ToString();
            item.SubItems.Add(user.Username);
            item.SubItems.Add(user.CreatedAt.ToString());
            item.SubItems.Add(user.ModifiedAt.ToString());
            UserListView.Items.Add(item);
        }
    }

    private void Login()
    {
        ErrorLabel.Text = "";
        if (_dbDriver is null)
        {
            _dbDriver = new DBDriver(PasswordTextBox.Text);
        }
        PasswordTextBox.Text = "";
    }

    private void LoadUsers()
    {
        List<User> users = _dbDriver.GetUsers();
        if (_dbDriver.ThrownException is not null)
        {
            ErrorLabel.Text = _dbDriver.ThrownException.Message;
            _dbDriver.ThrownException = null;
            _dbDriver = null;
        }
        else
        {
            PopulateListView(users);
        }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {
        Login();

        LoadUsers();
    }

    private void PasswordTextBox_KeyPressed(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int)Keys.Enter)
        {
            Login();
            LoadUsers();
        }
    }

    private void CreateNewUser(string username)
    {
        if (_dbDriver is null) return;

        User newUser = new User()
        {
            Username = username,
        };
        _dbDriver.InsertUser(newUser);
        LoadUsers();
    }

    private void ButtonNewUser_Click(object sender, EventArgs e)
    {
        if (TextBoxNewUser.Text == "") return;
        
        CreateNewUser(TextBoxNewUser.Text);
        TextBoxNewUser.Text = "";
    }

    private void TextBoxNewUser_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (TextBoxNewUser.Text == "") return;
            
            CreateNewUser(TextBoxNewUser.Text);
            TextBoxNewUser.Text = "";
        }
    }

    private void DeleteUserWithId(string stringId)
    {
        if (_dbDriver is null) return;

        ErrorLabel.Text = "";
        int id;
        if (int.TryParse(stringId, out id) is false)
        {
            ErrorLabel.Text = "Please enter a valid ID";
            return;
        }
        _dbDriver.DeteteUserWithId(id);
        if (_dbDriver?.ThrownException is not null)
        {
            ErrorLabel.Text = _dbDriver.ThrownException.Message;
            _dbDriver.ThrownException = null;
            return;
        }
        LoadUsers();
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        string userId = TextBoxDeleteUser.Text;
        DeleteUserWithId(userId);
        TextBoxDeleteUser.Text = "";
       
    }

    private void TextBoxDeleteUser_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            DeleteUserWithId(TextBoxDeleteUser.Text);
            TextBoxDeleteUser.Text = "";
        }
    }

    private void UserListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        Console.WriteLine($"{e.Item.Text}: {e.Item.SubItems[1].Text}: {e.Item.SubItems[2].Text}");
    }
}