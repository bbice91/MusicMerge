import { TestBed } from '@angular/core/testing';

import { AlbumsByArtistService } from './albums-by-artist.service';

describe('AlbumsByArtistService', () => {
  let service: AlbumsByArtistService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AlbumsByArtistService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
