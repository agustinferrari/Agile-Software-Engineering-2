/* eslint-disable @typescript-eslint/no-unused-vars */

import { TestBed, async, inject } from '@angular/core/testing';
import { ReviewService } from './review.service';

describe('Service: Review', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ReviewService]
    });
  });

  it('should ...', inject([ReviewService], (service: ReviewService) => {
    expect(service).toBeTruthy();
  }));
});
