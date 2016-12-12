import { Owner } from '../models/owner';
import { Component, OnInit } from '@angular/core';
import { OwnersService } from '../owners.service';

@Component({
  selector: 'app-owners',
  templateUrl: './owners.component.html',
  styleUrls: ['./owners.component.css']
})
export class OwnersComponent implements OnInit {

  constructor(private ownService: OwnersService) { }

  owners: Owner[];

  ngOnInit() {
    this.getOwners();
  }

  getOwners() {
    this.ownService.getOwners().subscribe(owners =>
      this.owners = owners);
  }
}
