import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { UserDataService } from '../_data-service/user_data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];

  constructor(private userDataService: UserDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.userDataService.get().subscribe(
      (data: any[]) => {
        this.users = data;
      },
      error => {
        console.log(error);
        alert("Erro interno no sistema");
      }
    );
  }

}
