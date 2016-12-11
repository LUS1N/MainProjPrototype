import {Owner} from './owner';
import {Site} from './site';
import {Database} from './database';
import {Entity} from './entity';

export class Server extends Entity {
    owner: Owner;
    ip: string;
    os: string;
    ownerId: number;
    sites: Site[];
    databases: Database[];
}

