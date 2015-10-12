OOP Design 
C# Game development 
Visual Studio


Rules of the game:

1. Each player starts with 1 mana crystal, after every round a player is rewarded with an additional mana crystal up to a maximum of 10, mana crystals regenerate per turn. For example, round 1 each player has 1 mana crystal to spend, round 2 they have 2 to spend, and so on up to a maximum of 10.

2. A player deck consists of the following 30 cards:

a. 10 cards that deal 1 damage and cost 1 mana.
b. 4 cards that deal 2 damage and cost 2 mana.
c. 2 cards that deal 3 damage and cost 3 mana.
d. 2 cards that deal 4 damage and cost 4 mana.
e. 2 card that deals 5 damage and cost 5 mana.
f. 5 cards that heal for 1 hit point and cost 1 mana.
g. 2 cards that heal for 2 hit points and cost 2 mana.
h. 2 cards that deal 1 damage and cost 1 mana, in addition the player draws another card.
i. 1 legendary card that deals 4 damage and you get 1 extra mana crystal that turn, costs 5 mana and outputs
the epic message “You will never defeat me!” to the UI.

3. Each player has their own distinct deck.

4. Each player starts with 4 random cards and 30 hit points.

5. A player can play as many cards as they have mana for, there is no “board” and once a card is played it is discarded.

6. A player does not need to spend all their mana every turn.

7. You can assume damage cards only damage the opponent and heal cards only heal you.

8. At the beginning of a turn a player draws another card from their deck.

9. If all 30 cards from the player’s deck have been drawn, the player is deducted 1 hit point at the start of their turn.

10. The game is over when one player reaches 0 hit points.

11. There are no time limits per turn.
