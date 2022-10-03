/*val1:
 skriv ut undermeny av apparater att välja
skriv ut meddelande om apparaten är trasig om trasig
annars skriv ut att den används
gå tillbaka till huvudmeny*/

/*val2:
 lägg till köksapparat
låter användaren mata in typ, märke och skick,
(tex "våffeljärn", "electrolux", "j" -> om litet j betyder det att den funkar
annars litet n -> trasig
lagrar apparaterna i en lista och skriver ut meddelande om att apparaten lagts till
gå tillbaka till huvudmeny*/

/*val 3:
 lista köksapparater, inklusive alla som lagts till
ska inkludera typ, märke och skick
gå tillbaka till huvudmeny*/

/*val 4:
 ta bort köksapparat
skriv ut en numrerad lista över alla köksapparater
låter användaren ange vilken köksapparat som ska tas bort och läser in valet
tar bort köksapparaten från listan över lagrade köksapparater och 
skriver ut ett meddelande om att köksapparaten har tagits bort
gå tillbaka till huvudemnyn*/

/*val 5:
 avslutar huvudmenyn*/


//HUVUDMENY
void DisplayMenu()
{
    Console.WriteLine(
        "1. Använd köksapparat\n" +
        "2. Lägg till kökapparat\n" +
        "3. Lista köksapparater\n" +
        "4. Ta bort köksapparat\n" +
        "5. Avsluta");
}

public interface IKitchenAppliance
{
    string Type { get; set; }
    string Brand { get; set; }
    bool IsFunctioning { get; set; }
    void Use();
}
