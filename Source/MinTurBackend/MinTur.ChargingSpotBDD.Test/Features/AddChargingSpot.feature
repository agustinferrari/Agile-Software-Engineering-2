Feature: AddChargingSpot

@mytag
@ignore
Scenario: Add charging spot without being logged in.
	Given a Region already registered:
	| Id | Name                 | TouristPoints  |
	| 1  | SurOeste             | []             |
	And a new ChargingSpot:
	| Id| Name                 | Address        | Region   | Description     |
	| 1 | Cargar frente al mar | General Flores | SurOeste | Punto de carga  |
	When the user tries to add the new charging spot
	Then an error 'You must be logged in to create a charging spot' should be raised