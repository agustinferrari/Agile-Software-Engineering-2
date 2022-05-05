/* eslint-disable @typescript-eslint/no-unused-vars */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReservationService } from './reservation.service';

describe('Service: Reservation', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReservationService]
    });
  });

  it('should ...', inject([ReservationService], (service: ReservationService) => {
    expect(service).toBeTruthy();
  }));
});
