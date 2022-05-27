Feature: DeleteChargingSpot
	As an administrator
	I Want to delete a charging spot
	So that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in.
		Given an existing region
			| Id | Name     |
			| 1  | SurOeste |
		And an existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		And a charging spot with id <Id>
		When the user tries to delete the charging spot
		Then the error <Error> should be raised

		Examples:
			| Id | Error                                |
			| 1  | Please send your authorization token |

	@mytag
	Scenario: Delete charging spot with invalid data.
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		And a charging spot with id <Id>
		When the user tries to delete the charging spot
		Then the error <Error> should be raised

		Examples:
			| Id | Error                                  |
			| 2  | Could not find specified charging spot |

	@mytag
	Scenario: Delete charging spot with valid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing Region
			| Id | Name     |
			| 1  | SurOeste |
		And an existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		And a charging spot with id <Id>
			| Id |
			| 1  |
		When the user tries to delete the charging spot
		Then the charging spot should be deleted from the database