using Avalonia;
using Avalonia.Controls;


namespace Forms;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void Submit_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string name = nameBox.Text ?? "";
        string salary = salaryBox.Text ?? "";
        string id = employeeIdBox.Text ?? "";

        var dialog = new Window
        {
            Title = "Data",
            Width = 250,
            Height = 150,
            Content = new TextBlock
            {
                Text = $"Name: {name}\nSalary: {salary}",
                Margin = new Thickness(20)
            }
        };

        await dialog.ShowDialog(this);
    }

    private void btnDDeSerialize_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Employee emp1 = new Employee();
        txtEmployee.
}
}
