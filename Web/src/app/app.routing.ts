import { Routes, RouterModule } from '@angular/router';

import { ServersComponent } from './servers/servers.component';
import { ServerDetailComponent } from './server-detail/server-detail.component';

import { SitesComponent } from './sites/sites.component';
import { SiteDetailComponent } from './site-detail/site-detail.component';

import { DatabasesComponent } from './databases/databases.component';
import { DatabaseDetailComponent } from './database-detail/database-detail.component';

import { OwnersComponent } from './owners/owners.component';
import { OwnerDetailComponent } from './owner-detail/owner-detail.component';

const appRoutes: Routes = [
    {
        path: '', // redirect root to servers
        redirectTo: '/servers',
        pathMatch: 'full'
    },
    {
        path: 'servers/:id',
        component: ServerDetailComponent
    },
    {
        path: 'servers',
        component: ServersComponent
    },
    {
        path: 'sites',
        component: SitesComponent
    },
    {
        path: 'sites/:id',
        component: SiteDetailComponent
    },
    {
        path: 'databases/:id',
        component: DatabaseDetailComponent
    },
    {
        path: 'databases',
        component: DatabasesComponent
    },
    {
        path: 'owners/:id',
        component: OwnerDetailComponent
    },
    {
        path: 'owners',
        component: OwnersComponent
    }
];

// returns a configured router module with appRoutes
export const routing = RouterModule.forRoot(appRoutes);


