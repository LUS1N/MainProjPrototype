import { Component, OnInit, Input } from '@angular/core';
import { Server } from '../models/server';
import { ServersService } from '../servers.service';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {

  @Input() servers: Server[];

  constructor(private srvService: ServersService) {
  }

  ngOnInit() {
    if (!this.servers)
      this.srvService.getServers().subscribe(servers => {
        this.servers = servers;
      }
      );
  }

}
