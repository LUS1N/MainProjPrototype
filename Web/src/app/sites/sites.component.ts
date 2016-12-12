import { Site } from '../models/site';
import { Server } from '../models/server';

import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { SitesService } from '../sites.service';

@Component({
  selector: 'app-sites',
  templateUrl: './sites.component.html',
  styleUrls: ['./sites.component.css']
})
export class SitesComponent implements OnInit {

  @Input() sites: Site[];
  @Input() server: Server;

  constructor(private route: ActivatedRoute,
    private sitesService: SitesService) { }

  ngOnInit() {
    console.log(this.sites)
    if (!this.sites) {
      this.getSites();
    } else {
      if (this.server) {
        for (var site of this.sites) {
          site.server = this.server;
        }
      }
    }
  }

  getSites() {
    this.sitesService.getSites().subscribe(sites =>
      this.sites = sites);
  }

}
