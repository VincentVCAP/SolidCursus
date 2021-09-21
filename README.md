# Solid-Course
Interface Segregation Principle --- Start

We hebben nieuwe export functionaliteit toegevoegd om een overzicht van de gehuurde films etc van een klant te exporteren (in dit geval nog afdrukken op de console)
Maar er is een probleem: onze interface heeft 2 methoden: ToText en ToPdf, de eerste methode kan geimplementeerd worden in onze KlantDocumentKlasse, maar de 2e niet!
Dit geeft wat overbodige code, probeer dit te fixen zodat alles in het export mapje toch blijft werken.