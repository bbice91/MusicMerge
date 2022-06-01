import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlbumListViewComponent } from './album-list-view.component';

describe('ListViewComponent', () => {
  let component: AlbumListViewComponent;
  let fixture: ComponentFixture<AlbumListViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlbumListViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AlbumListViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
