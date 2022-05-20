Feature: DeleteChargingSpot
	As an administrator I Want to delete a charging spot so that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in.
		Given an existing ChargingSpot:
			| Id | Name                 | Address        | Region   | Description    |
			| 1  | Cargar frente al mar | General Flores | SurOeste | Punto de carga |
		When the user tries to delete the existing charging spot
		Then the error 'You must be logged in to delete a charging spot' should be raised