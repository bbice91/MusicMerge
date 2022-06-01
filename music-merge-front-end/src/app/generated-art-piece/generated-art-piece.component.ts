import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-generated-art-piece',
  templateUrl: './generated-art-piece.component.html',
  styleUrls: ['./generated-art-piece.component.css']
})
export class GeneratedArtPieceComponent implements OnInit {

  constructor() { }


  @Input() imageURL1 = "https://cdn.openai.com/dall-e-2/demos/text2im/astronaut/horse/photo/0.jpg"
  @Input() imageURL2 = "https://cdn.openai.com/dall-e-2/demos/inpainting/flamingo_pool/a/0.jpg"
 
  ngOnInit(): void {
  }

}
