import { Component, OnInit ,Input} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';


@Component({
  selector: 'app-insert-child',
  templateUrl: './insert-child.component.html',
  styleUrls: ['./insert-child.component.scss']
})
export class InsertChildComponent implements OnInit {

  @Input() kinderGardens:KinderGarden[];

  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit() {
  }
sumbit(){

}
helpfunc()
{
  
}

}
