# Solid-Course
Single Responsibility Principe --- Persistentie

We hebben het uitlezen van een file weggenomen uit Processor en deze in FileKlantSource gezet.
Vervolgens gebruiken we een instantie van deze source in Processor om de uitlees functionaliteit aan te roepen.
Onze code blijft werken, maar de echte implementatie van wat de GetKlantFromFile methode doet, staat nu apart.