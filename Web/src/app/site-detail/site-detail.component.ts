import {OwnersService} from '../owners.service';
import {Site} from '../models/site';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import {SitesService} from '../sites.service';

@Component({
  selector: 'app-site-detail',
  templateUrl: './site-detail.component.html',
  styleUrls: ['./site-detail.component.css']
})
export class SiteDetailComponent implements OnInit {

  siteId: number;
  site: Site;

  constructor(private route: ActivatedRoute,
  private ownersService: OwnersService,
    private siteService: SitesService) {
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) =>
      this.siteId = +params['id']); // extract serverId

    this.getSite();
  }

  getSite() {
    this.siteService.getSite(this.siteId).subscribe(s =>
      this.site = s);
  }

  updateOwner(id: number){
    this.ownersService.updateEntitiesOwner<Site>(this.site.href, id).subscribe(site => this.site = site);
  }
}
