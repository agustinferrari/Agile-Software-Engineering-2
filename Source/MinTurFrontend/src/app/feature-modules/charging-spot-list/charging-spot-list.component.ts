import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ChargingSpotRoutes } from 'src/app/core/routes';
import { ChargingSpotService } from 'src/app/core/http-services/charging-spot/charging-spot.service';
import { ChargingSpotBasicInfoModel } from 'src/app/shared/models/in/charging-spot-basic-info-model';
import { UserIsLoggedIn } from 'src/app/shared/helpers/LoginStatus';
@Component({
  selector: 'charging-spot-list',
  templateUrl: './charging-spot-list.component.html',
  styleUrls: [],
})
export class ChargingSpotListComponent implements OnInit {
  public chargingSpots: ChargingSpotBasicInfoModel[];
  public ownEmail: string;
  public displayError: boolean;
  public errorMessages: string[];

  constructor(
    private chargingSpotService: ChargingSpotService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.ownEmail =
      JSON.parse(localStorage.getItem('userInfo'))?.email ?? 'administrador';
    this.getChargingSpots();
    this.displayError = false;
    this.errorMessages = [];
  }

  private getChargingSpots(): void {
    this.chargingSpotService.allChargingSpots().subscribe(
      (chargingSpotsInfo) => this.loadChargingSpots(chargingSpotsInfo),
      (error: HttpErrorResponse) => this.showError(error)
    );
  }

  public IsLoggedIn(): boolean {
    return UserIsLoggedIn();
  }

  private loadChargingSpots(
    chargingSpotsInfo: ChargingSpotBasicInfoModel[]
  ): void {
    this.chargingSpots = chargingSpotsInfo;
    if (this.chargingSpots.length === 0) {
      this.displayError = true;
      this.errorMessages.push('No charging spots in system');
    }
  }

  public deleteChargingSpot(chargingSpotId: number): void {
    console.log('DeleteChargingSPot: ' + chargingSpotId);
    this.chargingSpotService.deleteOneChargingSpot(chargingSpotId).subscribe(
      (response) => this.getChargingSpots(),
      (error: HttpErrorResponse) => this.showError(error)
    );
  }

  public goToChargingSpotCreate(): void {
    this.router.navigate([ChargingSpotRoutes.CHARGING_SPOT_CREATE], {
      replaceUrl: true,
    });
  }

  public closeError(): void {
    this.displayError = false;
  }

  private showError(error: HttpErrorResponse): void {
    this.errorMessages.push(error.message);
    console.log(error);
  }
}
