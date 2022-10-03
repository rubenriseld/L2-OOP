internal abstract class KitchenApplianceAbstract : IKitchenAppliance
{
    public string type { get; set; }
    public string brand { get; set; }
    public bool isFunctioning { get; set; }
    public KitchenApplianceAbstract(string type, string brand, bool isFunctioning)
    {
        this.type = type;
        this.brand = brand;
        this.isFunctioning = isFunctioning;
    }
    public void Use()
    {
        if (this.isFunctioning == true) Console.WriteLine($"Använder {this.type}...");
        else Console.WriteLine($"{this.type} är trasig!");

    }
    public string CheckFunctioning()
    {
        if (this.isFunctioning == true) return "Ja";
        else return "Nej";
    }
}
