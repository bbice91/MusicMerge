import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NeuralStyleUploadComponent } from './neural-style-upload.component';

describe('AlbumUploadComponent', () => {
  let component: NeuralStyleUploadComponent;
  let fixture: ComponentFixture<NeuralStyleUploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NeuralStyleUploadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NeuralStyleUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
