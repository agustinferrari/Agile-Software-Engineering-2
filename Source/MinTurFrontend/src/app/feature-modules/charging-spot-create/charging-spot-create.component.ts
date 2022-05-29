import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { RegionService } from 'src/app/core/http-services/region/region.service';
import { ChargingSpotService } from 'src/app/core/http-services/charging-spot/charging-spot.service';
import { RegionBasicInfoModel } from 'src/app/shared/models/out/region-basic-info-model';
import { ChargingSpotIntentModel } from 'src/app/shared/models/out/charging-spot-intent-model';

@Component({
  selector: 'app-charging-spot-create',
  templateUrl: './charging-spot-create.component.html',
  styleUrls: [],
})
export class CreateChargingSpotComponent implements OnInit {
  public explanationTitle: string;
  public explanationDescription: string;
  public justCreatedChargingSpot = false;
  public name: string;
  public address: string;
  public description: string;
  public regionId: number;
  public displayError: boolean;
  public errorMessages: string[] = [];
  public regions: RegionBasicInfoModel[] = [];
  private charginSpotIntentModel: ChargingSpotIntentModel;

  constructor(
    private chargingSpotService: ChargingSpotService,
    private regionService: RegionService
  ) {}

  ngOnInit(): void {
    this.getRegions();
    this.populateExplanationParams();
  }

  public regionElementId(region: RegionBasicInfoModel): string {
    return 'region-' + region.id;
  }

  private getRegions(): void {
    this.regionService.allRegions().subscribe(
      (regions) => {
        this.loadRegions(regions);
      },
      (error) => this.showError(error)
    );
  }

  private loadRegions(regions: RegionBasicInfoModel[]): void {
    this.regions = regions;
  }

  public setName(name: string): void {
    this.name = name;
  }

  public setAddress(address: string): void {
    this.address = address;
  }

  public setDescription(description: string): void {
    this.description = description;
  }

  public selectRegion(regionId: number): void {
    this.regionId = regionId;
  }

  public createChargingSpot(): void {
    this.validateInputs();

    if (!this.displayError) {
      this.charginSpotIntentModel = {
        name: this.name,
        address: this.address,
        description: this.description,
        regionId: this.regionId,
      };
      this.chargingSpotService
        .createChargingSpot(this.charginSpotIntentModel)
        .subscribe(
          (chargingSpotBasicInfoModel) => {
            this.justCreatedChargingSpot = true;
          },
          (error) => this.showError(error)
        );
    } else {
      this.justCreatedChargingSpot = false;
    }
  }

  private validateInputs(): void {
    this.displayError = false;
    this.errorMessages = [];
    this.validateName();
    this.validateAddress();
    this.validateDescription();
    this.validateRegion();
  }

  private validateName(): void {
    if (!this.name?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar un nombre');
    }
  }

  private validateAddress(): void {
    if (!this.address?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una dirección');
    }
  }

  private validateDescription(): void {
    if (!this.description?.trim()) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una descripción');
    }
  }

  private validateRegion(): void {
    if (!this.regionId) {
      this.displayError = true;
      this.errorMessages.push('Es necesario especificar una región');
    }
  }

  private showError(error: HttpErrorResponse): void {
    console.log(error);
  }

  public closeError(): void {
    this.displayError = false;
  }

  private populateExplanationParams(): void {
    this.explanationTitle = 'Crear un punto de carga';
    this.explanationDescription = 'Aquí puedes crear puntos de carga!';
  }
}
