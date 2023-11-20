# rpg-character-sheet
A dektop app for creating/managing TTRPG character sheets.
## Description
RPG Character Sheet is a simple Desktop application for creating and managing character sheets for "The World's Most Popular Tabletop Roleplaying game". This application allows users to open a new Character Sheet and fill out all basic information needed for a character, including general info (name, class, level, etc.) abilities (ability scores, skill checks, attacks, etc.), and background information. Calculations for ability score modifiers, saving throws, and skill checks are all performed automatically. This includes accounting for a proficiency and expertise modifier. Lastly, this application allows users to save character data off to an "rpgc" file and load previously-saved files. All PRs into main have a workflow run that runs all unit tests.

Future features for this application include
- The ability to automatically calculate attack modifiers
- Tracking for spells and spell slots
- Automatic leveling
- Different pages for different TTRPGs

This application is built using .NET 7.0 and the MAUI Framework in order to create a desktop application with future potential for targetting mobile deployments.

## Project Structure
### RPGCharacterSheet
This project houses the basic data structures used by the application as well as the ViewModel used by the UI.

Notes:
- CharacterData is the main Model for the application.
- CharacterData does not build its own lists of Ability Scores, Saving Throws, and Skill Checks so that there can be greater flexibility in potential use for other TTRPG pages.
- Proficiency for a Saving Throw/Skill Check is not pulled directly from the CharacterData in order to maintain decoupling and allow easier eventing off of the ProficiencyBonus.

### RPGCharacterSheet.MAUI
This project houses the UI code for this application. 

#### MainPage
This is the first page of the application. This allows users to either open a blank CharacterSheet via "Create", or load a previously-saved character's data into the Sheet via "Load".

#### CharacterSheet
This is the primary page for interacting with the application. It holds form information for all basic aspects of a Character. Certain aspects are automcatically calculated from other entries e.g., Skill Checks modifiers are calcualted based on the skill's base AbilityScore modifier, and proficiency and expertise if those options are selected. Lastly, there is a save button to allow users to save their character. Entries designed for numeric input have a custom converter applied that automatically converts any non-numeric strings (including a blank string) to 0.

### RPGCharacterSheet.Tests
This project houses the unit tests for this solution, primarily focussed on testing the data structures. Included in this project is a PowerShell script to automatically run all unit tests, calculate code coverage, and generate a coverage report. Unit testing is performed through XUnit.