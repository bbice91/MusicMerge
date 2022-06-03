import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-generated-art-piece',
  templateUrl: './generated-art-piece.component.html',
  styleUrls: ['./generated-art-piece.component.css']
})
export class GeneratedArtPieceComponent implements OnInit {

  constructor() { }


  @Input() imageURL1 = "https://neuralstyle.art/paintings/269269_XIUAFNFJ_600_wm.jpg"
  @Input() imageURL2 = "https://neuralstyle.art/paintings/269539_CIUDLRUF_600_wm.jpg"
  @Input() imageURL3 = "https://neuralstyle.art/paintings/269620_FFNHPCNM_600_wm.jpg"
  @Input() imageURL4 = "https://neuralstyle.art/paintings/269716_QWRODXSD_600_wm.jpg"
 
  ngOnInit(): void {
  }

}
