import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainNagivationBarComponent } from './main-nagivation-bar.component';

describe('MainNagivationBarComponent', () => {
  let component: MainNagivationBarComponent;
  let fixture: ComponentFixture<MainNagivationBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainNagivationBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MainNagivationBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
