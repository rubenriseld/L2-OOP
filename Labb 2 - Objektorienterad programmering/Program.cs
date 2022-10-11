bool isRunning = true;

//lista för alla köksapparater
List<KitchenAppliance> KitchenApplianceList = new List<KitchenAppliance>();

//tre befintliga apparater som finns vid upsptart
KitchenApplianceList.Add(new KitchenAppliance("Kylskåp", "Electrolux", true));
KitchenApplianceList.Add(new KitchenAppliance("Brödrost", "SMEG", true));
KitchenApplianceList.Add(new KitchenAppliance("Ugn", "Electrolux", true));

//while-loop för menyn som utgångspunkt så länge användaren inte väljer att avsluta
while (isRunning == true)
{
    DisplayMenu();
    int inputNumber;

    //felhantering i de fall då inmatat värde ej är en siffra
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
                //felhantering i de fall då inmatad siffra inte står med på listan
                Console.WriteLine("\nAnge en siffra som är listad!\n");
                break;
        }
    }
    else Console.WriteLine("\nVälj ett val från menyn med en siffra!\n");
}

//metod för att skriva ut huvudmenyn
void DisplayMenu()
{
    Console.WriteLine(
        "======KÖKET======\n" +
        "1. Använd köksapparat\n" +
        "2. Lägg till kökapparat\n" +
        "3. Lista köksapparater\n" +
        "4. Ta bort köksapparat\n" +
        "5. Avsluta\n");
    Console.Write("Ange val:\n>");
}

//metod för att skriva ut detaljerad lista över alla befintliga apparater
void DisplayInfoList()
{
    if (KitchenApplianceList.Count == 0)
    {
        Console.WriteLine("\nDet finns inga köksapparater i köket, " +
            "vänligen lägg till nya i huvudmenyn!\n");
    }
    else
    {
        Console.WriteLine("\nListar köksapparater i köket...\n");
        foreach (var appliance in KitchenApplianceList)
        {
            Console.WriteLine($"Typ: {appliance.type}\n" +
                $"Märke: {appliance.brand}\n" +
                $"Fungerar: {appliance.CheckFunctioning()}\n");
        }
    }
}

//metod för att skriva ut kortfattad lista över apparater, vid användning och borttagning
void DisplayChoiceList()
{
    Console.WriteLine("\nVälj köksapparat:\n");
    for (int i = 0; i < KitchenApplianceList.Count(); i++)
    {
        Console.WriteLine($"{i + 1}. {KitchenApplianceList[i].type}");
    }
    Console.Write("\nAnge val:\n>");
}

//metod för att använda en av köksapparaterna
void UseAppliance()
{
    bool inputRunCondition = true;
    int inputNumber;

    if (KitchenApplianceList.Count == 0)
    {
        Console.WriteLine("\nDet finns inga köksapparater i köket, " +
            "vänligen lägg till nya i huvudmenyn!\n");
    }
    else
    {
        while (inputRunCondition == true)
        {
            DisplayChoiceList();
            //felhantering i de fall då inmatat värde ej är en siffra
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
                    Console.WriteLine("\nAnge en siffra som är listad!");

                }
            }
            else
            {
                Console.WriteLine("\nVälj apparat från listan med en siffra!");
            }
        }
    }
}

//metod för att lägga till apparat
void AddAppliance()
{
    bool inputRunCondition = true;
    bool isWorking;

    Console.WriteLine("\nLägger till en köksapparat.\n");

    Console.Write("Ange typ:\n>");
    string typeInput = Console.ReadLine();

    Console.Write("Ange märke:\n>");
    string brandInput = Console.ReadLine();

    while (inputRunCondition == true)
    {
        Console.Write("Ange om apparaten fungerar (j/n):\n>");
        //enkel felhantering om inmatning är stor bokstav istället för liten
        string isFunctioningInput = Console.ReadLine().ToLower();

        //felhantering i de fall då inmatat värde ej är "j" eller "n"
        if (isFunctioningInput == "j" || isFunctioningInput == "n")
        {
            if (isFunctioningInput == "j") isWorking = true;
            else isWorking = false;

            KitchenApplianceList.Add(new KitchenAppliance(typeInput, brandInput, isWorking));
            Console.WriteLine("\nTillagd!\n");
            inputRunCondition = false;
        }
        else
        {
            Console.WriteLine("Felaktig inmatning, ange svar med bokstav 'j' eller 'n'!");
        }
    }
}

//metod för att ta bort en apparat
void RemoveAppliance()
{
    bool inputRunCondition = true;
    int inputNumber;

    if (KitchenApplianceList.Count == 0)
    {
        Console.WriteLine("\nDet finns inga köksapparater i köket, " +
            "vänligen lägg till nya i huvudmenyn!\n");
    }
    else
    {
        while (inputRunCondition == true)
        {
            DisplayChoiceList();
            //felhantering i de fall då inmatat värde ej är en siffra
            if (int.TryParse(Console.ReadLine(), out inputNumber) == true)
            {
                //felhantering i de fall då inmatad siffra inte står med på listan
                try
                {
                    KitchenApplianceList.RemoveAt(inputNumber - 1);
                    inputRunCondition = false;
                    Console.WriteLine("\nBorttagen!\n");
                }
                catch
                {
                    Console.WriteLine("\nAnge en siffra som är listad!");
                }
            }
            else
            {
                Console.WriteLine("\nVälj apparat från listan med en siffra!");
            }
        }
    }
}