import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { format } from 'util';
import { AdminEndpoints, ChargingSpotEndpoints } from '../endpoints';
import { AdministratorBasicInfoModel } from 'src/app/shared/models/in/administrator-basic-info-model';
import { AdministratorIntentModel } from 'src/app/shared/models/out/administrator-intent-model';
import { ChargingSpotBasicInfoModel } from 'src/app/shared/models/in/charging-spot-basic-info-model';

@Injectable({
  providedIn: 'root'
})
export class ChargingSpotService {

  constructor(private http: HttpClient) {}

  public allChargingSpots(): Observable<ChargingSpotBasicInfoModel[]>{
    return this.http.get<ChargingSpotBasicInfoModel[]>(ChargingSpotEndpoints.GET_CHARGING_SPOTS);
  }
}
