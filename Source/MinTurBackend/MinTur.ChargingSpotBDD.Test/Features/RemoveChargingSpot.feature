Feature: DeleteChargingSpot
	As an administrator I Want to delete a charging spot so that turists don't search a closed charging spot.

	@mytag
	@ignore
	Scenario: Delete charging spot without being logged in.
		Given a not logged in user
		And an existing ChargingSpot:
			| Id | Name                 | Address        | Region   | Description    | Error                                                                    |
			| 1  | Cargar frente al mar | General Flores | SurOeste | Punto de carga | Can not delete charging spot without being logged in as an administrator |
		When the user tries to delete the new charging spot
		Then an error 'You must be logged in to delete a charging spot' should be raised