Feature: AddChargingSpot

@mytag
Scenario: Add charging spot without being logged in.
	Given a new ChargingSpot:
	| Id| Name                 | Address        | RegionId   | Description     |
	| 1 | Cargar frente al mar | General Flores | 1 | Punto de carga  |
	When the user tries to add the new charging spot
	Then an error 'Please send your authorization token' should be raised