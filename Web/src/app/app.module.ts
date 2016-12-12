import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ServersComponent } from './servers/servers.component';
import { ServersService } from './servers.service';
import { SitesService } from './sites.service';
import { DatabasesService } from './databases.service';
import { OwnersService } from './owners.service';

import { ConfigService } from './config.service';
import { routing } from './app.routing';

import { ServerDetailComponent } from './server-detail/server-detail.component';
import { SitesComponent } from './sites/sites.component';
import { SiteDetailComponent } from './site-detail/site-detail.component';
import { DatabasesComponent } from './databases/databases.component';
import { DatabaseDetailComponent } from './database-detail/database-detail.component';
import { OwnerDetailComponent } from './owner-detail/owner-detail.component';
import { OwnersComponent } from './owners/owners.component';

@NgModule({
  declarations: [
    AppComponent,
    ServersComponent,
    ServerDetailComponent,
    SitesComponent,
    SiteDetailComponent,
    DatabasesComponent,
    DatabaseDetailComponent,
    OwnerDetailComponent,
    OwnersComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [
    ServersService,
    ConfigService,
    SitesService,
    DatabasesService,
    OwnersService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
