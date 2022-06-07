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
  @Input() imageURL3 = "https://images.fineartamerica.com/images/artworkimages/mediumlarge/3/the-scream-under-the-starry-night-mihaela-pater.jpg"
  @Input() imageURL4 = "https://miro.medium.com/max/1258/1*LKrowjzqbNjkohF6ddI1sQ.png"
  @Input() imageURL5 = "https://www.angrymetalguy.com/wp-content/uploads/2019/03/sentynel-avatar-500x500.png"
  @Input() imageURL6 = "https://miro.medium.com/max/1180/1*dLNwo2fhB6FJZJJOEixTLA.png"
  @Input() imageURL7 = "https://images.immediate.co.uk/production/volatile/sites/4/2021/06/AI-music--e12d6aa.jpg?quality=90&resize=768,574"
  @Input() imageURL8 = "https://cdn.openai.com/research-covers/jukebox/2x-no-mark.jpg"
  @Input() imageURL9 = "https://i0.wp.com/www.printmag.com/wp-content/uploads/2017/06/2a34d8_ac07e952189a49eb82011677e7125b59mv2.jpg?fit=481%2C270&ssl=1"
  @Input() imageURL10 = "https://miro.medium.com/max/600/1*Yy-Aie2QSbGkfWDicqUBJA.png"
  @Input() imageURL11 = "https://miro.medium.com/max/1200/1*GvEa_NPfSc5ujONg7-uiVg.png"
  @Input() imageURL12 = "https://ztthoughtscom.files.wordpress.com/2018/05/bad-vibrations1.jpg?w=840"
  @Input() imageURL13 = "https://miro.medium.com/max/1400/1*ooNTndXcwMUcArRKoeS0eA.jpeg"
  @Input() imageURL14 = "https://assets.website-files.com/60a0ade9a9e15bdd6b98f68b/60e8a0777c64ff2ee524b1a2_create%20your%20own%20album%20artwork%20with%20canva.jpg"
  @Input() imageURL15 = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR9mlWXVb-3AcxkkNjGgoO_ra1oA_trgiJbUg&usqp=CAU"
 
  ngOnInit(): void {
  }

}
