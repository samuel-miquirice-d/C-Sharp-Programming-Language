// Alteração realizada por Samuel António Miquirice Domingos
namespace teste;
var stock = new Stock("MSFT");
stock.PriceChanged += ReportPriceChange;    // Define a função que será executada quando o evento ocorrer
stock.Price = 123;                          // Price changed from 0 to 123
stock.Price = 456;                          // Price changed from 123 to 456  

void ReportPriceChange(decimal oldPrice, decimal newPrice)
{
  Console.WriteLine("Price changed from " + oldPrice + " to " + newPrice);
}



public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

public class Stock
{
  string symbol;
  decimal price;

  public Stock(string symbol) { this.symbol = symbol; }
  
  public event PriceChangedHandler PriceChanged;        // Variável de evento
  
  public decimal Price
  {
    get { return price; }
    set
    {  // Outra alteração realizada por Samuel António Miquirice Domingos
      if (price == value) return;      
      decimal oldPrice = price;
      price = value;
      if (PriceChanged != null)         
        PriceChanged(oldPrice, price);   // Dispara o evento
    }
  }
}
