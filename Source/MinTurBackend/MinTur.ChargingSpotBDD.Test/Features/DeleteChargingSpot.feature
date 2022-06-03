Feature: DeleteChargingSpot
	As an administrator
	I Want to delete a charging spot
	So that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in
		Given a non-logged in admin
		And the existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to delete the charging spot
		Then the error <Error> should be raised

		Examples:
			| Error 								|
			| Please send your authorization token  |

	@mytag
	Scenario: Delete charging spot with invalid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And a non-existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to delete the charging spot
		Then the error <Error> should be raised

		Examples:
			| Error 								 |
			| Could not find specified charging spot |

	@mytag
	Scenario: Delete charging spot with valid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And the existing region
			| Id | Name     |
			| 1  | SurOeste |
		And the existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to delete the charging spot
		Then the charging spot should be deleted from the database