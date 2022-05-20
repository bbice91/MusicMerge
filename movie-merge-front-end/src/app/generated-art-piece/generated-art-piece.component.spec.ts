import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GeneratedArtPieceComponent } from './generated-art-piece.component';

describe('GeneratedArtPieceComponent', () => {
  let component: GeneratedArtPieceComponent;
  let fixture: ComponentFixture<GeneratedArtPieceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GeneratedArtPieceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GeneratedArtPieceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
