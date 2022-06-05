import { TestBed } from '@angular/core/testing';

import { CoverartarchiveService } from './cover-art-archive.service';

describe('CoverartarchiveService', () => {
  let service: CoverartarchiveService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CoverartarchiveService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
