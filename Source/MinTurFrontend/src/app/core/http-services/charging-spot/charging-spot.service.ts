import { ChargingSpotEndpoints } from '../endpoints';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ChargingSpotBasicInfoModel } from 'src/app/shared/models/out/charging-spot-basic-info-model';
import { ChargingSpotIntentModel } from 'src/app/shared/models/out/charging-spot-intent-model';

@Injectable({
  providedIn: 'root'
})
export class ChargingSpotService {
  
  constructor(private http: HttpClient) { }

  public createChargingSpot(newChargingSpot: ChargingSpotIntentModel): Observable<ChargingSpotBasicInfoModel[]> {
    return this.http.post<ChargingSpotBasicInfoModel[]>(ChargingSpotEndpoints.GET_CHARGING_SPOTS, newChargingSpot);
  }
}
