Feature: DeleteChargingSpot
	As an administrator
	I Want to delete a charging spot
	So that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in.
		Given an existing ChargingSpot:
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to delete the existing charging spot
		Then the error 'Please send your authorization token' should be raised

	@mytag
	Scenario: Delete charging spot with invalid data.
		Given an existing, logged user
			| Email            | Password |
			| matias@admin.com | admin    |
		And a not existing ChargingSpot:
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to delete the not existing charging spot
		Then the error 'Could not find specified charging spot' should be raised

	@mytag
	Scenario: Delete charging spot with valid data
		Given an existing, logged admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And the existing Region:
			| Id | Name     |
			| 1  | SurOeste |
		And the existing ChargingSpot:
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to delete the charging spot
		Then the charging spot should be deleted from the database