using SimpleDuo;

 namespace DatabaseViewForm;

public partial class LanguageView : UserControl
{
    private readonly StartForm _parentForm;
    private DBDriver? _dbDriver;

    public LanguageView(StartForm parentForm)
    {
        _parentForm = parentForm;
        InitializeComponent();
    }
    

    

    private void PopulateListView(List<Language> languages)
    {
        UserListView.Items.Clear();
        foreach (var language in languages)
        {
            ListViewItem item = new ListViewItem();
            item.Text = language.Id.ToString();
            item.SubItems.Add(language.Name);
            item.SubItems.Add(language.CreatedAt.ToString());
            item.SubItems.Add(language.ModifiedAt.ToString());
            UserListView.Items.Add(item);
        }
    }

    private void Login()
    {
        
            _dbDriver = new DBDriver(_parentForm.Password);
       
    }

    private void LoadLanguages()
    {
        List<Language> languages = _dbDriver.GetLanguages();
        if (_dbDriver.ThrownException is not null)
        {
            ErrorLabel.Text = _dbDriver.ThrownException.Message;
            _dbDriver.ThrownException = null;
            _dbDriver = null;
        }
        else
        {
            PopulateListView(languages);
        }
    }

    private void FetchButton_Click(object sender, EventArgs e)
    {

        Login();
        LoadLanguages();
    }

    private void PasswordTextBox_KeyPressed(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (int)Keys.Enter)
        {
            Login();
            LoadLanguages();
        }
    }

    private void CreateNewLanguage(string username)
    {
        if (_dbDriver is null) return;

        Language newLanguage = new Language()
        {
            Name = username,
        };
        _dbDriver.InsertLanguage(newLanguage);
        LoadLanguages();
    }

    private void ButtonNewUser_Click(object sender, EventArgs e)
    {
        if (TextBoxNewUser.Text == "") return;
        
        CreateNewLanguage(TextBoxNewUser.Text);
        TextBoxNewUser.Text = "";
    }

    private void TextBoxNewUser_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (TextBoxNewUser.Text == "") return;
            
            CreateNewLanguage(TextBoxNewUser.Text);
            TextBoxNewUser.Text = "";
        }
    }

    private void DeleteLanguageWithId(string stringId)
    {
        if (_dbDriver is null) return;

        ErrorLabel.Text = "";
        int id;
        if (int.TryParse(stringId, out id) is false)
        {
            ErrorLabel.Text = "Please enter a valid ID";
            return;
        }
        _dbDriver.DeteteLanguageWithId(id);
        if (_dbDriver?.ThrownException is not null)
        {
            ErrorLabel.Text = _dbDriver.ThrownException.Message;
            _dbDriver.ThrownException = null;
            return;
        }
        LoadLanguages();
    }

    private void ButtonDelete_Click(object sender, EventArgs e)
    {
        string userId = TextBoxDeleteUser.Text;
        DeleteLanguageWithId(userId);
        TextBoxDeleteUser.Text = "";
       
    }

    private void TextBoxDeleteUser_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            DeleteLanguageWithId(TextBoxDeleteUser.Text);
            TextBoxDeleteUser.Text = "";
        }
    }

    private void UserListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        Console.WriteLine($"{e.Item.Text}: {e.Item.SubItems[1].Text}: {e.Item.SubItems[2].Text}");
    }

    private void button2_Click(object sender, EventArgs e)
    {
        _parentForm.SelectView(StartForm.ViewType.Navigation);
    }
}