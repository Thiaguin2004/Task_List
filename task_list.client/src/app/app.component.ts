import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Projeto {
  id: number;
  nome: string;
  descricao: string;
}
interface Usuario {
  id: number;
  nome: string;
  senha: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public projetos: Projeto[] = [];
  public usuarios: Usuario[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getProjetos();
    this.getUsuarios();
  }

  getUsuarios() {
    this.http.get<Usuario[]>('/usuarios').subscribe(
      (result) => {
        this.usuarios = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  getProjetos() {
    this.http.get<Projeto[]>('/projetos').subscribe(
      (result) => {
        this.projetos = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'task_list.client';
}
