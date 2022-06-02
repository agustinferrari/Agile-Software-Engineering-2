Feature: AddChargingSpot
	As an administrator
	I Want to add a charging spot
	So that turists know where to find the charging spot.


	@mytag
	Scenario: Add charging spot without being logged in.
		Given a new ChargingSpot
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to add the new charging spot
		Then the user is not allowed to create the charging spot

		Examples:
			| Id | Error                                |
			| 1  | Please send your authorization token |

	@mytag
	Scenario: Add charging spot with invalid characters.
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionName>
		And the description <Description>
		When the user tries to add the new charging spot
		Then the alert <Alert> should be shown

		Examples:
			| Name                | Address           | RegionName 				| Description    | Alert                                                                |
			| Cargar parada @$#%# | General Flores    | Región Metropolitana  	| Punto de carga | the name must be alphanumeric with a maximum of 20 characters        |
			| Cargar parada 2     | Direccion @2 !..% | Región Metropolitana    | Punto de carga | the address must be alphanumeric with a maximum of 30 characters     |
			| Cargar parada 2     | General Flores    | Región Metropolitana    | Desc @[][]??   | the description must be alphanumeric with a maximum of 60 characters |

	@mytag
	Scenario: Add charging spot with invalid data length.
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionName>
		And the description <Description>
		When the user tries to add the new charging spot
		Then the alert <Alert> should be shown

		Examples:
			| Name                              | Address                                      | RegionName 				 | Description                                                                | Alert                                                                |
			| Cargar parada 223 mas de 20 chars | General Flores                               | Región Metropolitana        | Punto de carga                                                             | the name must be alphanumeric with a maximum of 20 characters        |
			| Cargar parada 2                   | General Flores General Flores General Flores | Región Metropolitana        | Punto de carga                                                             | the address must be alphanumeric with a maximum of 30 characters     |
			| Cargar parada 2                   | General Flores                               | Región Metropolitana        | Punto de carga Punto de carga Punto de carga Punto de carga Punto de carga | the description must be alphanumeric with a maximum of 60 characters |

	@mytag
	Scenario: Add charging spot with a non-existent region.
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionId>
		And the description <Description>
		When the user tries to add the new charging spot
		Then the charging spot couldnt be created

		Examples:
			| Name            | Address        | RegionId | Description    |
			| Cargar parada 2 | General Flores | 2        | Punto de carga |

	@mytag
	Scenario: Add charging spot with valid data
		Given a logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And an existing region
			| Id | Name                 |
			| 1  | Región Metropolitana |
		And a new ChargingSpot
			| Name            | Address        | RegionName 			| Description    |
			| Cargar parada 1 | General Flores | Región Metropolitana   | Punto de carga |
		When the user tries to add the new charging spot
		Then the charging spot should be added successfully