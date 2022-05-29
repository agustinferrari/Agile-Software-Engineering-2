import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/core/http-services/admin/admin.service';
import { ChargingSpotRoutes } from 'src/app/core/routes';
import { AdministratorBasicInfoModel } from 'src/app/shared/models/in/administrator-basic-info-model';

@Component({
  selector: 'charging-spot-list',
  templateUrl: './charging-spot-list.component.html',
  styleUrls: []
})
export class ChargingSpotList implements OnInit {

  public administrators: AdministratorBasicInfoModel[];
  public ownEmail: string;

  constructor(private adminService: AdminService, private router: Router) { }

  ngOnInit(): void {
    this.ownEmail = JSON.parse(localStorage.getItem('userInfo'))?.email ?? 'administrador';
    this.getAdministrators();
  }

  private getAdministrators(): void{
    this.adminService.allAdministrators()
    .subscribe(administratorsInfo => this.loadAdministrators(administratorsInfo),
      (error: HttpErrorResponse) => this.showError(error));
  }

  private loadAdministrators(administratorsInfo: AdministratorBasicInfoModel[]): void {
    this.administrators = administratorsInfo;
  }

  public deleteAdministrator(administratorId: number): void {
    this.adminService.deleteOneAdministrator(administratorId)
      .subscribe((response) => this.getAdministrators(),
        (error: HttpErrorResponse) => this.showError(error));
  }

  public isItMe(email: string): boolean {
    return this.ownEmail === email;
  }

  public goToChargingSpotCreate(): void{
    this.router.navigate([ChargingSpotRoutes.CHARGING_SPOT_CREATE], {replaceUrl: true});
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }
}
