Feature: GetChargingSpot
	As a user
	I Want to know the data from charging spots
	So that I know where to charge my electric car

	@mytag
	Scenario: Get charging spot given non existing
		Given an existing region
			| Id | Name     |
			| 1  | SurOeste |
		And no charging spots saved
		When the user requests the list of charging spots
		Then the error <Error> should be raised

		Examples:
			| Id | Error                       |
			| 1  | No charging spots in system |

	@mytag
	Scenario: Get all charging spots
		Given an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And no charging spots saved
		And the charging spots
			| Id | Name                 | Address        | RegionName           | Description      |
			| 1  | Cargar frente al mar | General Flores | Región Metropolitana | Punto de carga 1 |
			| 2  | Cargar dentro        | 18 de julio    | Región Metropolitana | Punto de carga 2 |
		When the user requests the list of charging spots
		Then a list containing the charging spots should be returned
