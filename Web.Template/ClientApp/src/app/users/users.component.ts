import { Component, OnInit } from '@angular/core';
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

  showEdit: boolean = true;

  textheader: string = "null";

  textButton: string = "null";

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
      }

      else {
        alert("Erro a Cadastrar usuário");
      }
    },
      error => {
        console.log(error);
        alert("Erro interno no sistema");
      }
    );
  }

  put() {
    this.userDataService.Put(this.user).subscribe(data => {
      if (data == true) {
        alert("Usuário Atualizado");
        this.get();
      }
      else {
        alert("Erro a Atualizar usuário");
      }
    },
      error => {
        console.log(error);
        alert("Erro interno no sistema");
      }
    )
  }

  save() {

    console.log(this.user);

    if (this.isKeyExists(this.user, "id")) {
      this.put();
    }

    else {
      this.post();
    }

  }

  ShowAddUser() {
    this.user = {}; // Limpando campos
    this.showList = !this.showList;
    this.textheader = 'Adicionar Usuário';
    this.textButton = 'Adicionar';
  }

  openDetails(data) {
    console.log(data);
    this.showList = false;
    this.user = data;
    this.textheader = "Editar Usuário: " + data.name;
    this.textButton = 'Confirmar';
  }

  isKeyExists(obj, key) {
    if (obj[key] == undefined) {
      return false;
    } else {
      return true;
    }
  }

}
