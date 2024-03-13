# Tipps
Hier findest du ein paar Tipps, die dir weiterhelfen können. 

## Klassenstruktur
Sollte dir unklar sein, wie du die Klassen für das Projekt strukturieren sollst, kannst du dich an diesem Klassendiagramm orientieren:
![Klassendiagram](</Class Diagram.svg>)
Im Folgenden findest du eine kurze Erläuterung zu jeder Klasse.
### FieldState
FieldState ist eine Enumeration, die den Status einer Zelle des Spielfeldes darstellt: Jedes Feld kann entweder leer, von Spieler 1 oder von Spieler 2 belegt sein.

### Game
Diese Klasse repräsentiert ein Tic Tac Toe Spiel. Sie speichert Referenzen auf das Spielfeld sowie die beiden Spieler und koordiniert den Spielablauf. Hierzu hat sie Methoden, mit denen der Spielstand (Sieg eines Spielers, Spielfeld voll belegt) oder die Gültigkeit eines Zuges überprüft sowie das Spielfeld auf der Konsole ausgegeben werden kann.

### Player
Die Player-Klasse repräsentiert einen Spieler. Jeder Spieler verfügt über ein Symbol (X oder O) sowie eine Spielernummer. Die Klasse stellt zudem eine Methode bereit, die den Spieler zur Eingabe seines nächsten Spielzuges auffordert und diesen dann ausführt.

## Darstellung des Spielfelds
Das ganze Spiel muss mit Buchstaben und Zeichen dargestellt werden. Für den Rahmen eignen sich dabei zum Beispiel folgende Zeichen:
- "-"
- "_"
- "|"

## Eingabe durch den Spieler
Da du keine Maus zur Eingabe verwenden kannst, muss der Spieler die gewünschte Zelle durch Eingabe der Koordinaten auswählen. Die mittlere Zelle hat zum Beispiel die Koordinaten (2|2).

## Mögliche Spielzüge
Es gibt einige Voraussetzungen dafür, dass ein Spielzug erlaubt ist:
1. Die gewünschte Reihe ist mindestens 1 und höchstens 3
2. Die gewünschte Spalte ist mindestens 1 und höchstens 3
3. Die gewünschte Zelle ist leer

## Spielende
Es gibt drei mögliche Enden für das Spiel:
- Spieler 1 hat drei in einer Reihe (horizontal/vertikal/diagonal)  
    -> Spieler 1 gewinnt
- Spieler 2 hat drei in einer Reihe (horizontal/vertikal/diagonal)  
    -> Spieler 2 gewinnt
- Alle Felder sind voll, aber kein Spieler hat gewonnen
    -> unentschieden