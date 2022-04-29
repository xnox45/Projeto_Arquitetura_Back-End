import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ModalModule } from 'ngx-bootstrap/modal';
import { AppComponent } from './app.component';
import { Interceptor } from './app.interceptor.module';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SharedModule } from './shared/shared.module';
import { UsersComponent } from './users/users.component';
import { UserDataService } from './_data-service/user_data-service';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    UsersComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'users', component: UsersComponent },//rota para users
    ]),
    Interceptor,
    BrowserAnimationsModule,
    ModalModule.forRoot(),
    SharedModule
  ],
  providers: [UserDataService],
  bootstrap: [AppComponent],
})
export class AppModule { }
