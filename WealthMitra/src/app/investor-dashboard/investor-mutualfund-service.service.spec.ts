import { TestBed } from '@angular/core/testing';

import { InvestorMutualfundServiceService } from './investor-mutualfund-service.service';

describe('InvestorMutualfundServiceService', () => {
  let service: InvestorMutualfundServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestorMutualfundServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
