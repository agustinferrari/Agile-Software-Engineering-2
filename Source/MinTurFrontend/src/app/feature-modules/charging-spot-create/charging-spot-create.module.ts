import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateChargingSpotComponent } from './charging-spot-create.component';
import { UtilitiesModule } from 'src/app/shared/utilities/utilities.module';

@NgModule({
  imports: [
    CommonModule,
    UtilitiesModule
  ],
  declarations: [CreateChargingSpotComponent]
})
export class CreateChargingSpotModule { }
