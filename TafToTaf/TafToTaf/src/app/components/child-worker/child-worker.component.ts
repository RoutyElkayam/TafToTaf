import { Component, OnInit } from '@angular/core';
import { Child } from 'src/app/shared/models/child';
import { KinderGarden } from 'src/app/shared/models/kinderGarden';
import { ChildKinderGardenService } from 'src/app/shared/services/child-kinder-garden.service';
import { ChildService } from 'src/app/shared/services/child.service';
import { KindergardenService } from 'src/app/shared/services/kindergarden.service';
import {AccountService} from 'src/app/shared/services/account.service';


@Component({
  selector: 'app-child-worker',
  templateUrl: './child-worker.component.html',
  styleUrls: ['./child-worker.component.scss']
})
export class ChildWorkerComponent implements OnInit {

  children: Child[];
  kinderGardens: KinderGarden[];
  selectkng: string = null;


  constructor( public kinderGardenService: KindergardenService,
    public childService: ChildService,
    public childKinderGardenService: ChildKinderGardenService,
    public accountService: AccountService) { }

  ngOnInit() {

    this.getChildren();

  }

  getChildren(): void {
    this.childService.getChildren()
      .subscribe(children => { this.children = children });
  }

 

}
