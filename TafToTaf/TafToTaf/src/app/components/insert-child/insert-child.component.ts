import { Component, OnInit ,Input} from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-insert-child',
  templateUrl: './insert-child.component.html',
  styleUrls: ['./insert-child.component.scss']
})
export class InsertChildComponent implements OnInit {

  @Input() name;

  constructor(public activeModal: NgbActiveModal) {}

  ngOnInit() {
  }

}
