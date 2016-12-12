import { Component, OnInit } from '@angular/core';
import { Owner } from '../models/owner';
import { OwnersService } from '../owners.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-owner-detail',
  templateUrl: './owner-detail.component.html',
  styleUrls: ['./owner-detail.component.css']
})
export class OwnerDetailComponent implements OnInit {

  ownerId: number;
  owner: Owner;

  constructor(private route: ActivatedRoute, private oSrvc: OwnersService) {
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) =>
      this.ownerId = +params['id']); // extract serverId

    this.getOwner();
  }

  getOwner() {
    this.oSrvc.getOwner(this.ownerId).subscribe(o =>
      this.owner = o);
  }

}
