# gdi_PointAndClick
Das vorliegende WindowsForms-Projekt zeichnet mit GDI+ Rechtecke auf die GUI, wenn mit der Maus geklickt wird. Mit `Escape` wird die Darstellung wieder zurückgesetzt. Dieses UML-Klassendiagramm stellt den Aufbau dar: 

[![](https://mermaid.ink/img/pako:eNp1UMFugzAM_ZXIp01DFYUQINdVu2xI03abconAbaNBUiWhG0Pw7Qus662-2Hrv-enZI9SmQeBQt9K5nZIHKzuhhSahVow82a6SSo9_GCEPFmsv9aFFx8mLcn5--wfmq-Y1bHgyz3hG7ef57p6cjWqudGV6h4-tqj9va55x2JkvfUMwQQQd2k6qJqRfwwnwR-xQAA_j3lh0XoDQi1L23rwPugbubY8R9KdGerycC3wvWxdQbJQ3tro8ZGkRnKQGPsI38G1KN1lOaZnSuEjidJtEMAAv2KYskzJP0yRnKcuTKYIfY4JrvGG0YDmjZcximhVZsdp9rOSSY_oFr3V3_A?type=png)](https://mermaid.live/edit#pako:eNp1UMFugzAM_ZXIp01DFYUQINdVu2xI03abconAbaNBUiWhG0Pw7Qus662-2Hrv-enZI9SmQeBQt9K5nZIHKzuhhSahVow82a6SSo9_GCEPFmsv9aFFx8mLcn5--wfmq-Y1bHgyz3hG7ef57p6cjWqudGV6h4-tqj9va55x2JkvfUMwQQQd2k6qJqRfwwnwR-xQAA_j3lh0XoDQi1L23rwPugbubY8R9KdGerycC3wvWxdQbJQ3tro8ZGkRnKQGPsI38G1KN1lOaZnSuEjidJtEMAAv2KYskzJP0yRnKcuTKYIfY4JrvGG0YDmjZcximhVZsdp9rOSSY_oFr3V3_A)

## :dart: Ziele
- WindowsForms-Events kennen und einsetzen, um das Verhalten des Programms zu steuern.
- Objekte in Listen verwalten. Infos dazu in der [Doku](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0) oder [hier](https://csharp-hilfe.de/c-sharp-lists/).

## :clipboard:TODO
### Muss
1)  Die Rechtecke sollen mittig unter dem Mausklick entstehen.
2)	Ein neues Rechteck darf nur dann gezeichnet werden, wenn die **Klickposition** nicht auf einem bereits erzeugtem Rechteck liegt. Tipp: `.Contains` (siehe Cheatsheet)
3)	Die Größe neuer Rechtecke soll bei jedem Klick zufällig festgelegt werden. Vorhandene Rechtecke sollen ihre Größe behalten
4)	Die Farbe neuer Rechtecke soll bei jedem Klick zufällig ausgewählt werden.

### Kann
1)  Durch Rechtsklick auf ein bereits vorhandenes Rechteck soll dieses entfernt werden.
2)	Die Überschneidung zweier Rechtecke soll farblich hervorgehoben werden.

### Für Schnelle
1)	Durch Halten der Maustaste auf einem bereits vorhandenen Rechteck soll dessen Position verändert werden können.
2)	Bei Klick auf ein Rechteck soll dieses 'ausgewählt' werden. Durch Drücken der Pfeiltasten soll die Position verändert werden können.
