# Solid-Course
Single Responsibility Principe --- Persistentie

We hebben het converteren van een JSONstring naar een lijst van objecten weggenomen uit Processor en deze in JsonKlantSerializer gezet.
Vervolgens gebruiken we een instantie van deze serializer in Processor om de serializatie functionaliteit aan te roepen.
Onze code blijft werken, maar de echte implementatie van wat de GetKlantenFromJsonString methode doet, staat nu apart.