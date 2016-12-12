import { Component, OnInit, Input } from '@angular/core';
import { Database } from '../models/database';
import { Server } from '../models/server';
import { DatabasesService } from '../databases.service';

@Component({
  selector: 'app-databases',
  templateUrl: './databases.component.html'
})
export class DatabasesComponent implements OnInit {

  @Input() databases: Database[];
  @Input() server: Server;

  constructor(private dbService: DatabasesService) { }

  ngOnInit() {
    if (!this.databases)
      this.getDatabase();
    else {
      if (this.server) {
        for (var db of this.databases) {
          db.server = this.server;
        }
      }
    }
  }

  getDatabase() {
    this.dbService.getDatabases().subscribe(dbs =>
      this.databases = dbs);
  }
}
