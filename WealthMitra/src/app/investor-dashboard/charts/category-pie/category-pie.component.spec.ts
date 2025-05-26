import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CategoryPieComponent } from './category-pie.component';

describe('CategoryPieComponent', () => {
  let component: CategoryPieComponent;
  let fixture: ComponentFixture<CategoryPieComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CategoryPieComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CategoryPieComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
