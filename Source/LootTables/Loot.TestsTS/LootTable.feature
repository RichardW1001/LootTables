
Feature: Loot Tables
	As a player 
	I should receive a random reward
	So that the reward system is varied

Scenario: Happy Case 1
	Given the next random number is 0.25
	And the loot table
	| Item               | Weighting |
	| Sword              | 10        |
	| Shield             | 10        |
	| Health Potion      | 30        |
	| Resurrection Phial | 30        |
	| Scroll of wisdom   | 20        |
	When rolling for a loot item for "Little Sparrow"
	Then the loot item should be "Health Potion"
	And a log entry should show "Health Potion" given to "Little Sparrow"

Scenario: Happy Case 2
	Given the next random number is 0.75
	And the loot table
	| Item               | Weighting |
	| Sword              | 10        |
	| Shield             | 10        |
	| Health Potion      | 30        |
	| Resurrection Phial | 30        |
	| Scroll of wisdom   | 20        |
	When rolling for a loot item for "Little Sparrow"
	Then the loot item should be "Resurrection Phial"
	And a log entry should show "Resurrection Phial" given to "Little Sparrow"

Scenario: Happy Case 3
	Given the next random number is 0
	And the loot table
	| Item               | Weighting |
	| Sword              | 10        |
	| Shield             | 10        |
	| Health Potion      | 30        |
	| Resurrection Phial | 30        |
	| Scroll of wisdom   | 20        |
	When rolling for a loot item for "Little Sparrow"
	Then the loot item should be "Sword"

Scenario: Happy Case 4
	Given the next random number is 0.1
	And the loot table
	| Item               | Weighting |
	| Sword              | 10        |
	| Shield             | 10        |
	| Health Potion      | 30        |
	| Resurrection Phial | 30        |
	| Scroll of wisdom   | 20        |
	When rolling for a loot item for "Little Sparrow"
	Then the loot item should be "Shield"

Scenario: No items
	Given the next random number is 0
	And the loot table
	| Item               | Weighting |
	When rolling for a loot item for "Little Sparrow"
	Then there should be an error