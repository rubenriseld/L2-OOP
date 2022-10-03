bool isRunning = true;

List<KitchenAppliance> KitchenApplianceList = new List<KitchenAppliance>();
KitchenApplianceList.Add(new KitchenAppliance("Kylskåp", "Electrolux", true));
KitchenApplianceList.Add(new KitchenAppliance("Brödrost", "SMEG", true));
KitchenApplianceList.Add(new KitchenAppliance("Ugn", "Electrolux", true));

while (isRunning == true)
{
    DisplayMenu();
    int inputMenuNumber;

    if (int.TryParse(Console.ReadLine(), out inputMenuNumber) == true)
    {
        switch (inputMenuNumber)
        {
            case 1:
                /*val1:
                skriv ut undermeny av apparater att välja
                skriv ut meddelande om apparaten är trasig om trasig
                annars skriv ut att den används
                gå tillbaka till huvudmeny*/
                DisplayChoiceList();
                
                if (int.TryParse(Console.ReadLine(), out inputMenuNumber) == true)
                {
                    KitchenApplianceList[inputMenuNumber - 1].Use();
                }
                else
                {
                    Console.WriteLine("Välj apparat från listan med en siffra!");
                    DisplayChoiceList();
                }
                break;
            case 2:
                /*val2:
                lägg till köksapparat
                låter användaren mata in typ, märke och skick,
                (tex "våffeljärn", "electrolux", "j" -> om litet j betyder det att den funkar
                annars litet n -> trasig
                lagrar apparaterna i en lista och skriver ut meddelande om att apparaten lagts till
                gå tillbaka till huvudmeny*/
                AddAppliance();
                break;
            case 3:
                /*val 3:
                 lista köksapparater, inklusive alla som lagts till
                ska inkludera typ, märke och skick
                gå tillbaka till huvudmeny*/
                DisplayInfoList();
                break;
            case 4:
                /*val 4:
                 ta bort köksapparat
                skriv ut en numrerad lista över alla köksapparater
                låter användaren ange vilken köksapparat som ska tas bort och läser in valet
                tar bort köksapparaten från listan över lagrade köksapparater och 
                skriver ut ett meddelande om att köksapparaten har tagits bort
                gå tillbaka till huvudemnyn*/
                DisplayChoiceList();
                if (int.TryParse(Console.ReadLine(), out inputMenuNumber) == true)
                {
                    //felhantering i de fall då inmatad siffra inte står med på listan
                    try
                    {
                        KitchenApplianceList.RemoveAt(inputMenuNumber - 1);
                    }
                    catch
                    {
                        Console.WriteLine("Ange en siffra som är listad!");
                        DisplayChoiceList();
                    }
                }
                else
                {
                    Console.WriteLine("Välj apparat från listan med en siffra!");
                    DisplayChoiceList();
                }
                break;
            case 5:
                /*val 5:
                 avslutar huvudmenyn*/
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
//metod för att lägga till apparat
void AddAppliance()
{
    bool inputRunCondition = true;
    bool isWorking;

    Console.Write("Ange typ:\n>");
    string typeInput = Console.ReadLine();
    Console.Write("Ange märke:\n>");
    string brandInput = Console.ReadLine();
    while(inputRunCondition == true)
    {
        Console.Write("Ange om apparaten fungerar (j/n):\n>");
        string isFunctioningInput = Console.ReadLine().ToLower();
        if(isFunctioningInput == "j" || isFunctioningInput == "n")
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