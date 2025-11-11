using BlogSharp2025.ApiClient;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;

namespace BlogSharp2025.WinFormsApp;

public partial class Form1 : Form
{
    #region Variables and constructor
    IAuthorDao _authorApiClient = new AuthorApiClient("https://localhost:7249");
    public Form1() => InitializeComponent();

    #endregion

    #region Events
    private void Form1_Load(object sender, EventArgs e) => LoadAuthors();
    private void LstAuthors_SelectedIndexChanged(object sender, EventArgs e) => UpdateUi();
    private void BtnDelete_Click(object sender, EventArgs e) => DeleteSelectedAuthor();

    #endregion

    #region Functionality
    private void LoadAuthors()
    {
        lstAuthors.Items.Clear();
        foreach (var author in _authorApiClient.GetAll())
        {
            lstAuthors.Items.Add(author);
        }
        UpdateUi();
    }
    private void UpdateUi()
    {
        btnDelete.Enabled = lstAuthors.SelectedIndex != -1;
    }


    private void DeleteSelectedAuthor()
    {
        if (lstAuthors.SelectedIndex == -1)
        {
            return;
        }
        if (MessageBox.Show("Do you want to delete ?", "Delete?", MessageBoxButtons.OKCancel) != DialogResult.OK)
        {
            return;
        }

        var selectedIndex = lstAuthors.SelectedIndex;
        var selectedAuthor = (Author)lstAuthors.SelectedItem;
        _authorApiClient.Delete(selectedAuthor.Id);

        lstAuthors.Items.Remove(selectedAuthor);

        //in case the deleted item was last in the list
        //move selected index up
        int maxIndex = lstAuthors.Items.Count - 1;
        if (selectedIndex > maxIndex)
        {
            selectedIndex = maxIndex;
        }
        lstAuthors.SelectedIndex = selectedIndex;

    } 
    #endregion
}
