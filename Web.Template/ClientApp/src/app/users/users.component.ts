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

  textheader: string = "Adicionar Usuário";

  textButton: string = "Adicionar";

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

    //verificando se é edição ou criação de usuario
    if (this.isKeyExists(this.user, "id")) {
      this.put();
    }

    else {
      this.post();
    }

  }

  delete(id) {
    console.log(id);

    this.userDataService.Delete(id).subscribe(
      data =>
      {
        console.log(data);
        alert("Usuario deletado com sucesso");
        this.get();
      },
      erro =>
      {
        console.log(erro);
        alert("Erro interno no sistema");
      }
    );
  }

  ShowAddUser() {
    this.user = {}; // Limpando campos
    this.showList = !this.showList;
  }

  openDetails(data) {
    console.log(data);
    this.showList = false;
    this.user = data;
    this.textheader = "Editar Usuário: " + data.name;
    this.textButton = 'Confirmar';
  }

  isKeyExists(obj, key) {//verificando se a propriedade existe no objeto
    if (obj[key] == undefined) {
      return false;
    } else {
      return true;
    }
  }

}
