import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChargingSpotRoutes } from 'src/app/core/routes';
import { ChargingSpotService } from 'src/app/core/http-services/charging-spot/charging-spot.service';
import { ChargingSpotBasicInfoModel } from 'src/app/shared/models/in/charging-spot-basic-info-model';

@Component({
  selector: 'charging-spot-list',
  templateUrl: './charging-spot-list.component.html',
  styleUrls: []
})
export class ChargingSpotListComponent implements OnInit {

  public chargingSpots: ChargingSpotBasicInfoModel[];
  public ownEmail: string;

  constructor(private chargingSpotService: ChargingSpotService, private router: Router) { }

  ngOnInit(): void {
    this.ownEmail = JSON.parse(localStorage.getItem('userInfo'))?.email ?? 'administrador';
    this.getChargingSpots();
  }

  private getChargingSpots(): void{
    this.chargingSpotService.allChargingSpots()
    .subscribe(chargingSpotsInfo => this.loadChargingSpots(chargingSpotsInfo),
      (error: HttpErrorResponse) => this.showError(error));
  }

  private loadChargingSpots(chargingSpotsInfo: ChargingSpotBasicInfoModel[]): void {
    this.chargingSpots = chargingSpotsInfo;
  }

  public deleteChargingSpot(chargingSpotId: number): void {
    console.log("DeleteChargingSPot: " + chargingSpotId);
    // this.chargingSpotService.deleteOneAdministrator(chargingSpotId)
    //   .subscribe((response) => this.getAdministrators(),
    //     (error: HttpErrorResponse) => this.showError(error));
  }

  public goToChargingSpotCreate(): void{
    this.router.navigate([ChargingSpotRoutes.CHARGING_SPOT_CREATE], {replaceUrl: true});
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }
}
