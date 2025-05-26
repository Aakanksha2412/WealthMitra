import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayMutualFundComponent } from './display-mutual-fund.component';

describe('DisplayMutualFundComponent', () => {
  let component: DisplayMutualFundComponent;
  let fixture: ComponentFixture<DisplayMutualFundComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayMutualFundComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DisplayMutualFundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
