import { Component, OnInit, Input } from '@angular/core';
import { Database } from '../models/database';
import { DatabasesService } from '../databases.service';

@Component({
  selector: 'app-databases',
  templateUrl: './databases.component.html',
  styleUrls: ['./databases.component.css']
})
export class DatabasesComponent implements OnInit {

  @Input() databases: Database[];

  constructor(private dbService: DatabasesService) { }

  ngOnInit() {
    if (!this.databases)
      this.getDatabase();
  }

  getDatabase() {
    this.dbService.getDatabases().subscribe(dbs =>
      this.databases = dbs);
  }
}
