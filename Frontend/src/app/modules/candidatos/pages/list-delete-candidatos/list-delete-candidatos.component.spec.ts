import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCandidatosComponent } from './list-delete-candidatos.component';

describe('ListCandidatosComponent', () => {
  let component: ListCandidatosComponent;
  let fixture: ComponentFixture<ListCandidatosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ListCandidatosComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListCandidatosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
