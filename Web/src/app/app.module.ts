import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { ServersComponent } from './servers/servers.component';
import { ServersService } from './servers.service';
import { ConfigService } from './config.service';
import { routing } from './app.routing';
import { ServerDetailComponent } from './server-detail/server-detail.component';
@NgModule({
  declarations: [
    AppComponent,
    ServersComponent,
    ServerDetailComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing
  ],
  providers: [ServersService, ConfigService],
  bootstrap: [AppComponent]
})
export class AppModule { }
