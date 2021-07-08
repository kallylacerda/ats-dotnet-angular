import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateEditCandidatoComponent } from './create-edit-candidato.component';

describe('CreateEditCandidatoComponent', () => {
  let component: CreateEditCandidatoComponent;
  let fixture: ComponentFixture<CreateEditCandidatoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateEditCandidatoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateEditCandidatoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
