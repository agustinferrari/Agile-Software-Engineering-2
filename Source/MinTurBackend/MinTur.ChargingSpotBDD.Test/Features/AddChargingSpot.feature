﻿Feature: AddChargingSpot
	As an administrator
	I Want to add a charging spot
	So that turists know where to find the charging spot.

	@mytag
	Scenario: Add charging spot without being logged in.
		Given a new ChargingSpot:
			| Id | Name                 | Address        | RegionId | Description    |
			| 1  | Cargar frente al mar | General Flores | 1        | Punto de carga |
		When the user tries to add the new charging spot
		Then an error 'Please send your authorization token' should be raised

	@mytag
	Scenario: Add charging spot with invalid data.
		Given a new ChargingSpot named <Name>
		And located in <Address>
		And in the region <RegionId>
		And the description <Description>
		When the user tries to add the new charging spot with invalid data
		Then the following error <Error> should be raised

		Examples:
			| Name                              | Address                                      | RegionId | Description                                                                | Error                                                                |
			| Cargar parada 223 mas de 20 chars | General Flores                               | 1        | Punto de carga                                                             | the name must be alphanumeric with a maximum of 20 characters        |
			| Cargar parada @$#%#               | General Flores                               | 1        | Punto de carga                                                             | the name must be alphanumeric with a maximum of 20 characters        |
			| Cargar parada 2                   | General Flores General Flores General Flores | 1        | Punto de carga                                                             | the address must be alphanumeric with a maximum of 30 characters     |
			| Cargar parada 2                   | Direccion @2 !..%                            | 1        | Punto de carga                                                             | the address must be alphanumeric with a maximum of 30 characters     |
			| Cargar parada 2                   | General Flores                               | 0        | Punto de carga                                                             | Could not find specified region                                      |
			| Cargar parada 2                   | General Flores                               | 1        | Punto de carga Punto de carga Punto de carga Punto de carga Punto de carga | the description must be alphanumeric with a maximum of 60 characters |
			| Cargar parada 2                   | General Flores                               | 1        | Desc @[][]??                                                               | the description must be alphanumeric with a maximum of 60 characters |

	@ignore
	@mytag
	Scenario: Add charging spot with valid data
		Given an existing, logged in admin
			| Email            | Password |
			| matias@admin.com | admin    |
		And the existing region:
			| Id | Name     |
			| 2  | SurOeste |
		Given a new ChargingSpot with valid data to add:
			| Name            | Address        | RegionId | Description    |
			| Cargar parada 1 | General Flores | 2        | Punto de carga |
		When the user tries to add the charging spot
		Then the charging spot should be added to the database