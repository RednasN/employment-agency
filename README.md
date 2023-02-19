# Employment Agency Editor

**Functionaliteiten:**
 - API met CRUD ondersteuning voor vacatures en bedrijven.
 - Front-end:
	 - Lijst met bedrijven met een filter waardoor alleen bedrijven met vacatures getoond worden.
	 - Een formulier om vacatures toe te voegen inclusief validatie.

**Gemaakte keuzes en prioriteiten:**

Backend:
 - Ik heb gekozen om Clean Archtiecture toe te passen voor de back-end:
	 - Het maakt testen makkelijker omdat alle onderdelen "ontkoppeld" zijn. Mits het goed opgezet is is het makkelijk om de logica te testen.
	 - Het is eenvoudig om de database (ook al komt dat niet vaak voor) aan te passen.
	 - Overzichtelijk
- Ik heb gekozen om CQRS d.m.v. MediatR toe te passen. Ook hier zijn onderdelen ontkoppeld en vind het "Single Responsibility" principe plaats. Verder zijn er minder afhankelijken tussen de services aanwezig. Een controller heeft bijvoorbeeld maar een dependency en dat is *IMediatR*om gegevens te kunnen toevoegen, wijzigen, verwijderen en bekijken. Echter is er ook een nadeel; debuggen gaat lastiger.
- Er is gekozen voor een repository pattern, dit maakt testen van logica eenvoudiger en d.m.v. de basis repository kan er code hergebruikt worden.
- Verder heb ik gekozen van een *InMemoryDatabase", de applicatie kan uitgevoerd worden zonder afhankelijkheid van een SQL database (na het afsluiten ben je wel alle gegevens kwijt).
- Voor validatie heb ik gebruik gemaakt van FluentValidation, hiermee is het eenvoudig om validatie toe te voegen.
- De domeinmodellen zijn in dit geval gelijk aan de databasemodellen, voor de communicatie heb ik gebruik gemaakt van DTO's zodat het domein gescheiden van wat de gebruiker ziet. Het domein wordt d.m.v. automapper gemapped naar DTO's.

Front-end:

 - Voor het genereren van de API heb ik gebruik gemaakt van de openapi-generator-cli op basis van een OpenApi specificatie. Voorkomt fouten in het model/api en is vrij snel opgezet.
 - Voor codestyle heb ik gebruik gemaakt van ESLint. Ik kwam er echter wel achter dat de gegenereerde API code niet voldoet aan de standaard ESlint configuratie, ik heb deze code dan ook uitgezonderd van de linting (komt omdat de code gegenereerd is).
 - Voor het formulier om een vacature te genereren heb ik gebruik gemaakt van "Reactive Forms" in Angular. Het formulier wordt opgebouwd vanuit de code en input elementen kunnen hergebruikt worden. Voor laatste genoemde heb ik een FormService geschreven waarin FormControls gegenereerd worden met het idee om nog andere formulieren te maken, echter is het beperkt tot 1 formulier; het toevoegen van vacatures.

**Prioriteiten**

 - Voor de back-end ligt de focus op de architectuur, ik heb geprobeerd een duidelijke projectstructuur neer te zetten. Verder heb ik aandacht besteed aan de validatie van de invoer (bepaalde velden zijn verplicht en er wordt gecontroleerd of afhankelijkheden beschikbaar zijn, hiervoor is foutafhandeling geïmplementeerd).
 - Voor de front-end had ik het plan om ook nog een formulier voor bedrijven aan te maken, maar omwille van de tijd ben ik hier niet aan toegekomen. Ik heb hiervoor een manier uitgewerkt (https://angular.io/guide/dynamic-form) waardoor het minder tijd kost om formulieren op te zetten en input velden hergebruikt kunnen worden.
