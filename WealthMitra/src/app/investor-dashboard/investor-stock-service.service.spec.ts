import { TestBed } from '@angular/core/testing';

import { InvestorStockServiceService } from './investor-stock-service.service';

describe('InvestorStockServiceService', () => {
  let service: InvestorStockServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InvestorStockServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
