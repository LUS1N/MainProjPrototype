import { Routes, RouterModule } from '@angular/router';
import { ServersComponent } from './servers/servers.component';

const appRoutes: Routes = [
    {
        path: '', // redirect root to servers
        redirectTo: '/servers',
        pathMatch: 'full'
    },
    {
        path: 'servers',
        component: ServersComponent
    }
];

// returns a configured router module with appRoutes
export const routing = RouterModule.forRoot(appRoutes);


//   {
//         path: 'servers/:id',
//         component: ServerDetailComponent
//     },