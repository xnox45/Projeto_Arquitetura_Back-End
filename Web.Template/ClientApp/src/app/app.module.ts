import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { UsersComponent } from './users/users.component';
import { UserDataService } from './_data-service/user_data-service';
import { Interceptor } from './app.interceptor.module';
import { ModalinfoComponent } from './modalinfo/modalinfo.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersComponent,
    ModalinfoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users', component: UsersComponent },//rota para users
    ]),
    Interceptor
  ],
  providers: [UserDataService],
  bootstrap: [AppComponent],
  entryComponents: [ModalinfoComponent]
})
export class AppModule { }
