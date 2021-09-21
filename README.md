# Solid-Course
Dependency Inversion Principle --- ILogger

We hebben ervoor gezorgd dat overal ILogger wordt meegegeven met de constructors.
zo kunnen we dus op 1 plaats kiezen welke soort logger we willen gebruiken, zonder dat de klassen die er gebruik van maken moeten weten over welk soort logger het gaat.