internal interface IKitchenAppliance
{
    string type { get; set; }
    string brand { get; set; }
    bool isFunctioning { get; set; }
    void Use();
}