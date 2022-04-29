import { Component, OnInit } from '@angular/core';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { AlertmodalComponent } from '../shared/alertmodal/alertmodal.component';
import { UserDataService } from '../_data-service/user_data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  users: any[] = [];

  user: any = {};

  userLogin: any = {};

  userLogged: any = {};

  isAuthenticated: boolean = false;

  showList: boolean = true;

  showEdit: boolean = true;

  textheader: string = "Adicionar Usuário";

  textButton: string = "Adicionar";

  Token: any = {};

  bsModalRef = new BsModalRef<AlertmodalComponent>();

  constructor(private userDataService: UserDataService, private modalService: BsModalService) { }

  ngOnInit() {
  }

  get() {
    this.userDataService.Get().subscribe(
      (data: any[]) => {
        this.users = data;
        this.showList = true;//retornando para a tabela de usuários
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
        this.handlerSuccess("Usuário Cadastrado");
        this.get(); //Recarregando dados sem precisar atualizar toda a pagina
      }

      else {
        this.handlerError("Erro a Cadastrar usuário");
      }
    },
      error => {
        console.log(error);
        this.handlerError("Nenhum campo pode ser vazio");
      }
    );
  }

  put() {
    this.userDataService.Put(this.user).subscribe(data => {
      if (data == true) {
        this.handlerSuccess("Usuário Atualizado");
        this.get();
      }
      else {
        this.handlerError("Erro a Atualizar usuário");
      }
    },
      error => {
        console.log(error);
        this.handlerError("Erro interno no sistema");
      }
    )
  }

  save() {
    //verificando se é edição ou criação de usuario
    if (this.isKeyExists(this.user, "id")) {
      this.put();
    }

    else {
      this.post();
    }

  }

  delete(id) {
    this.Token = JSON.parse(localStorage.getItem('user_logged'));
    if (id == this.Token.user.id) {
      this.userDataService.Delete().subscribe(
        data => {
          console.log(data);
          this.handlerSuccess("Usuario deletado com sucesso");
          this.ShowLogin();
        },
        erro => {
          console.log(erro);
          this.handlerError("Erro interno no sistema");
        }
      );
    }
    else {
      return this.handlerError("Você só pode excluir seu proprio usuário");
    }
  }

  authenticate() {
    this.userDataService.Authenticate(this.userLogin).subscribe(
      (data: any) => {
        if (this.isKeyExists(data, "user")) {
          localStorage.setItem('user_logged', JSON.stringify(data));//setando item no local storage para buscar futuramente
          this.get();
          this.getUserData();
        }
        else {
          this.handlerError("usuario invalido")
        }
      },
      erro => {
        console.log(erro);
        this.handlerError(erro.error);
      }
    );
  }

  ShowLogin() {
    this.userLogin = {};

    this.isAuthenticated = false;
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

  getUserData() {
    this.userLogged = JSON.parse(localStorage.getItem('user_logged'));

    this.isAuthenticated = this.userLogged != null;
  }

  isKeyExists(obj, key) {//verificando se a propriedade existe no objeto
    if (obj[key] == undefined) {
      return false;
    } else {
      return true;
    }
  }

  handlerError(message) {
    this.bsModalRef = this.modalService.show(AlertmodalComponent);
    this.bsModalRef.content.type = 'danger';
    this.bsModalRef.content.message = message;
  }

  handlerSuccess(message) {
    this.bsModalRef = this.modalService.show(AlertmodalComponent);
    this.bsModalRef.content.type = 'success';
    this.bsModalRef.content.message = message;
  }
}
