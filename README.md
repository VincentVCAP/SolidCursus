# Solid-Course
Interface Segregation Principle --- Oplossing

Er is nu enkel nog een ojbect Export aanwezig, deze kan eenvoudig geimplementeerd worden door KlantDocument (want een string is ook een object).
In de ExportManager heb je nog steeds de ExportToText die nog even (in dit geval onnodige) cast doet naar een string van het object.
ExportManager kan nu niet meer de, de nu onbestaande, niet geimplementeerde ToPdf aanroepen.