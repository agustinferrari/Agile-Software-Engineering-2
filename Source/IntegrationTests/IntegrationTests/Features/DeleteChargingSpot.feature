Feature: DeleteChargingSpot
	As an administrator
	I Want to delete a charging spot
	So that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in.
		Given an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And the charging spots
			| Id | Name                 | Address        | RegionName           | Description    |
			| 1  | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
		When the user tries to delete the charging spot
		Then no delete button should be found

	@mytag
	@ignore
	Scenario: Delete charging spot with invalid data.
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 0  | Cargar frente al mar | General Flores | 1        | Punto de carga |
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
		And an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And the charging spots
			| Id | Name                 | Address        | RegionName           | Description    |
			| 1  | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
		When the user deletes the charging spot
		Then the error <Error> should be raised

		Examples:
			| Error                       |
			| No charging spots in system |
		