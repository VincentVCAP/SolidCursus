# Solid-Course
Single Responsibility Principe --- Logging

We hebben de logging functionaliteit weggenomen uit Processor en deze in ConsoleLogger gezet.
Vervolgens gebruiken we een instantie van deze logger in Processor om de logging functionaliteit aan te roepen.
Onze code blijft werken, maar de echte implementatie van wat de Log() methode doet, staat nu apart.