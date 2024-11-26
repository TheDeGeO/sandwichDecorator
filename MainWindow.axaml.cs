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
            {
                var count = (int)this.FindControl<NumericUpDown>("AvocadoCount").Value;
                var decorator = new AvocadoDecorator(sandwich);
                for (int i = 1; i < count; i++)
                    decorator.IncrementCount();
                sandwich = decorator;
            }
            
            if (this.FindControl<CheckBox>("ExtraProtein").IsChecked == true)
            {
                var count = (int)this.FindControl<NumericUpDown>("ExtraProteinCount").Value;
                var decorator = new ExtraProteinDecorator(sandwich);
                for (int i = 1; i < count; i++)
                    decorator.IncrementCount();
                sandwich = decorator;
            }
            
            if (this.FindControl<CheckBox>("Mushrooms").IsChecked == true)
            {
                var count = (int)this.FindControl<NumericUpDown>("MushroomsCount").Value;
                var decorator = new MushroomDecorator(sandwich);
                for (int i = 1; i < count; i++)
                    decorator.IncrementCount();
                sandwich = decorator;
            }
            
            if (this.FindControl<CheckBox>("Drink").IsChecked == true)
            {
                var count = (int)this.FindControl<NumericUpDown>("DrinkCount").Value;
                var decorator = new DrinkDecorator(sandwich);
                for (int i = 1; i < count; i++)
                    decorator.IncrementCount();
                sandwich = decorator;
            }
            
            if (this.FindControl<CheckBox>("Soup").IsChecked == true)
            {
                var count = (int)this.FindControl<NumericUpDown>("SoupCount").Value;
                var decorator = new SoupDecorator(sandwich);
                for (int i = 1; i < count; i++)
                    decorator.IncrementCount();
                sandwich = decorator;
            }
            
            if (this.FindControl<CheckBox>("Dessert").IsChecked == true)
            {
                var count = (int)this.FindControl<NumericUpDown>("DessertCount").Value;
                var decorator = new DessertDecorator(sandwich);
                for (int i = 1; i < count; i++)
                    decorator.IncrementCount();
                sandwich = decorator;
            }

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