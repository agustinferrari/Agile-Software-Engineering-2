Feature: DeleteChargingSpot
	As an administrator I Want to delete a charging spot so that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in.
		Given an existing ChargingSpot:
			| Id | Name                 | Address        | Region   | Description    |
			| 1  | Cargar frente al mar | General Flores | SurOeste | Punto de carga |
		When the user tries to delete the existing charging spot
		Then the error 'You must be logged in to delete a charging spot' should be raised

	@mytag
	Scenario: Delete charging spot with invalid data.
		Given an existing, logged user
			| Email            | Password |
			| matias@admin.com | admin    |
		And a not existing ChargingSpot:
			| Id | Name                 | Address        | Region   | Description    |
			| 1  | Cargar frente al mar | General Flores | SurOeste | Punto de carga |
		When the user tries to delete the not existing charging spot
		Then the error 'Could not find specified charging spot' should be raised