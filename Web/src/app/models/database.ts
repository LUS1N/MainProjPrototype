import { Owner } from './owner';
import { Site } from './site';
import { Server } from './server';
import { Entity } from './entity';

export class Database extends Entity {
    owner: Owner;
    sites: Site[];
    server: Server;
    ownerId: number;
    serverId: number;
}
