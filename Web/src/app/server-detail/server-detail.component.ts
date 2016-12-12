import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ServersService } from '../servers.service';
import { Server } from '../models/server';
import { OwnersService } from '../owners.service';

@Component({
  selector: 'app-server-detail',
  templateUrl: './server-detail.component.html',
  styleUrls: ['./server-detail.component.css']
})
export class ServerDetailComponent implements OnInit {

  serverId: number;
  server: Server;
  constructor(private route: ActivatedRoute,
    private ownersService: OwnersService, private srvService: ServersService) {
  }

  ngOnInit(): void {
    this.route.params.forEach((params: Params) =>
      this.serverId = +params['id']); // extract serverId

    this.getServer();
  }

  getServer() {
    this.srvService.getServer(this.serverId).subscribe(server => {
      this.server = server;
    });
  }

  updateOwner(id: number) {
    this.ownersService.updateEntitiesOwner<Server>(this.server.href, id).subscribe(server => this.server = server);
  }
}
