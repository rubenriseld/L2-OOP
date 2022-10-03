

//övrigt:

/*
 när programmet startar ska det finnas ett antal köksapparater lagrade i en lista redo att användas
programmet ska felhantera all inmatning
ingen filhantering*/

//KRAV:
/* variabler
 * properties (auto-implemented)
 * typkonvertering
 * felhantering med try-catch alt tryparse e.d.
 * klass/klasser
 * abstrakt klass/klasser
 * interface (valfritt att utöka)
 * inkapsling (rpivate/public etc)
 * metoder
 * iteration
 * selektion
 * */




//HUVUDMENY
internal class KitchenAppliance : KitchenApplianceAbstract
{
    public KitchenAppliance(string type, string brand, bool isFunctioning) : base(type, brand, isFunctioning)
    {
    }
}
