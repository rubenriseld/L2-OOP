internal class KitchenAppliance
{
    internal string type { get; set; }
    internal string brand { get; set; }
    internal bool isFunctioning { get; set; }
    internal KitchenAppliance(string type, string brand, bool isFunctioning)
    {
        this.type = type;
        this.brand = brand;
        this.isFunctioning = isFunctioning;
    }
    //metod för att returnera output vid användning av apparat
    internal void Use()
    {
        if (this.isFunctioning == true) Console.WriteLine($"\nAnvänder {this.type}...\n");
        else Console.WriteLine($"\n{this.type} är trasig!\n");

    }
    //metod för att returnera värde till den detaljerade infolistan
    internal string CheckFunctioning()
    {
        if (this.isFunctioning == true) return "Ja";
        else return "Nej";
    }
}
