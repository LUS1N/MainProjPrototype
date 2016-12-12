import { Component, OnInit } from '@angular/core';
import { Server } from '../models/server';
import { ServersService } from '../servers.service';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {

  servers: Server[];

  constructor(private srvService: ServersService) {
  }

  ngOnInit() {
    this.srvService.getServers().subscribe(servers => {
      this.servers = servers;
    }
    );
  }

}
