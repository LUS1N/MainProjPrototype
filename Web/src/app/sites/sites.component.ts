import { Site } from '../models/site';
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

  constructor(private route: ActivatedRoute,
    private sitesService: SitesService) { }

  ngOnInit() {
    if (!this.sites) {
      this.getSites();
    }
  }

  getSites() {
    this.sitesService.getSites().subscribe(sites =>
      this.sites = sites);
  }

}
