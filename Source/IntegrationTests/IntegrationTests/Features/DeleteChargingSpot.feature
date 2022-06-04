Feature: DeleteChargingSpot
	As an administrator
	I Want to delete a charging spot
	So that turists don't search a closed charging spot.

	@mytag
	Scenario: Delete charging spot without being logged in
		Given an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And the charging spots
			| Id | Name                 | Address        | RegionName           | Description    |
			| 1  | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
		When the user tries to delete the charging spot
			| Name                 |
			| Cargar frente al mar |
		Then the charging spot cannot be deleted

	@mytag
	Scenario: Delete charging spot with invalid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		Given an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And the charging spots
			| Id | Name                 | Address        | RegionName           | Description    |
			| 1  | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
		When the user tries to delete the charging spot
			| Name        |
			| Inexistente |
		Then the charging spots by those names cannot be deleted

	@mytag
	Scenario: Delete charging spot with valid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And the charging spot
			| Id | Name                 | Address        | RegionName           | Description    |
			| 1  | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga |
		When the user deletes the charging spot
		Then the error <Error> should be raised

		Examples:
			| Error                       |
			| No charging spots in system |
