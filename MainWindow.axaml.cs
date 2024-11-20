using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections.Generic;
using System.Linq;

namespace SubgueiApp;

public partial class MainWindow : Window
{
    private List<ISubwayComponent> _order = new();
    private decimal _total = 0;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void OnAddToOrderClick(object sender, RoutedEventArgs e)
    {
        var selectedType = (this.FindControl<ComboBox>("SandwichType").SelectedItem as ComboBoxItem)?.Content.ToString();
        var size = this.FindControl<RadioButton>("Size15").IsChecked == true ? 15 : 30;

        var sandwich = CreateBaseSandwich(selectedType, size);
        
        if (sandwich != null)
        {
            if (this.FindControl<CheckBox>("Avocado").IsChecked == true)
                sandwich = new AvocadoDecorator(sandwich);
            
            if (this.FindControl<CheckBox>("ExtraProtein").IsChecked == true)
                sandwich = new ExtraProteinDecorator(sandwich);
            
            if (this.FindControl<CheckBox>("Mushrooms").IsChecked == true)
                sandwich = new MushroomDecorator(sandwich);
            
            if (this.FindControl<CheckBox>("Drink").IsChecked == true)
                sandwich = new DrinkDecorator(sandwich);
            
            if (this.FindControl<CheckBox>("Soup").IsChecked == true)
                sandwich = new SoupDecorator(sandwich);
            
            if (this.FindControl<CheckBox>("Dessert").IsChecked == true)
                sandwich = new DessertDecorator(sandwich);

            _order.Add(sandwich);
            UpdateOrderDisplay();
        }
    }

    private ISubwayComponent CreateBaseSandwich(string type, int size)
    {
        return type switch
        {
            "Pavo" => new BasicSubway("Pavo", 12, 18, size),
            "Italiano" => new BasicSubway("Italiano", 9, 16, size),
            "Beef" => new BasicSubway("Beef", 10, 16, size),
            "Veggie" => new BasicSubway("Veggie", 8, 14, size),
            "Atún" => new BasicSubway("Atún", 11, 17, size),
            "Pollo" => new BasicSubway("Pollo", 12, 18, size),
            _ => null
        };
    }

    private void UpdateOrderDisplay()
    {
        var resultText = "Orden actual:\n\n";
        _total = 0;

        foreach (var item in _order)
        {
            _total += item.GetCost();
            resultText += $"{item.GetDescription()} - ${item.GetCost():F2}\n";
        }

        resultText += $"\nTotal: ${_total:F2}";
        
        var orderDetails = this.FindControl<TextBlock>("OrderDetails");
        orderDetails.Text = resultText;
    }

    private void OnFinishOrderClick(object sender, RoutedEventArgs e)
    {
        if (_order.Any())
        {
            var message = $"Orden finalizada. Total a pagar: ${_total:F2}";
            _order.Clear();
            _total = 0;
            UpdateOrderDisplay();
            // Aquí podrías mostrar un diálogo de confirmación
        }
    }
}