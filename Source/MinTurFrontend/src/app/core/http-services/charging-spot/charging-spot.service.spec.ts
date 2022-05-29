/* eslint-disable @typescript-eslint/no-unused-vars */

import { TestBed, async, inject } from '@angular/core/testing';
import { ChargingSpotService } from './charging-spot.service';

describe('Service: ChargingSpot', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChargingSpotService]
    });
  });

  it('should ...', inject([ChargingSpotService], (service: ChargingSpotService) => {
    expect(service).toBeTruthy();
  }));
});
