# Tic Tac Toe
Jeder hat schon einmal das Spiel Tic Tac Toe gespielt - in dieser Übung wirst du deine eigene Version davon programmieren.

## Aufgabe
Programmiere Tic Tac Toe in einer objektorientierten Programmiersprache deiner Wahl.  
Zunächst solltest du dich auf eine Zwei-Spieler-Version konzentrieren - sobald diese geschafft ist, kannst du dich aber auch an einer KI für das Spiel versuchen.  
Das Spiel soll in der Konsole laufen, du musst dich also nicht um eine graphische Oberfläche kümmern.

Solltest du beim Programmieren an einer bestimmten Stelle nicht weiterkommen, findest du im Folgenden ein paar Tipps. Außerdem gibt es eine Musterlösung (in C#), die dir weiterhelfen kann.

## Tipps
Hier findest du ein paar Tipps, die dir weiterhelfen können. 

### Mögliche Klassenstruktur
![Klassendiagramm](Class Diagram.svg)

### Darstellung des Spielfelds
Das ganze Spiel muss mit Buchstaben und Zeichen dargestellt werden. Für den Rahmen eignen sich dabei zum Beispiel folgende Zeichen:
- "-"
- "_"
- "|"

### Eingabe durch den Spieler
Da du keine Maus zur Eingabe verwenden kannst, muss der Spieler die gewünschte Zelle durch Eingabe der Koordinaten auswählen. Die mittlere Zelle hat zum Beispiel die Koordinaten (2|2).

### Mögliche Spielzüge
Es gibt einige Voraussetzungen dafür, dass ein Spielzug erlaubt ist:
1. Die gewünschte Reihe ist mindestens 1 und höchstens 3
2. Die gewünschte Spalte ist mindestens 1 und höchstens 3
3. Die gewünschte Zelle ist leer

### Spielende
Es gibt drei mögliche Enden für das Spiel:
- Spieler 1 hat drei in einer Reihe (horizontal/vertikal/diagonal)  
    -> Spieler 1 gewinnt
- Spieler 2 hat drei in einer Reihe (horizontal/vertikal/diagonal)  
    -> Spieler 2 gewinnt
- Alle Felder sind voll, aber kein Spieler hat gewonnen
    -> unentschieden