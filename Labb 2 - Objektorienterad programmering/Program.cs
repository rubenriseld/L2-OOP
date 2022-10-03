bool isRunning = true;

List<KitchenAppliance> KitchenApplianceList = new List<KitchenAppliance>();
KitchenApplianceList.Add(new KitchenAppliance("Kylskåp", "Electrolux", true));
KitchenApplianceList.Add(new KitchenAppliance("Brödrost", "SMEG", true));
KitchenApplianceList.Add(new KitchenAppliance("Ugn", "Electrolux", true));

while (isRunning == true)
{
    DisplayMenu();
    int inputNumber;

    if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
    {
        switch (inputNumber)
        {
            case 1:
                UseAppliance();
                break;
            case 2:
                AddAppliance();
                break;
            case 3:
                DisplayInfoList();
                break;
            case 4:
                RemoveAppliance();
                break;
            case 5:
                //avsluta programmet
                isRunning = false;
                break;
            default:
                break;
        }
    }
    else Console.WriteLine("Endast siffror!");
}


//HUVUDMENY
void DisplayMenu()
{
    Console.WriteLine(
        "======KÖKET======\n" +
        "1. Använd köksapparat\n" +
        "2. Lägg till kökapparat\n" +
        "3. Lista köksapparater\n" +
        "4. Ta bort köksapparat\n" +
        "5. Avsluta");
    Console.Write(">");
}
//detaljerad lista över alla apparater
void DisplayInfoList()
{
    foreach (var appliance in KitchenApplianceList)
    {
        Console.WriteLine($"Typ: {appliance.type}\n" +
            $"Märke: {appliance.brand}\n" +
            $"Fungerar: {appliance.CheckFunctioning()}\n" +
            $"-----");
    }
}
//visa numrerad lista över apparater för användning och borttagning
void DisplayChoiceList()
{
    for (int i = 0; i < KitchenApplianceList.Count(); i++)
    {
        Console.WriteLine($"{i + 1}. {KitchenApplianceList[i].type}");
    }
    Console.Write(">");
}
//använd en apparat
void UseAppliance()
{
    bool inputRunCondition = true;
    int inputNumber;

    while (inputRunCondition == true)
    {
        DisplayChoiceList();
        if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
        {
            //felhantering i de fall då inmatad siffra inte står med på listan
            try
            {
                KitchenApplianceList[inputNumber - 1].Use();
                inputRunCondition = false;
            }
            catch
            {
                Console.WriteLine("Ange en siffra som är listad!");

            }

        }
        else
        {
            Console.WriteLine("Välj apparat från listan med en siffra!");
        }
    }

}
//metod för att lägga till apparat
void AddAppliance()
{
    bool inputRunCondition = true;
    bool isWorking;

    Console.Write("Ange typ:\n>");
    string typeInput = Console.ReadLine();
    Console.Write("Ange märke:\n>");
    string brandInput = Console.ReadLine();
    while (inputRunCondition == true)
    {
        Console.Write("Ange om apparaten fungerar (j/n):\n>");
        string isFunctioningInput = Console.ReadLine().ToLower();
        if (isFunctioningInput == "j" || isFunctioningInput == "n")
        {
            if (isFunctioningInput == "j") isWorking = true;
            else isWorking = false;
            KitchenApplianceList.Add(new KitchenAppliance(typeInput, brandInput, isWorking));
            Console.WriteLine("Tillagd!");
            inputRunCondition = false;
        }
        else
        {
            Console.WriteLine("Felaktig inmatning, ange svar med bokstav 'j' eller 'n'!");
        }
    }
}
void RemoveAppliance()
{
    bool inputRunCondition = true;
    int inputNumber;

    while (inputRunCondition == true)
    {
        DisplayChoiceList();
        if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
        {
            //felhantering i de fall då inmatad siffra inte står med på listan
            try
            {
                KitchenApplianceList.RemoveAt(inputNumber - 1);
                inputRunCondition = false;
            }
            catch
            {
                Console.WriteLine("Ange en siffra som är listad!");

            }
        }
        else
        {
            Console.WriteLine("Välj apparat från listan med en siffra!");
        }
    }
}