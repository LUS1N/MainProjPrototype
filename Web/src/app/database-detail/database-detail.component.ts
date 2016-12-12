import { Component, OnInit } from '@angular/core';
import { DatabasesService } from '../databases.service';
import { Database } from '../models/database';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-database-detail',
  templateUrl: './database-detail.component.html',
  styleUrls: ['./database-detail.component.css']
})
export class DatabaseDetailComponent implements OnInit {

  databaseId: number;
  database: Database;

  constructor(private route: ActivatedRoute,
    private dbServc: DatabasesService) {
  }

  ngOnInit() {
    this.route.params.forEach((params: Params) =>
      this.databaseId = +params['id']); // extract serverId

    this.getDatabase();
  }

  getDatabase() {
    this.dbServc.getDatabase(this.databaseId).subscribe(db =>
      this.database = db);
  }
}
