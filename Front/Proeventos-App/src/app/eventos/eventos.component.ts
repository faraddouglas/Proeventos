import { Component } from '@angular/core'
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent {
  public eventos: any;
  public eventosFiltrados: any;
  larguraImagem: number = 70;
  margemImagem: number = 2;
  exibirImagem: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(){
    return this._filtroLista
  }

  public set filtroLista(value: string){
    this._filtroLista = value
  
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos
  }

  filtrarEventos(filtrarPor: string): any{
    filtrarPor = filtrarPor.toLocaleLowerCase();

    var eventos =  this.eventos.filter(
      (evento: any)=> {
       return evento.tema.toLocaleLowerCase().indexOf(filtrarPor) != - 1 ||
              evento.local.toLocaleLowerCase().indexOf(filtrarPor) != -1
      }
    )
    
    return eventos
  }

  constructor(private http: HttpClient){

  }

  ngOnInit(){
    this.getEventos()
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/Evento').subscribe({
      next: (res) => {
        this.eventos = res
        this.eventosFiltrados = this.eventos
        console.log(res)
      },
      error: (err) =>  console.log(err)
  })}

  public updateShowImage(input: boolean){
    this.exibirImagem = input
  }
}
