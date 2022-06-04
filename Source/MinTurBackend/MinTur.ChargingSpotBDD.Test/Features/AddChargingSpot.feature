Feature: AddChargingSpot
	As an administrator
	I Want to add a charging spot
	So that turists know where to find the charging spot.

	@mytag
	Scenario: Add charging spot without being logged in
		And the existing region
			| Id | Name     |
			| 1  | SurOeste |
		Given a non-logged in admin
		And a new ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to add the charging spot
		Then the error <Error> should be raised
	
		Examples:
			| Error 				|
			| Please send your authorization token  |

	@mytag
	Scenario: Add charging spot with invalid characters
		Given a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionId>
		And the description <Description>
		When the user tries to add the charging spot
		Then the error <Error> should be raised

		Examples:
			| Name                 | Address             | RegionId | Description      | Error                                                                |
			| Cargar parada @$#%#  | General Flores      | 1        | Punto de carga   | the name must be alphanumeric with a maximum of 20 characters        |
			| Cargar parada 2      | Direccion @2 !..%   | 1        | Punto de carga   | the address must be alphanumeric with a maximum of 30 characters     |
			| Cargar parada 2      | General Flores      | 1        | Desc @[][]??     | the description must be alphanumeric with a maximum of 60 characters |

	@mytag
	Scenario: Add charging spot with invalid data length
		Given a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionId>
		And the description <Description>
		When the user tries to add the charging spot
		Then the error <Error> should be raised

		Examples:
			| Name                              | Address                                      | RegionId | Description                                                                | Error                                                                |
			| Cargar parada 223 mas de 20 chars | General Flores                               | 1        | Punto de carga                                                             | the name must be alphanumeric with a maximum of 20 characters        |
			| Cargar parada 2                   | General Flores General Flores General Flores | 1        | Punto de carga                                                             | the address must be alphanumeric with a maximum of 30 characters     |
			| Cargar parada 2                   | General Flores                               | 1        | Punto de carga Punto de carga Punto de carga Punto de carga Punto de carga | the description must be alphanumeric with a maximum of 60 characters |

	@mytag
	Scenario: Add charging spot with a non-existent region
		Given a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionId>
		And the description <Description>
		When the user tries to add the charging spot
		Then the error <Error> should be raised

		Examples:
			| Name              | Address         | RegionId | Description      | Error                            |
			| Cargar parada 2   | General Flores  | 0        | Punto de carga   | Could not find specified region  |

	@mytag
	Scenario: Add charging spot with valid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And the existing region
			| Id | Name     |
			| 2  | SurOeste |
		Given a new ChargingSpot
			| Name            | Address        | RegionId | Description    |
			| Cargar parada 1 | General Flores | 2        | Punto de carga |
		When the user tries to add the charging spot
		Then the charging spot should be added to the database