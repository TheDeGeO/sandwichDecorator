using Avalonia.Controls;
using Avalonia.Interactivity;

namespace SubgueiApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnCalculateClick(object sender, RoutedEventArgs e)
    {
        ISubwayComponent subway = new BasicSubway();

        if (this.FindControl<CheckBox>("CheeseCheckBox").IsChecked == true)
        {
            subway = new CheeseDecorator(subway);
        }

        if (this.FindControl<CheckBox>("TomatoCheckBox").IsChecked == true)
        {
            subway = new TomatoDecorator(subway);
        }

        var resultText = this.FindControl<TextBlock>("ResultText");
        resultText.Text = $"{subway.GetDescription()}\nTotal Cost: ${subway.GetCost():F2}";
    }
}