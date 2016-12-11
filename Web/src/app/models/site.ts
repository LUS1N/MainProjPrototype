import {Owner} from './owner';
import {Database} from './database';
import {Entity} from './entity';
import {Server} from './server';

export class Site extends Entity {
    owner: Owner;
    server: Server;
    ownerId: number;
    serverId: number;
    databases: Database[];
}
