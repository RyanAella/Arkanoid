Author: Rebecca Biebl, 205037

In dieser Arkanoid-Version ist vorhanden:

- grundlegende Kollisionsabfrage des Balls mit anderen Ojekten
  (Spieler-Paddle, Blöcke/Hindernisse, Wände)
  (Bekannter Bug: Teilweise falsch erkannte Kollisionen mit Wand, mehrfaches Berühren der Wand)
  
- 3 Arten von Powerups
  (Paddle vergrößern, Paddle beschleunigen, Ball bleibt am Paddle kleben)
  
- 3 Arten von Hindernisse
  (1, 2 und 3 Leben, sind entsprechend viele Punkte wert)
  
- UI mit Punktanzeige, Spieler-Lebensanzeige

- Main Menu

- Victory Screen mit Punktezähler, vergangener Spielzeit, Verloren/Gewonnen, Buttons für Main Menu und Next Level bzw. Restart Level
  
- verschiedene Sounds für Powerups, Kollisionen mit Paddle und Blöcken, Block-Zerstörung
  

Ablauf:

- Bei Spielstart haftet der Ball am Paddle. Durch das Drücken von Space wird er abgeschossen.

- Das Spieler-Paddle lässt sich per "A", "D" und den Pfeiltasten steuern.

- Powerups werden gespawnt, wenn die entsprechenden Blöcke zerstört werden. Die Auswahl, welcher Block ein Powerup spawnt und welches das ist, erfolgt zufallsgeneriert.
  
- Der Spieler hat 3 Leben. Bei 0 Leben ist das Spiel verloren. 

- Wenn alle Blöcke zerstört wurden, ist das Spiel gewonnen.
 
- Sowohl bei Sieg, als auch bei Niederlage kann das nächste Level gestartet oder zum Hauptmenü zurückgekehrt werden.


Link zum Video: https://youtu.be/6x19AJP5_pQ