import { ChargingSpotEndpoints } from '../endpoints';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChargingSpotBasicInfoModel } from 'src/app/shared/models/in/charging-spot-basic-info-model';
import { ChargingSpotIntentModel } from 'src/app/shared/models/out/charging-spot-intent-model';
import { format } from 'util';

@Injectable({
  providedIn: 'root'
})
export class ChargingSpotService {

  constructor(private http: HttpClient) { }

  public createChargingSpot(newChargingSpot: ChargingSpotIntentModel): Observable<ChargingSpotBasicInfoModel[]> {
    return this.http.post<ChargingSpotBasicInfoModel[]>(ChargingSpotEndpoints.CREATE_CHARGING_SPOT, newChargingSpot);
  }

  public allChargingSpots(): Observable<ChargingSpotBasicInfoModel[]>{
    return this.http.get<ChargingSpotBasicInfoModel[]>(ChargingSpotEndpoints.GET_CHARGING_SPOTS);
  }

  public deleteOneChargingSpot(chargingSpotId: number): Observable<void>{
    return this.http.delete<void>(format(ChargingSpotEndpoints.DELETE_ONE_CHARGING_SPOT, chargingSpotId));
  }
}
