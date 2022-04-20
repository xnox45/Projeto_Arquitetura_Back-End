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

  user: any = {};

  showList: boolean = true;

  constructor(private userDataService: UserDataService) { }

  ngOnInit() {
    this.get();
  }

  get() {
    this.userDataService.Get().subscribe(
      (data: any[]) => {
        this.users = data;
        this.showList = true;//retronando para a tabela de usuários
      },
      error => {
        console.log(error);
        alert("Erro interno no sistema");
      }
    );
  }

  post() {
    this.userDataService.Post(this.user).subscribe(data => { //data ja é o response
      if (data == true) {
        alert("Usuário Cadastrado");
        this.get(); //Recarregando dados sem precisar atualizar toda a pagina
        this.user = {}; // Limpando campos
      }

      else{
        alert("Erro a Cadastrar usuário");
      }
    },
      error => {
        console.log(error);
        alert("Erro interno no sistema");
      }
    );
  }

}
