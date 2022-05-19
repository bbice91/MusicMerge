import { TestBed } from '@angular/core/testing';

import { GeneratedImagesService } from './generated-images.service';

describe('GeneratedImagesService', () => {
  let service: GeneratedImagesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GeneratedImagesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
